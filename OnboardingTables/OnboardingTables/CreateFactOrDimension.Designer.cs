namespace OnboardingTables
{
    partial class CreateFactOrDimension
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
            this.TableNameLabel = new System.Windows.Forms.Label();
            this.NewTableName = new System.Windows.Forms.TextBox();
            this.SearchTableLabel = new System.Windows.Forms.Label();
            this.SearchTable = new System.Windows.Forms.TextBox();
            this.TablesList = new System.Windows.Forms.CheckedListBox();
            this.TablesLabel = new System.Windows.Forms.Label();
            this.ColumnsLabel = new System.Windows.Forms.Label();
            this.ColumnsList = new System.Windows.Forms.CheckedListBox();
            this.GetColumns = new System.Windows.Forms.Button();
            this.AddColumns = new System.Windows.Forms.Button();
            this.SelectedColumnsLabel = new System.Windows.Forms.Label();
            this.SelectAsPKColumns = new System.Windows.Forms.Button();
            this.DeleteSelectedColumns = new System.Windows.Forms.Button();
            this.SelectedPKColumnsList = new System.Windows.Forms.CheckedListBox();
            this.PKColumnsLabel = new System.Windows.Forms.Label();
            this.SelectedColumnsList = new System.Windows.Forms.CheckedListBox();
            this.DeleteSelectedColumnsFromPK = new System.Windows.Forms.Button();
            this.CreateTable = new System.Windows.Forms.Button();
            this.SelectAllTables = new System.Windows.Forms.CheckBox();
            this.SelectAllColumns = new System.Windows.Forms.CheckBox();
            this.SelectAllSelectedColumns = new System.Windows.Forms.CheckBox();
            this.SelectAllPKColumns = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // TableNameLabel
            // 
            this.TableNameLabel.AutoSize = true;
            this.TableNameLabel.Location = new System.Drawing.Point(50, 38);
            this.TableNameLabel.Name = "TableNameLabel";
            this.TableNameLabel.Size = new System.Drawing.Size(68, 13);
            this.TableNameLabel.TabIndex = 0;
            this.TableNameLabel.Text = "Table Name:";
            // 
            // NewTableName
            // 
            this.NewTableName.Location = new System.Drawing.Point(178, 35);
            this.NewTableName.Name = "NewTableName";
            this.NewTableName.Size = new System.Drawing.Size(160, 20);
            this.NewTableName.TabIndex = 1;
            // 
            // SearchTableLabel
            // 
            this.SearchTableLabel.AutoSize = true;
            this.SearchTableLabel.Location = new System.Drawing.Point(50, 80);
            this.SearchTableLabel.Name = "SearchTableLabel";
            this.SearchTableLabel.Size = new System.Drawing.Size(74, 13);
            this.SearchTableLabel.TabIndex = 2;
            this.SearchTableLabel.Text = "Search Table:";
            // 
            // SearchTable
            // 
            this.SearchTable.Location = new System.Drawing.Point(178, 77);
            this.SearchTable.Name = "SearchTable";
            this.SearchTable.Size = new System.Drawing.Size(160, 20);
            this.SearchTable.TabIndex = 3;
            // 
            // TablesList
            // 
            this.TablesList.CheckOnClick = true;
            this.TablesList.FormattingEnabled = true;
            this.TablesList.HorizontalScrollbar = true;
            this.TablesList.Location = new System.Drawing.Point(178, 126);
            this.TablesList.Name = "TablesList";
            this.TablesList.Size = new System.Drawing.Size(160, 154);
            this.TablesList.TabIndex = 4;
            // 
            // TablesLabel
            // 
            this.TablesLabel.AutoSize = true;
            this.TablesLabel.Location = new System.Drawing.Point(50, 126);
            this.TablesLabel.Name = "TablesLabel";
            this.TablesLabel.Size = new System.Drawing.Size(42, 13);
            this.TablesLabel.TabIndex = 5;
            this.TablesLabel.Text = "Tables:";
            // 
            // ColumnsLabel
            // 
            this.ColumnsLabel.AutoSize = true;
            this.ColumnsLabel.Location = new System.Drawing.Point(383, 126);
            this.ColumnsLabel.Name = "ColumnsLabel";
            this.ColumnsLabel.Size = new System.Drawing.Size(50, 13);
            this.ColumnsLabel.TabIndex = 6;
            this.ColumnsLabel.Text = "Columns:";
            // 
            // ColumnsList
            // 
            this.ColumnsList.CheckOnClick = true;
            this.ColumnsList.FormattingEnabled = true;
            this.ColumnsList.Location = new System.Drawing.Point(495, 126);
            this.ColumnsList.Name = "ColumnsList";
            this.ColumnsList.Size = new System.Drawing.Size(160, 154);
            this.ColumnsList.TabIndex = 7;
            // 
            // GetColumns
            // 
            this.GetColumns.Location = new System.Drawing.Point(376, 190);
            this.GetColumns.Name = "GetColumns";
            this.GetColumns.Size = new System.Drawing.Size(75, 23);
            this.GetColumns.TabIndex = 8;
            this.GetColumns.Text = "Get Columns";
            this.GetColumns.UseVisualStyleBackColor = true;
            this.GetColumns.Click += new System.EventHandler(this.GetColumns_Click);
            // 
            // AddColumns
            // 
            this.AddColumns.Location = new System.Drawing.Point(376, 228);
            this.AddColumns.Name = "AddColumns";
            this.AddColumns.Size = new System.Drawing.Size(85, 23);
            this.AddColumns.TabIndex = 9;
            this.AddColumns.Text = "Add Columns";
            this.AddColumns.UseVisualStyleBackColor = true;
            this.AddColumns.Click += new System.EventHandler(this.AddColumns_Click);
            // 
            // SelectedColumnsLabel
            // 
            this.SelectedColumnsLabel.AutoSize = true;
            this.SelectedColumnsLabel.Location = new System.Drawing.Point(53, 347);
            this.SelectedColumnsLabel.Name = "SelectedColumnsLabel";
            this.SelectedColumnsLabel.Size = new System.Drawing.Size(95, 13);
            this.SelectedColumnsLabel.TabIndex = 10;
            this.SelectedColumnsLabel.Text = "Selected Columns:";
            // 
            // SelectAsPKColumns
            // 
            this.SelectAsPKColumns.Location = new System.Drawing.Point(344, 449);
            this.SelectAsPKColumns.Name = "SelectAsPKColumns";
            this.SelectAsPKColumns.Size = new System.Drawing.Size(145, 23);
            this.SelectAsPKColumns.TabIndex = 15;
            this.SelectAsPKColumns.Text = "Select As PK Columns";
            this.SelectAsPKColumns.UseVisualStyleBackColor = true;
            this.SelectAsPKColumns.Click += new System.EventHandler(this.SelectAsPKColumns_Click);
            // 
            // DeleteSelectedColumns
            // 
            this.DeleteSelectedColumns.Location = new System.Drawing.Point(344, 397);
            this.DeleteSelectedColumns.Name = "DeleteSelectedColumns";
            this.DeleteSelectedColumns.Size = new System.Drawing.Size(145, 23);
            this.DeleteSelectedColumns.TabIndex = 14;
            this.DeleteSelectedColumns.Text = "Delete Selected Columns";
            this.DeleteSelectedColumns.UseVisualStyleBackColor = true;
            this.DeleteSelectedColumns.Click += new System.EventHandler(this.DeleteSelectedColumns_Click);
            // 
            // SelectedPKColumnsList
            // 
            this.SelectedPKColumnsList.CheckOnClick = true;
            this.SelectedPKColumnsList.FormattingEnabled = true;
            this.SelectedPKColumnsList.Location = new System.Drawing.Point(495, 347);
            this.SelectedPKColumnsList.Name = "SelectedPKColumnsList";
            this.SelectedPKColumnsList.Size = new System.Drawing.Size(160, 154);
            this.SelectedPKColumnsList.TabIndex = 13;
            // 
            // PKColumnsLabel
            // 
            this.PKColumnsLabel.AutoSize = true;
            this.PKColumnsLabel.Location = new System.Drawing.Point(383, 347);
            this.PKColumnsLabel.Name = "PKColumnsLabel";
            this.PKColumnsLabel.Size = new System.Drawing.Size(67, 13);
            this.PKColumnsLabel.TabIndex = 12;
            this.PKColumnsLabel.Text = "PK Columns:";
            // 
            // SelectedColumnsList
            // 
            this.SelectedColumnsList.CheckOnClick = true;
            this.SelectedColumnsList.FormattingEnabled = true;
            this.SelectedColumnsList.Location = new System.Drawing.Point(178, 347);
            this.SelectedColumnsList.Name = "SelectedColumnsList";
            this.SelectedColumnsList.Size = new System.Drawing.Size(160, 154);
            this.SelectedColumnsList.TabIndex = 11;
            // 
            // DeleteSelectedColumnsFromPK
            // 
            this.DeleteSelectedColumnsFromPK.Location = new System.Drawing.Point(661, 397);
            this.DeleteSelectedColumnsFromPK.Name = "DeleteSelectedColumnsFromPK";
            this.DeleteSelectedColumnsFromPK.Size = new System.Drawing.Size(145, 52);
            this.DeleteSelectedColumnsFromPK.TabIndex = 16;
            this.DeleteSelectedColumnsFromPK.Text = "Delete Selected Columns From PK";
            this.DeleteSelectedColumnsFromPK.UseVisualStyleBackColor = true;
            this.DeleteSelectedColumnsFromPK.Click += new System.EventHandler(this.DeleteSelectedColumnsFromPK_Click);
            // 
            // CreateTable
            // 
            this.CreateTable.Location = new System.Drawing.Point(344, 560);
            this.CreateTable.Name = "CreateTable";
            this.CreateTable.Size = new System.Drawing.Size(145, 23);
            this.CreateTable.TabIndex = 17;
            this.CreateTable.Text = "Create Table";
            this.CreateTable.UseVisualStyleBackColor = true;
            // 
            // SelectAllTables
            // 
            this.SelectAllTables.AutoSize = true;
            this.SelectAllTables.Location = new System.Drawing.Point(157, 126);
            this.SelectAllTables.Name = "SelectAllTables";
            this.SelectAllTables.Size = new System.Drawing.Size(15, 14);
            this.SelectAllTables.TabIndex = 18;
            this.SelectAllTables.UseVisualStyleBackColor = true;
            this.SelectAllTables.CheckedChanged += new System.EventHandler(this.SelectAllTables_CheckedChanged);
            // 
            // SelectAllColumns
            // 
            this.SelectAllColumns.AutoSize = true;
            this.SelectAllColumns.Checked = true;
            this.SelectAllColumns.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelectAllColumns.Location = new System.Drawing.Point(474, 126);
            this.SelectAllColumns.Name = "SelectAllColumns";
            this.SelectAllColumns.Size = new System.Drawing.Size(15, 14);
            this.SelectAllColumns.TabIndex = 19;
            this.SelectAllColumns.UseVisualStyleBackColor = true;
            this.SelectAllColumns.CheckedChanged += new System.EventHandler(this.SelectAllColumns_CheckedChanged);
            // 
            // SelectAllSelectedColumns
            // 
            this.SelectAllSelectedColumns.AutoSize = true;
            this.SelectAllSelectedColumns.Location = new System.Drawing.Point(157, 347);
            this.SelectAllSelectedColumns.Name = "SelectAllSelectedColumns";
            this.SelectAllSelectedColumns.Size = new System.Drawing.Size(15, 14);
            this.SelectAllSelectedColumns.TabIndex = 20;
            this.SelectAllSelectedColumns.UseVisualStyleBackColor = true;
            this.SelectAllSelectedColumns.CheckedChanged += new System.EventHandler(this.SelectAllSelectedColumns_CheckedChanged);
            // 
            // SelectAllPKColumns
            // 
            this.SelectAllPKColumns.AutoSize = true;
            this.SelectAllPKColumns.Location = new System.Drawing.Point(474, 347);
            this.SelectAllPKColumns.Name = "SelectAllPKColumns";
            this.SelectAllPKColumns.Size = new System.Drawing.Size(15, 14);
            this.SelectAllPKColumns.TabIndex = 21;
            this.SelectAllPKColumns.UseVisualStyleBackColor = true;
            this.SelectAllPKColumns.CheckedChanged += new System.EventHandler(this.SelectAllPKColumns_CheckedChanged);
            // 
            // CreateFactOrDimension
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 613);
            this.Controls.Add(this.SelectAllPKColumns);
            this.Controls.Add(this.SelectAllSelectedColumns);
            this.Controls.Add(this.SelectAllColumns);
            this.Controls.Add(this.SelectAllTables);
            this.Controls.Add(this.CreateTable);
            this.Controls.Add(this.DeleteSelectedColumnsFromPK);
            this.Controls.Add(this.SelectAsPKColumns);
            this.Controls.Add(this.DeleteSelectedColumns);
            this.Controls.Add(this.SelectedPKColumnsList);
            this.Controls.Add(this.PKColumnsLabel);
            this.Controls.Add(this.SelectedColumnsList);
            this.Controls.Add(this.SelectedColumnsLabel);
            this.Controls.Add(this.AddColumns);
            this.Controls.Add(this.GetColumns);
            this.Controls.Add(this.ColumnsList);
            this.Controls.Add(this.ColumnsLabel);
            this.Controls.Add(this.TablesLabel);
            this.Controls.Add(this.TablesList);
            this.Controls.Add(this.SearchTable);
            this.Controls.Add(this.SearchTableLabel);
            this.Controls.Add(this.NewTableName);
            this.Controls.Add(this.TableNameLabel);
            this.Name = "CreateFactOrDimension";
            this.Text = "CreateFactOrDimension";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TableNameLabel;
        private System.Windows.Forms.TextBox NewTableName;
        private System.Windows.Forms.Label SearchTableLabel;
        private System.Windows.Forms.TextBox SearchTable;
        private System.Windows.Forms.CheckedListBox TablesList;
        private System.Windows.Forms.Label TablesLabel;
        private System.Windows.Forms.Label ColumnsLabel;
        private System.Windows.Forms.CheckedListBox ColumnsList;
        private System.Windows.Forms.Button GetColumns;
        private System.Windows.Forms.Button AddColumns;
        private System.Windows.Forms.Label SelectedColumnsLabel;
        private System.Windows.Forms.Button SelectAsPKColumns;
        private System.Windows.Forms.Button DeleteSelectedColumns;
        private System.Windows.Forms.CheckedListBox SelectedPKColumnsList;
        private System.Windows.Forms.Label PKColumnsLabel;
        private System.Windows.Forms.CheckedListBox SelectedColumnsList;
        private System.Windows.Forms.Button DeleteSelectedColumnsFromPK;
        private System.Windows.Forms.Button CreateTable;
        private System.Windows.Forms.CheckBox SelectAllTables;
        private System.Windows.Forms.CheckBox SelectAllColumns;
        private System.Windows.Forms.CheckBox SelectAllSelectedColumns;
        private System.Windows.Forms.CheckBox SelectAllPKColumns;
    }
}