namespace OnboardingTables
{
    partial class AddingNewFolder
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
            this.Submit = new System.Windows.Forms.Button();
            this.NewFolderName = new System.Windows.Forms.TextBox();
            this.FolderNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(97, 100);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 5;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // NewFolderName
            // 
            this.NewFolderName.Location = new System.Drawing.Point(152, 42);
            this.NewFolderName.Name = "NewFolderName";
            this.NewFolderName.Size = new System.Drawing.Size(100, 20);
            this.NewFolderName.TabIndex = 4;
            // 
            // FolderNameLabel
            // 
            this.FolderNameLabel.AutoSize = true;
            this.FolderNameLabel.Location = new System.Drawing.Point(21, 45);
            this.FolderNameLabel.Name = "FolderNameLabel";
            this.FolderNameLabel.Size = new System.Drawing.Size(95, 13);
            this.FolderNameLabel.TabIndex = 3;
            this.FolderNameLabel.Text = "New Folder Name:";
            // 
            // AddingNewFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 164);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.NewFolderName);
            this.Controls.Add(this.FolderNameLabel);
            this.Name = "AddingNewFolder";
            this.Text = "Add New Folder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.TextBox NewFolderName;
        private System.Windows.Forms.Label FolderNameLabel;
    }
}