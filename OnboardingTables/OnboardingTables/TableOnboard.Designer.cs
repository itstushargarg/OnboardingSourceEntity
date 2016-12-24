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
            this.Submit = new System.Windows.Forms.Button();
            this.TableName = new System.Windows.Forms.TextBox();
            this.TargetTableNameLabel = new System.Windows.Forms.Label();
            this.SelectProject = new System.Windows.Forms.Button();
            this.BrowseProjectPath = new System.Windows.Forms.OpenFileDialog();
            this.ProjectPath = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ProjectPathLabel = new System.Windows.Forms.Label();
            this.SourceNameLabel = new System.Windows.Forms.Label();
            this.SourceName = new System.Windows.Forms.ComboBox();
            this.AddSource = new System.Windows.Forms.Button();
            this.SourceTableNameLabel = new System.Windows.Forms.Label();
            this.SourceSchemaName = new System.Windows.Forms.TextBox();
            this.ServerNameLabel = new System.Windows.Forms.Label();
            this.ServerName = new System.Windows.Forms.TextBox();
            this.DatabaseNameLabel = new System.Windows.Forms.Label();
            this.DatabaseName = new System.Windows.Forms.TextBox();
            this.SourceTableName = new System.Windows.Forms.TextBox();
            this.GetTableDetails = new System.Windows.Forms.Button();
            this.AddScript = new System.Windows.Forms.Button();
            this.ChefScriptLabel = new System.Windows.Forms.Label();
            this.ProcessIDLabel = new System.Windows.Forms.Label();
            this.CatalogID = new System.Windows.Forms.TextBox();
            this.CatalogIDLabel = new System.Windows.Forms.Label();
            this.ProcessID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ColumnList = new System.Windows.Forms.CheckedListBox();
            this.PrimaryKeyColumns = new System.Windows.Forms.CheckedListBox();
            this.PrimaryKeyLabel = new System.Windows.Forms.Label();
            this.SelectPrimaryKey = new System.Windows.Forms.Button();
            this.ScriptName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(318, 389);
            this.Submit.Margin = new System.Windows.Forms.Padding(2);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(88, 26);
            this.Submit.TabIndex = 1;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // TableName
            // 
            this.TableName.Location = new System.Drawing.Point(431, 155);
            this.TableName.Margin = new System.Windows.Forms.Padding(2);
            this.TableName.Name = "TableName";
            this.TableName.Size = new System.Drawing.Size(93, 20);
            this.TableName.TabIndex = 2;
            this.TableName.Text = "AA_Area";
            // 
            // TargetTableNameLabel
            // 
            this.TargetTableNameLabel.AutoSize = true;
            this.TargetTableNameLabel.Location = new System.Drawing.Point(319, 158);
            this.TargetTableNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TargetTableNameLabel.Name = "TargetTableNameLabel";
            this.TargetTableNameLabel.Size = new System.Drawing.Size(102, 13);
            this.TargetTableNameLabel.TabIndex = 4;
            this.TargetTableNameLabel.Text = "Target Table Name:";
            // 
            // SelectProject
            // 
            this.SelectProject.Location = new System.Drawing.Point(552, 23);
            this.SelectProject.Margin = new System.Windows.Forms.Padding(2);
            this.SelectProject.Name = "SelectProject";
            this.SelectProject.Size = new System.Drawing.Size(99, 26);
            this.SelectProject.TabIndex = 7;
            this.SelectProject.Text = "Select Project";
            this.SelectProject.UseVisualStyleBackColor = true;
            this.SelectProject.Click += new System.EventHandler(this.SelectProject_Click);
            // 
            // BrowseProjectPath
            // 
            this.BrowseProjectPath.FileName = "Project Path";
            // 
            // ProjectPath
            // 
            this.ProjectPath.Location = new System.Drawing.Point(132, 27);
            this.ProjectPath.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectPath.Name = "ProjectPath";
            this.ProjectPath.Size = new System.Drawing.Size(390, 20);
            this.ProjectPath.TabIndex = 8;
            // 
            // toolTip1
            // 
            this.toolTip1.ForeColor = System.Drawing.Color.DarkTurquoise;
            // 
            // ProjectPathLabel
            // 
            this.ProjectPathLabel.AutoSize = true;
            this.ProjectPathLabel.Location = new System.Drawing.Point(13, 27);
            this.ProjectPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProjectPathLabel.Name = "ProjectPathLabel";
            this.ProjectPathLabel.Size = new System.Drawing.Size(68, 13);
            this.ProjectPathLabel.TabIndex = 9;
            this.ProjectPathLabel.Text = "Project Path:";
            // 
            // SourceNameLabel
            // 
            this.SourceNameLabel.AutoSize = true;
            this.SourceNameLabel.Location = new System.Drawing.Point(13, 62);
            this.SourceNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SourceNameLabel.Name = "SourceNameLabel";
            this.SourceNameLabel.Size = new System.Drawing.Size(75, 13);
            this.SourceNameLabel.TabIndex = 12;
            this.SourceNameLabel.Text = "Source Name:";
            // 
            // SourceName
            // 
            this.SourceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SourceName.Location = new System.Drawing.Point(132, 62);
            this.SourceName.Margin = new System.Windows.Forms.Padding(2);
            this.SourceName.Name = "SourceName";
            this.SourceName.Size = new System.Drawing.Size(92, 21);
            this.SourceName.TabIndex = 13;
            // 
            // AddSource
            // 
            this.AddSource.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AddSource.Location = new System.Drawing.Point(431, 62);
            this.AddSource.Name = "AddSource";
            this.AddSource.Size = new System.Drawing.Size(75, 23);
            this.AddSource.TabIndex = 14;
            this.AddSource.Text = "Add Source";
            this.AddSource.UseVisualStyleBackColor = true;
            this.AddSource.Click += new System.EventHandler(this.AddSource_Click);
            // 
            // SourceTableNameLabel
            // 
            this.SourceTableNameLabel.AutoSize = true;
            this.SourceTableNameLabel.Location = new System.Drawing.Point(13, 158);
            this.SourceTableNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SourceTableNameLabel.Name = "SourceTableNameLabel";
            this.SourceTableNameLabel.Size = new System.Drawing.Size(105, 13);
            this.SourceTableNameLabel.TabIndex = 16;
            this.SourceTableNameLabel.Text = "Source Table Name:";
            // 
            // SourceSchemaName
            // 
            this.SourceSchemaName.Location = new System.Drawing.Point(132, 155);
            this.SourceSchemaName.Margin = new System.Windows.Forms.Padding(2);
            this.SourceSchemaName.Name = "SourceSchemaName";
            this.SourceSchemaName.Size = new System.Drawing.Size(51, 20);
            this.SourceSchemaName.TabIndex = 15;
            this.SourceSchemaName.Text = "dbo";
            this.SourceSchemaName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ServerNameLabel
            // 
            this.ServerNameLabel.AutoSize = true;
            this.ServerNameLabel.Location = new System.Drawing.Point(13, 128);
            this.ServerNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ServerNameLabel.Name = "ServerNameLabel";
            this.ServerNameLabel.Size = new System.Drawing.Size(72, 13);
            this.ServerNameLabel.TabIndex = 20;
            this.ServerNameLabel.Text = "Server Name:";
            // 
            // ServerName
            // 
            this.ServerName.Location = new System.Drawing.Point(132, 128);
            this.ServerName.Margin = new System.Windows.Forms.Padding(2);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(158, 20);
            this.ServerName.TabIndex = 19;
            this.ServerName.Text = "SKYKOMISH";
            // 
            // DatabaseNameLabel
            // 
            this.DatabaseNameLabel.AutoSize = true;
            this.DatabaseNameLabel.Location = new System.Drawing.Point(319, 128);
            this.DatabaseNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DatabaseNameLabel.Name = "DatabaseNameLabel";
            this.DatabaseNameLabel.Size = new System.Drawing.Size(87, 13);
            this.DatabaseNameLabel.TabIndex = 18;
            this.DatabaseNameLabel.Text = "Database Name:";
            // 
            // DatabaseName
            // 
            this.DatabaseName.Location = new System.Drawing.Point(431, 125);
            this.DatabaseName.Margin = new System.Windows.Forms.Padding(2);
            this.DatabaseName.Name = "DatabaseName";
            this.DatabaseName.Size = new System.Drawing.Size(93, 20);
            this.DatabaseName.TabIndex = 17;
            this.DatabaseName.Text = "MSSales";
            // 
            // SourceTableName
            // 
            this.SourceTableName.Location = new System.Drawing.Point(187, 155);
            this.SourceTableName.Margin = new System.Windows.Forms.Padding(2);
            this.SourceTableName.Name = "SourceTableName";
            this.SourceTableName.Size = new System.Drawing.Size(103, 20);
            this.SourceTableName.TabIndex = 21;
            this.SourceTableName.Text = "Area";
            // 
            // GetTableDetails
            // 
            this.GetTableDetails.Location = new System.Drawing.Point(552, 151);
            this.GetTableDetails.Margin = new System.Windows.Forms.Padding(2);
            this.GetTableDetails.Name = "GetTableDetails";
            this.GetTableDetails.Size = new System.Drawing.Size(99, 26);
            this.GetTableDetails.TabIndex = 22;
            this.GetTableDetails.Text = "Get Table Details";
            this.GetTableDetails.UseVisualStyleBackColor = true;
            this.GetTableDetails.Click += new System.EventHandler(this.GetTableDetails_Click);
            // 
            // AddScript
            // 
            this.AddScript.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AddScript.Location = new System.Drawing.Point(431, 94);
            this.AddScript.Name = "AddScript";
            this.AddScript.Size = new System.Drawing.Size(75, 23);
            this.AddScript.TabIndex = 25;
            this.AddScript.Text = "Add Script";
            this.AddScript.UseVisualStyleBackColor = true;
            this.AddScript.Click += new System.EventHandler(this.AddScript_Click);
            // 
            // ChefScriptLabel
            // 
            this.ChefScriptLabel.AutoSize = true;
            this.ChefScriptLabel.Location = new System.Drawing.Point(13, 96);
            this.ChefScriptLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ChefScriptLabel.Name = "ChefScriptLabel";
            this.ChefScriptLabel.Size = new System.Drawing.Size(62, 13);
            this.ChefScriptLabel.TabIndex = 23;
            this.ChefScriptLabel.Text = "Chef Script:";
            // 
            // ProcessIDLabel
            // 
            this.ProcessIDLabel.AutoSize = true;
            this.ProcessIDLabel.Location = new System.Drawing.Point(319, 189);
            this.ProcessIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProcessIDLabel.Name = "ProcessIDLabel";
            this.ProcessIDLabel.Size = new System.Drawing.Size(62, 13);
            this.ProcessIDLabel.TabIndex = 29;
            this.ProcessIDLabel.Text = "Process ID:";
            // 
            // CatalogID
            // 
            this.CatalogID.Location = new System.Drawing.Point(132, 189);
            this.CatalogID.Margin = new System.Windows.Forms.Padding(2);
            this.CatalogID.Name = "CatalogID";
            this.CatalogID.Size = new System.Drawing.Size(158, 20);
            this.CatalogID.TabIndex = 28;
            // 
            // CatalogIDLabel
            // 
            this.CatalogIDLabel.AutoSize = true;
            this.CatalogIDLabel.Location = new System.Drawing.Point(13, 189);
            this.CatalogIDLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CatalogIDLabel.Name = "CatalogIDLabel";
            this.CatalogIDLabel.Size = new System.Drawing.Size(60, 13);
            this.CatalogIDLabel.TabIndex = 27;
            this.CatalogIDLabel.Text = "Catalog ID:";
            // 
            // ProcessID
            // 
            this.ProcessID.Location = new System.Drawing.Point(431, 186);
            this.ProcessID.Margin = new System.Windows.Forms.Padding(2);
            this.ProcessID.Name = "ProcessID";
            this.ProcessID.Size = new System.Drawing.Size(93, 20);
            this.ProcessID.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Columns:";
            // 
            // ColumnList
            // 
            this.ColumnList.FormattingEnabled = true;
            this.ColumnList.Location = new System.Drawing.Point(132, 223);
            this.ColumnList.Name = "ColumnList";
            this.ColumnList.Size = new System.Drawing.Size(158, 154);
            this.ColumnList.TabIndex = 31;
            // 
            // PrimaryKeyColumns
            // 
            this.PrimaryKeyColumns.FormattingEnabled = true;
            this.PrimaryKeyColumns.Location = new System.Drawing.Point(431, 223);
            this.PrimaryKeyColumns.Name = "PrimaryKeyColumns";
            this.PrimaryKeyColumns.Size = new System.Drawing.Size(158, 154);
            this.PrimaryKeyColumns.TabIndex = 33;
            // 
            // PrimaryKeyLabel
            // 
            this.PrimaryKeyLabel.AutoSize = true;
            this.PrimaryKeyLabel.Location = new System.Drawing.Point(319, 223);
            this.PrimaryKeyLabel.Name = "PrimaryKeyLabel";
            this.PrimaryKeyLabel.Size = new System.Drawing.Size(65, 13);
            this.PrimaryKeyLabel.TabIndex = 32;
            this.PrimaryKeyLabel.Text = "Primary Key:";
            // 
            // SelectPrimaryKey
            // 
            this.SelectPrimaryKey.Location = new System.Drawing.Point(318, 288);
            this.SelectPrimaryKey.Margin = new System.Windows.Forms.Padding(2);
            this.SelectPrimaryKey.Name = "SelectPrimaryKey";
            this.SelectPrimaryKey.Size = new System.Drawing.Size(88, 26);
            this.SelectPrimaryKey.TabIndex = 34;
            this.SelectPrimaryKey.Text = "Select PK";
            this.SelectPrimaryKey.UseVisualStyleBackColor = true;
            this.SelectPrimaryKey.Click += new System.EventHandler(this.SelectPrimaryKey_Click);
            // 
            // ScriptName
            // 
            this.ScriptName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScriptName.Location = new System.Drawing.Point(132, 93);
            this.ScriptName.Margin = new System.Windows.Forms.Padding(2);
            this.ScriptName.Name = "ScriptName";
            this.ScriptName.Size = new System.Drawing.Size(274, 21);
            this.ScriptName.TabIndex = 35;
            // 
            // TableOnboarding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 473);
            this.Controls.Add(this.ScriptName);
            this.Controls.Add(this.SelectPrimaryKey);
            this.Controls.Add(this.PrimaryKeyColumns);
            this.Controls.Add(this.PrimaryKeyLabel);
            this.Controls.Add(this.ColumnList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProcessIDLabel);
            this.Controls.Add(this.CatalogID);
            this.Controls.Add(this.CatalogIDLabel);
            this.Controls.Add(this.ProcessID);
            this.Controls.Add(this.AddScript);
            this.Controls.Add(this.ChefScriptLabel);
            this.Controls.Add(this.GetTableDetails);
            this.Controls.Add(this.SourceTableName);
            this.Controls.Add(this.ServerNameLabel);
            this.Controls.Add(this.ServerName);
            this.Controls.Add(this.DatabaseNameLabel);
            this.Controls.Add(this.DatabaseName);
            this.Controls.Add(this.SourceTableNameLabel);
            this.Controls.Add(this.SourceSchemaName);
            this.Controls.Add(this.AddSource);
            this.Controls.Add(this.SourceName);
            this.Controls.Add(this.SourceNameLabel);
            this.Controls.Add(this.ProjectPathLabel);
            this.Controls.Add(this.ProjectPath);
            this.Controls.Add(this.SelectProject);
            this.Controls.Add(this.TargetTableNameLabel);
            this.Controls.Add(this.TableName);
            this.Controls.Add(this.Submit);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TableOnboarding";
            this.Text = " Table Onboarding";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.TextBox TableName;
        private System.Windows.Forms.Label TargetTableNameLabel;
        private System.Windows.Forms.Button SelectProject;
        private System.Windows.Forms.OpenFileDialog BrowseProjectPath;
        private System.Windows.Forms.TextBox ProjectPath;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label ProjectPathLabel;
        private System.Windows.Forms.Label SourceNameLabel;
        private System.Windows.Forms.ComboBox SourceName;
        private System.Windows.Forms.Button AddSource;
        private System.Windows.Forms.Label SourceTableNameLabel;
        private System.Windows.Forms.TextBox SourceSchemaName;
        private System.Windows.Forms.Label ServerNameLabel;
        private System.Windows.Forms.TextBox ServerName;
        private System.Windows.Forms.Label DatabaseNameLabel;
        private System.Windows.Forms.TextBox DatabaseName;
        private System.Windows.Forms.TextBox SourceTableName;
        private System.Windows.Forms.Button GetTableDetails;
        private System.Windows.Forms.Button AddScript;
        private System.Windows.Forms.Label ChefScriptLabel;
        private System.Windows.Forms.Label ProcessIDLabel;
        private System.Windows.Forms.Label CatalogIDLabel;
        private System.Windows.Forms.TextBox ProcessID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox ColumnList;
        private System.Windows.Forms.CheckedListBox PrimaryKeyColumns;
        private System.Windows.Forms.Label PrimaryKeyLabel;
        private System.Windows.Forms.Button SelectPrimaryKey;
        public System.Windows.Forms.TextBox CatalogID;
        public System.Windows.Forms.ComboBox ScriptName;
    }
}

