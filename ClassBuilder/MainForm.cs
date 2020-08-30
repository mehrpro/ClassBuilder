using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace ClassBuilder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private string ConnectionString_MySql(string database)
        {
            var connectionStringBuilder = new MySqlConnectionStringBuilder();
            connectionStringBuilder.Server = DataSourceTextBox.Text.Trim();
            connectionStringBuilder.Port = 3306;
            connectionStringBuilder.Database = database;
            if (UserIDCheckBox.Checked)
            {
                // connectionStringBuilder.IntegratedSecurity = false;
                connectionStringBuilder.UserID = UserIDTextBox.Text.Trim();
                connectionStringBuilder.Password = PasswordTextBox.Text.Trim();
            }
            else
                connectionStringBuilder.IntegratedSecurity = true;
            return connectionStringBuilder.ToString();
            //  return "Server=localhost;Port=3306;dataUid=root;Pwd=Ss987654";
        }
        private void UserIDCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserIDTextBox.Enabled = PasswordTextBox.Enabled = UserIDCheckBox.Checked;
            if (UserIDCheckBox.Checked)
            {
                UserIDTextBox.Focus();
            }
            else
            {
                DataSourceTextBox.Focus();
            }
        }
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(ConnectionString_MySql("information_schema")))
            {
                connection.Open();
                var cmd = new MySqlCommand("SELECT * from information_schema.schemata", connection);
                var reader = cmd.ExecuteReader();
                DataBaseComboBox.Items.Clear();
                while (reader.Read())
                {
                    DataBaseComboBox.Items.Add(reader["SCHEMA_NAME"]);
                }
                DataBaseComboBox.Enabled = true;
            }

        }
        private void DataBaseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(ConnectionString_MySql(DataBaseComboBox.SelectedItem.ToString())))
            {
                connection.Open();
                var query = new StringBuilder("Select * from information_schema.tables where TABLE_SCHEMA = '" + DataBaseComboBox.SelectedItem + "'");
                var cmd = new MySqlCommand(query.ToString(), connection);
                var reader = cmd.ExecuteReader();
                TablesCheckedList.Items.Clear();
                while (reader.Read())
                {
                    var schema = reader["TABLE_SCHEMA"];
                    var table = reader["TABLE_NAME"];
                    TablesCheckedList.Items.Add(schema + "." + table);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() != DialogResult.OK) return;
            foreach (var item in TablesCheckedList.CheckedItems)
            {
                var text = item.ToString();
                var schema = text.Split('.')[0];
                var table = text.Split('.')[1];
                var columns = GetTableVolumns(schema, table);
                GenerateEntities(folderBrowser.SelectedPath,schema,table,columns);
                GenerateRepositoryInterface(folderBrowser.SelectedPath, schema, table, columns);
                GenerateRepositories(folderBrowser.SelectedPath, schema, table, columns);
            }
        }
        private void GenerateRepositories(string generatorPath, string schema, string table, List<ColumnModel> columns)
        {
            var entitiesFolder = Path.Combine(generatorPath, "Repositories");
            if (!Directory.Exists(entitiesFolder))
                Directory.CreateDirectory(entitiesFolder);
            var classLines = new List<string>();
            classLines.Add("using System;");
            classLines.Add("using System.Collections.Generic;");
            classLines.Add("using MySql.Data.MySqlClient;");
            classLines.Add("using " + RootNamespace.Text.Trim() + ".Entities;");
            classLines.Add("using " + RootNamespace.Text.Trim() + ".DataLayer;"); 
            classLines.Add("using " + RootNamespace.Text.Trim() + ".RepositoryAbstracts;"); 
            classLines.Add("namespace " + RootNamespace.Text.Trim() + ".Repositories");
            classLines.Add("{");
            classLines.Add("\tpublic class " + table + "Repository : GenericRepository<" + GetSingularName(table) + ">,I"+table+"Repository");
            classLines.Add("\t{");
            classLines.Add("\t\tpublic "+table+ "Repository():base(\"name=mySQL\"){}");
            foreach (var column in columns)
            {
                var dataType = ConvertSQLDataTypeToCLR(column.DataType, column.IsNullable);
                classLines.Add("\t\tpublic List<"+GetSingularName(table)+"> GetBy"+column.Name+"("+dataType+" value)");
                classLines.Add("\t\t{");
                if (dataType =="string")
                {
                    classLines.Add("\t\t\treturn RunQuery(\"SELECT * FROM "+schema+"."+table+" WHERE "+column.Name+" LIKE @Value\",new MySqlParameter(\"Value\",value));");
                }
                else
                {
                    classLines.Add("\t\t\treturn RunQuery(\"SELECT * FROM " + schema + "." + table + " WHERE " + column.Name + " = @Value\",new MySqlParameter(\"Value\",value));");
                }
                classLines.Add("\t\t}");
            }
            classLines.Add("\t}");
            classLines.Add("}");

            File.WriteAllLines(Path.Combine(entitiesFolder, GetSingularName(table) + ".cs"), classLines);
        }
        private void GenerateRepositoryInterface(string generatorPath, string schema, string table, List<ColumnModel> columns)
        {
            var entitiesFolder = Path.Combine(generatorPath, "RepositoryAbstracts");
            if (!Directory.Exists(entitiesFolder))
                Directory.CreateDirectory(entitiesFolder);
            var classLines = new List<string>();
            classLines.Add("using System;");
            classLines.Add("using System.Collections.Generic;");
            classLines.Add("using "+ RootNamespace.Text.Trim() + ".Entities;");
            classLines.Add("using " + RootNamespace.Text.Trim() + ".DataLayer;");
            classLines.Add("namespace " + RootNamespace.Text.Trim() + ".RepositoryAbstracts");
            classLines.Add("{");
            classLines.Add("\tpublic interface I" + table + "Repository : IRepository<" + GetSingularName(table) + ">");
            classLines.Add("\t{");
            foreach (var column in columns)
            {
                classLines.Add("\t\tList<" + RootNamespace.Text.Trim() + ".Entities." + GetSingularName(table)+"> GetBy"+column.Name+"("+ConvertSQLDataTypeToCLR(column.DataType,column.IsNullable)+" value);");
            }
            classLines.Add("\t}");
            classLines.Add("}");

            File.WriteAllLines(Path.Combine(entitiesFolder, GetSingularName(table) + ".cs"), classLines);
        }
        private void GenerateEntities(string generatorPath,string schema, string table, List<ColumnModel> columns)
        {
            var entitiesFolder = Path.Combine(generatorPath, "Entities");
            if (!Directory.Exists(entitiesFolder))
                Directory.CreateDirectory(entitiesFolder);
            var classLines = new List<string>();
            classLines.Add("using System;"); 
            classLines.Add("using System.ComponentModel;"); 
            classLines.Add("using " + RootNamespace.Text.Trim() + ".DataLayer;");
            classLines.Add("namespace " + RootNamespace.Text.Trim() + ".Entities");
            classLines.Add("{");
            classLines.Add($"\t[Table(\"{schema}\",\"{table}\")]");
            classLines.Add("\tpublic class " + GetSingularName(table));
            classLines.Add("\t{");
            foreach (var column in columns)
            {
                if (column.IsPrimaryKey) classLines.Add("\t\t[PrimeryKey]");
                if (column.IsComputed) classLines.Add("\t\t[ComputedColumn]");
                if (column.IsIdentity) classLines.Add("\t\t[Identity]");
                if (column.Display != null) classLines.Add($"\t\t[DisplayName(\"{column.Display?? "بدون عنوان"}\")]");
                classLines.Add("\t\t public " + ConvertSQLDataTypeToCLR(column.DataType, column.IsNullable) + "\t" + column.Name + "\t{get;set;}");
            }
            classLines.Add("\t}");
            classLines.Add("}");

            File.WriteAllLines(Path.Combine(entitiesFolder, GetSingularName(table) + ".cs"), classLines);
        }
        private string GetSingularName(string name)
        {
            if (name.EndsWith("ies"))
                return name.Substring(0, name.Length - 3) + "y";
            return name;//.Substring(0, name.Length - 1);
        }
        private string ConvertSQLDataTypeToCLR(string dataType, bool nullable)
        {
            switch (dataType)
            {
                case "int":
                    return nullable ? "int?" : "int";
                case "tinyint":
                    return nullable ? "byte?" : "byte";
                case "smallint":
                    return nullable ? "short?" : "short";
                case "bigint":
                    return nullable ? "long?" : "long";
                case "char":
                case "varchar":
                case "text":
                case "nvarchar":
                case "nchar":
                    return "string";
                case "datetime":
                case "datetime2":
                case "year":
                case "date":
                    return nullable ? "DateTime?" : "DateTime";
                case "bit":
                    return nullable ? "bool?" : "bool";
                case "binary":
                case "image":
                    return nullable ? "byte[]?" : "byte[]";
                case "decimal":
                    return nullable ? "decimal?" : "decimal";
                case "float":
                    return nullable ? "float?" : "float";
            }

            return "object";
        }
        private List<ColumnModel> GetTableVolumns(string schema, string tableName)
        {
            var columns = new List<ColumnModel>();

            using (var connection = new MySqlConnection(ConnectionString_MySql(DataBaseComboBox.SelectedItem.ToString())))
            {
                connection.Open();
                var cmd = new MySqlCommand($"SELECT * from information_schema.columns where table_schema = '{schema}' and table_name ='{tableName}'", connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bool iscomputed = reader["EXTRA"].ToString() == "VIRTUAL GENERATED" ||
                                      reader["EXTRA"].ToString() == "STORED GENERATED";
                    var column = new ColumnModel()
                    {
                       Name = reader["COLUMN_NAME"].ToString(),
                        DataType = reader["DATA_TYPE"].ToString(),
                        IsNullable = reader["IS_NULLABLE"].ToString() == "YES",
                        IsPrimaryKey = reader["COLUMN_KEY"].ToString() =="PRI",
                        IsIdentity =  reader["EXTRA"].ToString() == "auto_increment",
                        IsComputed = iscomputed,
                        Display = reader["COLUMN_COMMENT"].ToString(),
                    };
                    columns.Add(column);
                }
            }
            return columns;
        }
        private void SelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectAllCheckBox.Checked)
            {
                for (int i = 0; i < TablesCheckedList.Items.Count; i++)
                {
                    TablesCheckedList.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < TablesCheckedList.Items.Count; i++)
                {
                    TablesCheckedList.SetItemChecked(i, false);
                }
            }
        }
    }
    public class ColumnModel
    {
        public string Name { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsComputed { get; set; }
        public string DataType { get; set; }
        public bool IsNullable { get; set; }
        public string Display { get; set; }
    }
}
