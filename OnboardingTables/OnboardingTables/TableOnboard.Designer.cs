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
            this.label1 = new System.Windows.Forms.Label();
            this.ColumnList = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SelectProject = new System.Windows.Forms.Button();
            this.BrowseProjectPath = new System.Windows.Forms.OpenFileDialog();
            this.ProjectPath = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SourceName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(343, 422);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(117, 32);
            this.Submit.TabIndex = 1;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // TableName
            // 
            this.TableName.Location = new System.Drawing.Point(137, 119);
            this.TableName.Name = "TableName";
            this.TableName.Size = new System.Drawing.Size(518, 22);
            this.TableName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Table Name:";
            // 
            // ColumnList
            // 
            this.ColumnList.Location = new System.Drawing.Point(137, 198);
            this.ColumnList.Name = "ColumnList";
            this.ColumnList.Size = new System.Drawing.Size(518, 207);
            this.ColumnList.TabIndex = 5;
            this.ColumnList.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Columns:";
            // 
            // SelectProject
            // 
            this.SelectProject.Location = new System.Drawing.Point(697, 28);
            this.SelectProject.Name = "SelectProject";
            this.SelectProject.Size = new System.Drawing.Size(132, 32);
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
            this.ProjectPath.Location = new System.Drawing.Point(137, 33);
            this.ProjectPath.Name = "ProjectPath";
            this.ProjectPath.Size = new System.Drawing.Size(518, 22);
            this.ProjectPath.TabIndex = 8;
            // 
            // toolTip1
            // 
            this.toolTip1.ForeColor = System.Drawing.Color.DarkTurquoise;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Project Path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Source Name:";
            // 
            // SourceName
            // 
            this.SourceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SourceName.Location = new System.Drawing.Point(137, 76);
            this.SourceName.Name = "SourceName";
            this.SourceName.Size = new System.Drawing.Size(121, 24);
            this.SourceName.TabIndex = 13;
            // 
            // TableOnboarding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 582);
            this.Controls.Add(this.SourceName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProjectPath);
            this.Controls.Add(this.SelectProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ColumnList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TableName);
            this.Controls.Add(this.Submit);
            this.Name = "TableOnboarding";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.TextBox TableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox ColumnList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SelectProject;
        private System.Windows.Forms.OpenFileDialog BrowseProjectPath;
        private System.Windows.Forms.TextBox ProjectPath;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SourceName;
    }
}

