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
            this.SuspendLayout();
            // 
            // OnboardingBaseTables
            // 
            this.OnboardingBaseTables.Location = new System.Drawing.Point(49, 37);
            this.OnboardingBaseTables.Name = "OnboardingBaseTables";
            this.OnboardingBaseTables.Size = new System.Drawing.Size(189, 23);
            this.OnboardingBaseTables.TabIndex = 0;
            this.OnboardingBaseTables.Text = "Onboarding Base Tables";
            this.OnboardingBaseTables.UseVisualStyleBackColor = true;
            this.OnboardingBaseTables.Click += new System.EventHandler(this.OnboardingBaseTables_Click);
            // 
            // AddingFactTablesandViews
            // 
            this.AddingFactTablesandViews.Location = new System.Drawing.Point(49, 75);
            this.AddingFactTablesandViews.Name = "AddingFactTablesandViews";
            this.AddingFactTablesandViews.Size = new System.Drawing.Size(189, 23);
            this.AddingFactTablesandViews.TabIndex = 1;
            this.AddingFactTablesandViews.Text = "Adding Fact Tables and Views";
            this.AddingFactTablesandViews.UseVisualStyleBackColor = true;
            // 
            // AddingDimensionTablesandViews
            // 
            this.AddingDimensionTablesandViews.Location = new System.Drawing.Point(49, 115);
            this.AddingDimensionTablesandViews.Name = "AddingDimensionTablesandViews";
            this.AddingDimensionTablesandViews.Size = new System.Drawing.Size(189, 23);
            this.AddingDimensionTablesandViews.TabIndex = 2;
            this.AddingDimensionTablesandViews.Text = "Adding Dimension Tables and Views";
            this.AddingDimensionTablesandViews.UseVisualStyleBackColor = true;
            // 
            // AddingDimensionSP
            // 
            this.AddingDimensionSP.Location = new System.Drawing.Point(49, 156);
            this.AddingDimensionSP.Name = "AddingDimensionSP";
            this.AddingDimensionSP.Size = new System.Drawing.Size(189, 23);
            this.AddingDimensionSP.TabIndex = 3;
            this.AddingDimensionSP.Text = "Adding Dimension SP(s)";
            this.AddingDimensionSP.UseVisualStyleBackColor = true;
            // 
            // AddingFactSP
            // 
            this.AddingFactSP.Location = new System.Drawing.Point(49, 194);
            this.AddingFactSP.Name = "AddingFactSP";
            this.AddingFactSP.Size = new System.Drawing.Size(189, 23);
            this.AddingFactSP.TabIndex = 4;
            this.AddingFactSP.Text = "Adding Fact SP(s)";
            this.AddingFactSP.UseVisualStyleBackColor = true;
            // 
            // StartingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.AddingFactSP);
            this.Controls.Add(this.AddingDimensionSP);
            this.Controls.Add(this.AddingDimensionTablesandViews);
            this.Controls.Add(this.AddingFactTablesandViews);
            this.Controls.Add(this.OnboardingBaseTables);
            this.Name = "StartingPage";
            this.Text = "StartingPage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OnboardingBaseTables;
        private System.Windows.Forms.Button AddingFactTablesandViews;
        private System.Windows.Forms.Button AddingDimensionTablesandViews;
        private System.Windows.Forms.Button AddingDimensionSP;
        private System.Windows.Forms.Button AddingFactSP;
    }
}