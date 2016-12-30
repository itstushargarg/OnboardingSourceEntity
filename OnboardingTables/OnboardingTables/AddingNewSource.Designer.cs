namespace OnboardingTables
{
    partial class AddingNewSource
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
            this.NewSourceName = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.ConnectionString = new System.Windows.Forms.TextBox();
            this.ConnectionStringLabel = new System.Windows.Forms.Label();
            this.FrequencyNumber = new System.Windows.Forms.TextBox();
            this.FrequencyNumberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SourceName:";
            // 
            // NewSourceName
            // 
            this.NewSourceName.Location = new System.Drawing.Point(136, 37);
            this.NewSourceName.Name = "NewSourceName";
            this.NewSourceName.Size = new System.Drawing.Size(100, 20);
            this.NewSourceName.TabIndex = 1;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(33, 199);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 2;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // ConnectionString
            // 
            this.ConnectionString.Location = new System.Drawing.Point(136, 84);
            this.ConnectionString.Name = "ConnectionString";
            this.ConnectionString.Size = new System.Drawing.Size(641, 20);
            this.ConnectionString.TabIndex = 4;
            // 
            // ConnectionStringLabel
            // 
            this.ConnectionStringLabel.AutoSize = true;
            this.ConnectionStringLabel.Location = new System.Drawing.Point(30, 87);
            this.ConnectionStringLabel.Name = "ConnectionStringLabel";
            this.ConnectionStringLabel.Size = new System.Drawing.Size(91, 13);
            this.ConnectionStringLabel.TabIndex = 3;
            this.ConnectionStringLabel.Text = "ConnectionString:";
            // 
            // FrequencyNumber
            // 
            this.FrequencyNumber.Location = new System.Drawing.Point(136, 131);
            this.FrequencyNumber.Name = "FrequencyNumber";
            this.FrequencyNumber.Size = new System.Drawing.Size(100, 20);
            this.FrequencyNumber.TabIndex = 6;
            // 
            // FrequencyNumberLabel
            // 
            this.FrequencyNumberLabel.AutoSize = true;
            this.FrequencyNumberLabel.Location = new System.Drawing.Point(30, 134);
            this.FrequencyNumberLabel.Name = "FrequencyNumberLabel";
            this.FrequencyNumberLabel.Size = new System.Drawing.Size(97, 13);
            this.FrequencyNumberLabel.TabIndex = 5;
            this.FrequencyNumberLabel.Text = "FrequencyNumber:";
            // 
            // AddingNewSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 251);
            this.Controls.Add(this.FrequencyNumber);
            this.Controls.Add(this.FrequencyNumberLabel);
            this.Controls.Add(this.ConnectionString);
            this.Controls.Add(this.ConnectionStringLabel);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.NewSourceName);
            this.Controls.Add(this.label1);
            this.Name = "AddingNewSource";
            this.Text = "AddingNewSource";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewSourceName;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.TextBox ConnectionString;
        private System.Windows.Forms.Label ConnectionStringLabel;
        private System.Windows.Forms.TextBox FrequencyNumber;
        private System.Windows.Forms.Label FrequencyNumberLabel;
    }
}