namespace OnboardingTables
{
    partial class StartingPage
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
            this.OnboardingBaseTables = new System.Windows.Forms.Button();
            this.AddingFactTablesandViews = new System.Windows.Forms.Button();
            this.AddingDimensionTablesandViews = new System.Windows.Forms.Button();
            this.AddingDimensionSP = new System.Windows.Forms.Button();
            this.AddingFactSP = new System.Windows.Forms.Button();
            this.ProjectPathLabel = new System.Windows.Forms.Label();
            this.ProjectPath = new System.Windows.Forms.TextBox();
            this.SelectProject = new System.Windows.Forms.Button();
            this.SelectProjectButton = new System.Windows.Forms.Button();
            this.BrowseProjectPath = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // OnboardingBaseTables
            // 
            this.OnboardingBaseTables.Location = new System.Drawing.Point(82, 144);
            this.OnboardingBaseTables.Name = "OnboardingBaseTables";
            this.OnboardingBaseTables.Size = new System.Drawing.Size(189, 23);
            this.OnboardingBaseTables.TabIndex = 0;
            this.OnboardingBaseTables.Text = "Onboarding Base Tables";
            this.OnboardingBaseTables.UseVisualStyleBackColor = true;
            this.OnboardingBaseTables.Click += new System.EventHandler(this.OnboardingBaseTables_Click);
            // 
            // AddingFactTablesandViews
            // 
            this.AddingFactTablesandViews.Location = new System.Drawing.Point(82, 182);
            this.AddingFactTablesandViews.Name = "AddingFactTablesandViews";
            this.AddingFactTablesandViews.Size = new System.Drawing.Size(189, 23);
            this.AddingFactTablesandViews.TabIndex = 1;
            this.AddingFactTablesandViews.Text = "Adding Fact Tables and Views";
            this.AddingFactTablesandViews.UseVisualStyleBackColor = true;
            this.AddingFactTablesandViews.Click += new System.EventHandler(this.AddingFactTablesandViews_Click);
            // 
            // AddingDimensionTablesandViews
            // 
            this.AddingDimensionTablesandViews.Location = new System.Drawing.Point(82, 222);
            this.AddingDimensionTablesandViews.Name = "AddingDimensionTablesandViews";
            this.AddingDimensionTablesandViews.Size = new System.Drawing.Size(189, 23);
            this.AddingDimensionTablesandViews.TabIndex = 2;
            this.AddingDimensionTablesandViews.Text = "Adding Dimension Tables and Views";
            this.AddingDimensionTablesandViews.UseVisualStyleBackColor = true;
            this.AddingDimensionTablesandViews.Click += new System.EventHandler(this.AddingDimensionTablesandViews_Click);
            // 
            // AddingDimensionSP
            // 
            this.AddingDimensionSP.Location = new System.Drawing.Point(82, 263);
            this.AddingDimensionSP.Name = "AddingDimensionSP";
            this.AddingDimensionSP.Size = new System.Drawing.Size(189, 23);
            this.AddingDimensionSP.TabIndex = 3;
            this.AddingDimensionSP.Text = "Adding Dimension SP(s)";
            this.AddingDimensionSP.UseVisualStyleBackColor = true;
            // 
            // AddingFactSP
            // 
            this.AddingFactSP.Location = new System.Drawing.Point(82, 301);
            this.AddingFactSP.Name = "AddingFactSP";
            this.AddingFactSP.Size = new System.Drawing.Size(189, 23);
            this.AddingFactSP.TabIndex = 4;
            this.AddingFactSP.Text = "Adding Fact SP(s)";
            this.AddingFactSP.UseVisualStyleBackColor = true;
            // 
            // ProjectPathLabel
            // 
            this.ProjectPathLabel.AutoSize = true;
            this.ProjectPathLabel.Location = new System.Drawing.Point(9, 20);
            this.ProjectPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProjectPathLabel.Name = "ProjectPathLabel";
            this.ProjectPathLabel.Size = new System.Drawing.Size(68, 13);
            this.ProjectPathLabel.TabIndex = 5;
            this.ProjectPathLabel.Text = "Project Path:";
            // 
            // ProjectPath
            // 
            this.ProjectPath.Location = new System.Drawing.Point(12, 53);
            this.ProjectPath.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectPath.Name = "ProjectPath";
            this.ProjectPath.ReadOnly = true;
            this.ProjectPath.Size = new System.Drawing.Size(335, 20);
            this.ProjectPath.TabIndex = 6;
            // 
            // SelectProject
            // 
            this.SelectProject.Location = new System.Drawing.Point(432, 49);
            this.SelectProject.Margin = new System.Windows.Forms.Padding(2);
            this.SelectProject.Name = "SelectProject";
            this.SelectProject.Size = new System.Drawing.Size(99, 26);
            this.SelectProject.TabIndex = 7;
            this.SelectProject.Text = "Select Project";
            this.SelectProject.UseVisualStyleBackColor = true;
            // 
            // SelectProjectButton
            // 
            this.SelectProjectButton.Location = new System.Drawing.Point(248, 13);
            this.SelectProjectButton.Margin = new System.Windows.Forms.Padding(2);
            this.SelectProjectButton.Name = "SelectProjectButton";
            this.SelectProjectButton.Size = new System.Drawing.Size(99, 26);
            this.SelectProjectButton.TabIndex = 8;
            this.SelectProjectButton.Text = "Select Project";
            this.SelectProjectButton.UseVisualStyleBackColor = true;
            this.SelectProjectButton.Click += new System.EventHandler(this.SelectProjectButton_Click);
            // 
            // BrowseProjectPath
            // 
            this.BrowseProjectPath.FileName = "Project Path";
            // 
            // StartingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 364);
            this.Controls.Add(this.SelectProjectButton);
            this.Controls.Add(this.ProjectPathLabel);
            this.Controls.Add(this.ProjectPath);
            this.Controls.Add(this.SelectProject);
            this.Controls.Add(this.AddingFactSP);
            this.Controls.Add(this.AddingDimensionSP);
            this.Controls.Add(this.AddingDimensionTablesandViews);
            this.Controls.Add(this.AddingFactTablesandViews);
            this.Controls.Add(this.OnboardingBaseTables);
            this.Name = "StartingPage";
            this.Text = "StartingPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OnboardingBaseTables;
        private System.Windows.Forms.Button AddingFactTablesandViews;
        private System.Windows.Forms.Button AddingDimensionTablesandViews;
        private System.Windows.Forms.Button AddingDimensionSP;
        private System.Windows.Forms.Button AddingFactSP;
        private System.Windows.Forms.Label ProjectPathLabel;
        private System.Windows.Forms.TextBox ProjectPath;
        private System.Windows.Forms.Button SelectProject;
        private System.Windows.Forms.Button SelectProjectButton;
        private System.Windows.Forms.OpenFileDialog BrowseProjectPath;
    }
}