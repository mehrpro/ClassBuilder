namespace ClassBuilder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DataSourceTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataBaseComboBox = new System.Windows.Forms.ComboBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.SelectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.UserIDCheckBox = new System.Windows.Forms.CheckBox();
            this.DataBaseLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UserIDTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RootNamespace = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TablesCheckedList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "DataSource";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(571, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // DataSourceTextBox
            // 
            this.DataSourceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSourceTextBox.Location = new System.Drawing.Point(110, 36);
            this.DataSourceTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.DataSourceTextBox.Name = "DataSourceTextBox";
            this.DataSourceTextBox.Size = new System.Drawing.Size(235, 22);
            this.DataSourceTextBox.TabIndex = 2;
            this.DataSourceTextBox.Text = "localhost";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataBaseComboBox);
            this.groupBox1.Controls.Add(this.ConnectButton);
            this.groupBox1.Controls.Add(this.SelectAllCheckBox);
            this.groupBox1.Controls.Add(this.UserIDCheckBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DataBaseLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.PasswordTextBox);
            this.groupBox1.Controls.Add(this.UserIDTextBox);
            this.groupBox1.Controls.Add(this.DataSourceTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(888, 137);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // DataBaseComboBox
            // 
            this.DataBaseComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataBaseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataBaseComboBox.Enabled = false;
            this.DataBaseComboBox.FormattingEnabled = true;
            this.DataBaseComboBox.Location = new System.Drawing.Point(110, 71);
            this.DataBaseComboBox.Name = "DataBaseComboBox";
            this.DataBaseComboBox.Size = new System.Drawing.Size(235, 24);
            this.DataBaseComboBox.TabIndex = 5;
            this.DataBaseComboBox.SelectedIndexChanged += new System.EventHandler(this.DataBaseComboBox_SelectedIndexChanged);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectButton.Location = new System.Drawing.Point(784, 31);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(92, 32);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // SelectAllCheckBox
            // 
            this.SelectAllCheckBox.AutoSize = true;
            this.SelectAllCheckBox.Location = new System.Drawing.Point(26, 111);
            this.SelectAllCheckBox.Name = "SelectAllCheckBox";
            this.SelectAllCheckBox.Size = new System.Drawing.Size(83, 20);
            this.SelectAllCheckBox.TabIndex = 3;
            this.SelectAllCheckBox.Text = "Select All";
            this.SelectAllCheckBox.UseVisualStyleBackColor = true;
            this.SelectAllCheckBox.CheckedChanged += new System.EventHandler(this.SelectAllCheckBox_CheckedChanged);
            // 
            // UserIDCheckBox
            // 
            this.UserIDCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserIDCheckBox.AutoSize = true;
            this.UserIDCheckBox.Location = new System.Drawing.Point(352, 38);
            this.UserIDCheckBox.Name = "UserIDCheckBox";
            this.UserIDCheckBox.Size = new System.Drawing.Size(72, 20);
            this.UserIDCheckBox.TabIndex = 3;
            this.UserIDCheckBox.Text = "User ID";
            this.UserIDCheckBox.UseVisualStyleBackColor = true;
            this.UserIDCheckBox.CheckedChanged += new System.EventHandler(this.UserIDCheckBox_CheckedChanged);
            // 
            // DataBaseLabel
            // 
            this.DataBaseLabel.AutoSize = true;
            this.DataBaseLabel.Location = new System.Drawing.Point(23, 74);
            this.DataBaseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DataBaseLabel.Name = "DataBaseLabel";
            this.DataBaseLabel.Size = new System.Drawing.Size(69, 16);
            this.DataBaseLabel.TabIndex = 0;
            this.DataBaseLabel.Text = "DataBase";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.Enabled = false;
            this.PasswordTextBox.Location = new System.Drawing.Point(645, 36);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(132, 22);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.Text = "Ss987654";
            // 
            // UserIDTextBox
            // 
            this.UserIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserIDTextBox.Enabled = false;
            this.UserIDTextBox.Location = new System.Drawing.Point(431, 36);
            this.UserIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.UserIDTextBox.Name = "UserIDTextBox";
            this.UserIDTextBox.Size = new System.Drawing.Size(132, 22);
            this.UserIDTextBox.TabIndex = 2;
            this.UserIDTextBox.Text = "root";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RootNamespace);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 533);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(888, 54);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generator";
            // 
            // RootNamespace
            // 
            this.RootNamespace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RootNamespace.Location = new System.Drawing.Point(145, 21);
            this.RootNamespace.Name = "RootNamespace";
            this.RootNamespace.Size = new System.Drawing.Size(633, 22);
            this.RootNamespace.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(784, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Root Namespace";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TablesCheckedList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(888, 396);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tables";
            // 
            // TablesCheckedList
            // 
            this.TablesCheckedList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablesCheckedList.FormattingEnabled = true;
            this.TablesCheckedList.Location = new System.Drawing.Point(3, 18);
            this.TablesCheckedList.Name = "TablesCheckedList";
            this.TablesCheckedList.Size = new System.Drawing.Size(882, 375);
            this.TablesCheckedList.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 587);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "ClassBuilder 1.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DataSourceTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.CheckBox UserIDCheckBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UserIDTextBox;
        private System.Windows.Forms.ComboBox DataBaseComboBox;
        private System.Windows.Forms.Label DataBaseLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox TablesCheckedList;
        private System.Windows.Forms.TextBox RootNamespace;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox SelectAllCheckBox;
    }
}

