namespace OnboardingTables
{
    partial class TableOnboarding
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
            this.components = new System.ComponentModel.Container();
            this.ProjectPathLabel = new System.Windows.Forms.Label();
            this.ProjectPath = new System.Windows.Forms.TextBox();
            this.SelectProject = new System.Windows.Forms.Button();
            this.SourceNameLabel = new System.Windows.Forms.Label();
            this.SourceName = new System.Windows.Forms.ComboBox();
            this.AddSource = new System.Windows.Forms.Button();
            this.ChefScriptLabel = new System.Windows.Forms.Label();
            this.ScriptName = new System.Windows.Forms.ComboBox();
            this.AddScript = new System.Windows.Forms.Button();
            this.CatalogIDLabel = new System.Windows.Forms.Label();
            this.CatalogID = new System.Windows.Forms.TextBox();
            this.ProcessIDLabel = new System.Windows.Forms.Label();
            this.ProcessID = new System.Windows.Forms.TextBox();
            this.ConnectionStringLabel = new System.Windows.Forms.Label();
            this.ConnectionString = new System.Windows.Forms.TextBox();
            this.SourceTableNameLabel = new System.Windows.Forms.Label();
            this.SourceTableName = new System.Windows.Forms.TextBox();
            this.TargetTableNameLabel = new System.Windows.Forms.Label();
            this.TargetTableName = new System.Windows.Forms.TextBox();
            this.BrowseProjectPath = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SourceSchemaName = new System.Windows.Forms.TextBox();
            this.GetTableDetails = new System.Windows.Forms.Button();
            this.ColumnListLabel = new System.Windows.Forms.Label();
            this.ColumnList = new System.Windows.Forms.CheckedListBox();
            this.PrimaryKeyColumns = new System.Windows.Forms.CheckedListBox();
            this.PrimaryKeyLabel = new System.Windows.Forms.Label();
            this.SelectPrimaryKey = new System.Windows.Forms.Button();
            this.TemporalTableCheck = new System.Windows.Forms.CheckBox();
            this.FiscalYearCheck = new System.Windows.Forms.CheckBox();
            this.Submit = new System.Windows.Forms.Button();
            this.TargetFolderNameLabel = new System.Windows.Forms.Label();
            this.TargetFolderName = new System.Windows.Forms.ComboBox();
            this.AddNewFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProjectPathLabel
            // 
            this.ProjectPathLabel.AutoSize = true;
            this.ProjectPathLabel.Location = new System.Drawing.Point(13, 27);
            this.ProjectPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProjectPathLabel.Name = "ProjectPathLabel";
            this.ProjectPathLabel.Size = new System.Drawing.Size(68, 13);
            this.ProjectPathLabel.TabIndex = 0;
            this.ProjectPathLabel.Text = "Project Path:";
            // 
            // ProjectPath
            // 
            this.ProjectPath.Location = new System.Drawing.Point(132, 27);
            this.ProjectPath.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectPath.Name = "ProjectPath";
            this.ProjectPath.Size = new System.Drawing.Size(390, 20);
            this.ProjectPath.TabIndex = 1;
            // 
            // SelectProject
            // 
            this.SelectProject.Location = new System.Drawing.Point(552, 23);
            this.SelectProject.Margin = new System.Windows.Forms.Padding(2);
            this.SelectProject.Name = "SelectProject";
            this.SelectProject.Size = new System.Drawing.Size(99, 26);
            this.SelectProject.TabIndex = 2;
            this.SelectProject.Text = "Select Project";
            this.SelectProject.UseVisualStyleBackColor = true;
            this.SelectProject.Click += new System.EventHandler(this.SelectProject_Click);
            // 
            // SourceNameLabel
            // 
            this.SourceNameLabel.AutoSize = true;
            this.SourceNameLabel.Location = new System.Drawing.Point(13, 62);
            this.SourceNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SourceNameLabel.Name = "SourceNameLabel";
            this.SourceNameLabel.Size = new System.Drawing.Size(75, 13);
            this.SourceNameLabel.TabIndex = 3;
            this.SourceNameLabel.Text = "Source Name:";
            // 
            // SourceName
            // 
            this.SourceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SourceName.Location = new System.Drawing.Point(132, 62);
            this.SourceName.Margin = new System.Windows.Forms.Padding(2);
            this.SourceName.Name = "SourceName";
            this.SourceName.Size = new System.Drawing.Size(274, 21);
            this.SourceName.TabIndex = 4;
            this.SourceName.SelectedIndexChanged += new System.EventHandler(this.SourceName_SelectedIndexChanged);
            // 
            // AddSource
            // 
            this.AddSource.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AddSource.Location = new System.Drawing.Point(552, 60);
            this.AddSource.Name = "AddSource";
            this.AddSource.Size = new System.Drawing.Size(99, 23);
            this.AddSource.TabIndex = 5;
            this.AddSource.Text = "Add Source";
            this.AddSource.UseVisualStyleBackColor = true;
            this.AddSource.Click += new System.EventHandler(this.AddSource_Click);
            // 
            // ChefScriptLabel
            // 
            this.ChefScriptLabel.AutoSize = true;
            this.ChefScriptLabel.Location = new System.Drawing.Point(13, 96);
            this.ChefScriptLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ChefScriptLabel.Name = "ChefScriptLabel";
            this.ChefScriptLabel.Size = new System.Drawing.Size(62, 13);
            this.ChefScriptLabel.TabIndex = 6;
            this.ChefScriptLabel.Text = "Chef Script:";
            // 
            // ScriptName
            // 
            this.ScriptName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScriptName.Location = new System.Drawing.Point(132, 93);
            this.ScriptName.Margin = new System.Windows.Forms.Padding(2);
            this.ScriptName.Name = "ScriptName";
            this.ScriptName.Size = new System.Drawing.Size(274, 21);
            this.ScriptName.TabIndex = 7;
            // 
            // AddScript
            // 
            this.AddScript.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AddScript.Location = new System.Drawing.Point(552, 91);
            this.AddScript.Name = "AddScript";
            this.AddScript.Size = new System.Drawing.Size(99, 23);
            this.AddScript.TabIndex = 8;
            this.AddScript.Text = "Add Script";
            this.AddScript.UseVisualStyleBackColor = true;
            this.AddScript.Click += new System.EventHandler(this.AddScript_Click);
            // 
            // CatalogIDLabel
            // 
            this.CatalogIDLabel.AutoSize = true;
            this.CatalogIDLabel.Location = new System.Drawing.Point(13, 130);
            this.CatalogIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CatalogIDLabel.Name = "CatalogIDLabel";
            this.CatalogIDLabel.Size = new System.Drawing.Size(60, 13);
            this.CatalogIDLabel.TabIndex = 9;
            this.CatalogIDLabel.Text = "Catalog ID:";
            // 
            // CatalogID
            // 
            this.CatalogID.Location = new System.Drawing.Point(132, 130);
            this.CatalogID.Margin = new System.Windows.Forms.Padding(2);
            this.CatalogID.Name = "CatalogID";
            this.CatalogID.Size = new System.Drawing.Size(158, 20);
            this.CatalogID.TabIndex = 10;
            // 
            // ProcessIDLabel
            // 
            this.ProcessIDLabel.AutoSize = true;
            this.ProcessIDLabel.Location = new System.Drawing.Point(319, 133);
            this.ProcessIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProcessIDLabel.Name = "ProcessIDLabel";
            this.ProcessIDLabel.Size = new System.Drawing.Size(62, 13);
            this.ProcessIDLabel.TabIndex = 11;
            this.ProcessIDLabel.Text = "Process ID:";
            // 
            // ProcessID
            // 
            this.ProcessID.Location = new System.Drawing.Point(431, 127);
            this.ProcessID.Margin = new System.Windows.Forms.Padding(2);
            this.ProcessID.Name = "ProcessID";
            this.ProcessID.Size = new System.Drawing.Size(93, 20);
            this.ProcessID.TabIndex = 12;
            // 
            // ConnectionStringLabel
            // 
            this.ConnectionStringLabel.AutoSize = true;
            this.ConnectionStringLabel.Location = new System.Drawing.Point(13, 162);
            this.ConnectionStringLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ConnectionStringLabel.Name = "ConnectionStringLabel";
            this.ConnectionStringLabel.Size = new System.Drawing.Size(94, 13);
            this.ConnectionStringLabel.TabIndex = 13;
            this.ConnectionStringLabel.Text = "Connection String:";
            // 
            // ConnectionString
            // 
            this.ConnectionString.Location = new System.Drawing.Point(132, 162);
            this.ConnectionString.Margin = new System.Windows.Forms.Padding(2);
            this.ConnectionString.Name = "ConnectionString";
            this.ConnectionString.ReadOnly = true;
            this.ConnectionString.Size = new System.Drawing.Size(392, 20);
            this.ConnectionString.TabIndex = 14;
            // 
            // SourceTableNameLabel
            // 
            this.SourceTableNameLabel.AutoSize = true;
            this.SourceTableNameLabel.Location = new System.Drawing.Point(13, 194);
            this.SourceTableNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SourceTableNameLabel.Name = "SourceTableNameLabel";
            this.SourceTableNameLabel.Size = new System.Drawing.Size(105, 13);
            this.SourceTableNameLabel.TabIndex = 15;
            this.SourceTableNameLabel.Text = "Source Table Name:";
            // 
            // SourceTableName
            // 
            this.SourceTableName.Location = new System.Drawing.Point(187, 191);
            this.SourceTableName.Margin = new System.Windows.Forms.Padding(2);
            this.SourceTableName.Name = "SourceTableName";
            this.SourceTableName.Size = new System.Drawing.Size(103, 20);
            this.SourceTableName.TabIndex = 17;
            // 
            // TargetTableNameLabel
            // 
            this.TargetTableNameLabel.AutoSize = true;
            this.TargetTableNameLabel.Location = new System.Drawing.Point(319, 194);
            this.TargetTableNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TargetTableNameLabel.Name = "TargetTableNameLabel";
            this.TargetTableNameLabel.Size = new System.Drawing.Size(102, 13);
            this.TargetTableNameLabel.TabIndex = 18;
            this.TargetTableNameLabel.Text = "Target Table Name:";
            // 
            // TargetTableName
            // 
            this.TargetTableName.Location = new System.Drawing.Point(431, 191);
            this.TargetTableName.Margin = new System.Windows.Forms.Padding(2);
            this.TargetTableName.Name = "TargetTableName";
            this.TargetTableName.Size = new System.Drawing.Size(93, 20);
            this.TargetTableName.TabIndex = 19;
            // 
            // BrowseProjectPath
            // 
            this.BrowseProjectPath.FileName = "Project Path";
            // 
            // toolTip1
            // 
            this.toolTip1.ForeColor = System.Drawing.Color.DarkTurquoise;
            // 
            // SourceSchemaName
            // 
            this.SourceSchemaName.Location = new System.Drawing.Point(132, 191);
            this.SourceSchemaName.Margin = new System.Windows.Forms.Padding(2);
            this.SourceSchemaName.Name = "SourceSchemaName";
            this.SourceSchemaName.Size = new System.Drawing.Size(51, 20);
            this.SourceSchemaName.TabIndex = 16;
            this.SourceSchemaName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GetTableDetails
            // 
            this.GetTableDetails.Location = new System.Drawing.Point(552, 187);
            this.GetTableDetails.Margin = new System.Windows.Forms.Padding(2);
            this.GetTableDetails.Name = "GetTableDetails";
            this.GetTableDetails.Size = new System.Drawing.Size(99, 26);
            this.GetTableDetails.TabIndex = 20;
            this.GetTableDetails.Text = "Get Table Details";
            this.GetTableDetails.UseVisualStyleBackColor = true;
            this.GetTableDetails.Click += new System.EventHandler(this.GetTableDetails_Click);
            // 
            // ColumnListLabel
            // 
            this.ColumnListLabel.AutoSize = true;
            this.ColumnListLabel.Location = new System.Drawing.Point(13, 252);
            this.ColumnListLabel.Name = "ColumnListLabel";
            this.ColumnListLabel.Size = new System.Drawing.Size(50, 13);
            this.ColumnListLabel.TabIndex = 24;
            this.ColumnListLabel.Text = "Columns:";
            // 
            // ColumnList
            // 
            this.ColumnList.FormattingEnabled = true;
            this.ColumnList.Location = new System.Drawing.Point(132, 252);
            this.ColumnList.Name = "ColumnList";
            this.ColumnList.Size = new System.Drawing.Size(158, 154);
            this.ColumnList.TabIndex = 25;
            // 
            // PrimaryKeyColumns
            // 
            this.PrimaryKeyColumns.FormattingEnabled = true;
            this.PrimaryKeyColumns.Location = new System.Drawing.Point(431, 252);
            this.PrimaryKeyColumns.Name = "PrimaryKeyColumns";
            this.PrimaryKeyColumns.Size = new System.Drawing.Size(158, 154);
            this.PrimaryKeyColumns.TabIndex = 28;
            // 
            // PrimaryKeyLabel
            // 
            this.PrimaryKeyLabel.AutoSize = true;
            this.PrimaryKeyLabel.Location = new System.Drawing.Point(319, 252);
            this.PrimaryKeyLabel.Name = "PrimaryKeyLabel";
            this.PrimaryKeyLabel.Size = new System.Drawing.Size(65, 13);
            this.PrimaryKeyLabel.TabIndex = 26;
            this.PrimaryKeyLabel.Text = "Primary Key:";
            // 
            // SelectPrimaryKey
            // 
            this.SelectPrimaryKey.Location = new System.Drawing.Point(318, 287);
            this.SelectPrimaryKey.Margin = new System.Windows.Forms.Padding(2);
            this.SelectPrimaryKey.Name = "SelectPrimaryKey";
            this.SelectPrimaryKey.Size = new System.Drawing.Size(88, 26);
            this.SelectPrimaryKey.TabIndex = 27;
            this.SelectPrimaryKey.Text = "Select PK -->";
            this.SelectPrimaryKey.UseVisualStyleBackColor = true;
            this.SelectPrimaryKey.Click += new System.EventHandler(this.SelectPrimaryKey_Click);
            // 
            // TemporalTableCheck
            // 
            this.TemporalTableCheck.AutoSize = true;
            this.TemporalTableCheck.Checked = true;
            this.TemporalTableCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TemporalTableCheck.Location = new System.Drawing.Point(315, 366);
            this.TemporalTableCheck.Name = "TemporalTableCheck";
            this.TemporalTableCheck.Size = new System.Drawing.Size(100, 17);
            this.TemporalTableCheck.TabIndex = 30;
            this.TemporalTableCheck.Text = "Temporal Table";
            this.TemporalTableCheck.UseVisualStyleBackColor = true;
            // 
            // FiscalYearCheck
            // 
            this.FiscalYearCheck.AutoSize = true;
            this.FiscalYearCheck.Checked = true;
            this.FiscalYearCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FiscalYearCheck.Location = new System.Drawing.Point(315, 333);
            this.FiscalYearCheck.Name = "FiscalYearCheck";
            this.FiscalYearCheck.Size = new System.Drawing.Size(78, 17);
            this.FiscalYearCheck.TabIndex = 29;
            this.FiscalYearCheck.Text = "Fiscal Year";
            this.FiscalYearCheck.UseVisualStyleBackColor = true;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(318, 419);
            this.Submit.Margin = new System.Windows.Forms.Padding(2);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(88, 26);
            this.Submit.TabIndex = 31;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // TargetFolderNameLabel
            // 
            this.TargetFolderNameLabel.AutoSize = true;
            this.TargetFolderNameLabel.Location = new System.Drawing.Point(13, 224);
            this.TargetFolderNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TargetFolderNameLabel.Name = "TargetFolderNameLabel";
            this.TargetFolderNameLabel.Size = new System.Drawing.Size(104, 13);
            this.TargetFolderNameLabel.TabIndex = 21;
            this.TargetFolderNameLabel.Text = "Target Folder Name:";
            // 
            // TargetFolderName
            // 
            this.TargetFolderName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TargetFolderName.Location = new System.Drawing.Point(132, 221);
            this.TargetFolderName.Margin = new System.Windows.Forms.Padding(2);
            this.TargetFolderName.Name = "TargetFolderName";
            this.TargetFolderName.Size = new System.Drawing.Size(158, 21);
            this.TargetFolderName.TabIndex = 22;
            // 
            // AddNewFolder
            // 
            this.AddNewFolder.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AddNewFolder.Location = new System.Drawing.Point(552, 219);
            this.AddNewFolder.Name = "AddNewFolder";
            this.AddNewFolder.Size = new System.Drawing.Size(99, 23);
            this.AddNewFolder.TabIndex = 23;
            this.AddNewFolder.Text = "Add New Folder";
            this.AddNewFolder.UseVisualStyleBackColor = true;
            this.AddNewFolder.Click += new System.EventHandler(this.AddNewFolder_Click);
            // 
            // TableOnboarding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 473);
            this.Controls.Add(this.AddNewFolder);
            this.Controls.Add(this.TargetFolderName);
            this.Controls.Add(this.TargetFolderNameLabel);
            this.Controls.Add(this.ProjectPathLabel);
            this.Controls.Add(this.ProjectPath);
            this.Controls.Add(this.SelectProject);
            this.Controls.Add(this.SourceNameLabel);
            this.Controls.Add(this.SourceName);
            this.Controls.Add(this.AddSource);
            this.Controls.Add(this.ChefScriptLabel);
            this.Controls.Add(this.ScriptName);
            this.Controls.Add(this.AddScript);
            this.Controls.Add(this.ProcessIDLabel);
            this.Controls.Add(this.CatalogID);
            this.Controls.Add(this.CatalogIDLabel);
            this.Controls.Add(this.ProcessID);
            this.Controls.Add(this.FiscalYearCheck);
            this.Controls.Add(this.TemporalTableCheck);
            this.Controls.Add(this.SelectPrimaryKey);
            this.Controls.Add(this.PrimaryKeyColumns);
            this.Controls.Add(this.PrimaryKeyLabel);
            this.Controls.Add(this.ColumnList);
            this.Controls.Add(this.ColumnListLabel);
            this.Controls.Add(this.GetTableDetails);
            this.Controls.Add(this.SourceTableName);
            this.Controls.Add(this.ConnectionStringLabel);
            this.Controls.Add(this.ConnectionString);
            this.Controls.Add(this.SourceTableNameLabel);
            this.Controls.Add(this.SourceSchemaName);
            this.Controls.Add(this.TargetTableNameLabel);
            this.Controls.Add(this.TargetTableName);
            this.Controls.Add(this.Submit);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TableOnboarding";
            this.Text = "Table Onboarding";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProjectPathLabel;
        private System.Windows.Forms.TextBox ProjectPath;
        private System.Windows.Forms.Button SelectProject;
        private System.Windows.Forms.Label SourceNameLabel;
        public System.Windows.Forms.ComboBox SourceName;
        private System.Windows.Forms.Button AddSource;
        private System.Windows.Forms.Label ChefScriptLabel;
        public System.Windows.Forms.ComboBox ScriptName;
        private System.Windows.Forms.Button AddScript;
        private System.Windows.Forms.Label CatalogIDLabel;
        public System.Windows.Forms.TextBox CatalogID;
        private System.Windows.Forms.Label ProcessIDLabel;
        private System.Windows.Forms.TextBox ProcessID;
        private System.Windows.Forms.Label ConnectionStringLabel;
        private System.Windows.Forms.TextBox ConnectionString;
        private System.Windows.Forms.Label SourceTableNameLabel;
        private System.Windows.Forms.TextBox SourceSchemaName;
        private System.Windows.Forms.TextBox SourceTableName;
        private System.Windows.Forms.Label TargetTableNameLabel;
        private System.Windows.Forms.TextBox TargetTableName;
        private System.Windows.Forms.Button GetTableDetails;
        private System.Windows.Forms.Label ColumnListLabel;
        private System.Windows.Forms.CheckedListBox ColumnList;
        private System.Windows.Forms.Label PrimaryKeyLabel;
        private System.Windows.Forms.CheckedListBox PrimaryKeyColumns;
        private System.Windows.Forms.Button SelectPrimaryKey;
        private System.Windows.Forms.CheckBox FiscalYearCheck;
        private System.Windows.Forms.CheckBox TemporalTableCheck;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.OpenFileDialog BrowseProjectPath;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label TargetFolderNameLabel;
        private System.Windows.Forms.ComboBox TargetFolderName;
        private System.Windows.Forms.Button AddNewFolder;
    }
}

