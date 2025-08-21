namespace nea_ui
{
    partial class StudentAssignmentMenu
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
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowCompletedButton = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button4.Location = new System.Drawing.Point(590, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(198, 43);
            this.button4.TabIndex = 42;
            this.button4.Text = "Back to dashboard";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.GoBackToDashboard);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 44);
            this.label1.TabIndex = 39;
            this.label1.Text = "Assignments";
            // 
            // ShowCompletedButton
            // 
            this.ShowCompletedButton.AutoSize = true;
            this.ShowCompletedButton.Location = new System.Drawing.Point(337, 46);
            this.ShowCompletedButton.Name = "ShowCompletedButton";
            this.ShowCompletedButton.Size = new System.Drawing.Size(247, 24);
            this.ShowCompletedButton.TabIndex = 44;
            this.ShowCompletedButton.Text = "Show completed assignments";
            this.ShowCompletedButton.UseVisualStyleBackColor = true;
            // 
            // StudentAssignmentMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 601);
            this.Controls.Add(this.ShowCompletedButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Name = "StudentAssignmentMenu";
            this.Text = "StudentAssignmentMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ShowCompletedButton;
    }
}