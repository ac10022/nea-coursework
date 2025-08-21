namespace nea_backend
{
    partial class SchemeOfWorkTracker
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
            this.ClassPicker = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SOWDisplay = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 44);
            this.label1.TabIndex = 12;
            this.label1.Text = "Schemes of work";
            // 
            // ClassPicker
            // 
            this.ClassPicker.FormattingEnabled = true;
            this.ClassPicker.Location = new System.Drawing.Point(430, 44);
            this.ClassPicker.Name = "ClassPicker";
            this.ClassPicker.Size = new System.Drawing.Size(198, 28);
            this.ClassPicker.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Select a class";
            // 
            // SOWDisplay
            // 
            this.SOWDisplay.FormattingEnabled = true;
            this.SOWDisplay.Location = new System.Drawing.Point(21, 96);
            this.SOWDisplay.Name = "SOWDisplay";
            this.SOWDisplay.Size = new System.Drawing.Size(607, 326);
            this.SOWDisplay.TabIndex = 15;
            // 
            // SchemeOfWorkTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 450);
            this.Controls.Add(this.SOWDisplay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ClassPicker);
            this.Controls.Add(this.label1);
            this.Name = "SchemeOfWorkTracker";
            this.Text = "SchemeOfWorkTracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ClassPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox SOWDisplay;
    }
}