namespace OnboardingTables
{
    partial class AddingNewChefScript
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
            this.ChefScriptName = new System.Windows.Forms.TextBox();
            this.ChefScriptSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ScriptName:";
            // 
            // ChefScriptName
            // 
            this.ChefScriptName.Location = new System.Drawing.Point(122, 40);
            this.ChefScriptName.Name = "ChefScriptName";
            this.ChefScriptName.Size = new System.Drawing.Size(121, 20);
            this.ChefScriptName.TabIndex = 1;
            // 
            // ChefScriptSubmit
            // 
            this.ChefScriptSubmit.Location = new System.Drawing.Point(79, 89);
            this.ChefScriptSubmit.Name = "ChefScriptSubmit";
            this.ChefScriptSubmit.Size = new System.Drawing.Size(101, 23);
            this.ChefScriptSubmit.TabIndex = 2;
            this.ChefScriptSubmit.Text = "Submit";
            this.ChefScriptSubmit.UseVisualStyleBackColor = true;
            this.ChefScriptSubmit.Click += new System.EventHandler(this.ChefScriptSubmit_Click);
            // 
            // AddingNewChefScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 143);
            this.Controls.Add(this.ChefScriptSubmit);
            this.Controls.Add(this.ChefScriptName);
            this.Controls.Add(this.label1);
            this.Name = "AddingNewChefScript";
            this.Text = "AddingNewChefScript";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ChefScriptName;
        private System.Windows.Forms.Button ChefScriptSubmit;
    }
}