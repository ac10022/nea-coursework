namespace nea_backend
{
    partial class PasswordResetMenu
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
            this.label2 = new System.Windows.Forms.Label();
            this.EmailField = new System.Windows.Forms.TextBox();
            this.ResetPasswordButton = new System.Windows.Forms.Button();
            this.SendConfirmButton = new System.Windows.Forms.Button();
            this.BackToDashboard = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CodeField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NewPasswordField = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.SuccessMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 44);
            this.label1.TabIndex = 3;
            this.label1.Text = "Reset Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Email";
            // 
            // EmailField
            // 
            this.EmailField.Enabled = false;
            this.EmailField.Location = new System.Drawing.Point(23, 108);
            this.EmailField.Name = "EmailField";
            this.EmailField.Size = new System.Drawing.Size(188, 26);
            this.EmailField.TabIndex = 4;
            // 
            // ResetPasswordButton
            // 
            this.ResetPasswordButton.BackColor = System.Drawing.Color.LightCoral;
            this.ResetPasswordButton.Location = new System.Drawing.Point(244, 100);
            this.ResetPasswordButton.Name = "ResetPasswordButton";
            this.ResetPasswordButton.Size = new System.Drawing.Size(186, 43);
            this.ResetPasswordButton.TabIndex = 11;
            this.ResetPasswordButton.Text = "This isn\'t me";
            this.ResetPasswordButton.UseVisualStyleBackColor = false;
            this.ResetPasswordButton.Click += new System.EventHandler(this.GoBack);
            // 
            // SendConfirmButton
            // 
            this.SendConfirmButton.Location = new System.Drawing.Point(23, 164);
            this.SendConfirmButton.Name = "SendConfirmButton";
            this.SendConfirmButton.Size = new System.Drawing.Size(407, 37);
            this.SendConfirmButton.TabIndex = 12;
            this.SendConfirmButton.Text = "Send confirmation email";
            this.SendConfirmButton.UseVisualStyleBackColor = true;
            this.SendConfirmButton.Click += new System.EventHandler(this.SendConfirmationEvent);
            // 
            // BackToDashboard
            // 
            this.BackToDashboard.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackToDashboard.Location = new System.Drawing.Point(412, 29);
            this.BackToDashboard.Name = "BackToDashboard";
            this.BackToDashboard.Size = new System.Drawing.Size(122, 43);
            this.BackToDashboard.TabIndex = 63;
            this.BackToDashboard.Text = "Return";
            this.BackToDashboard.UseVisualStyleBackColor = false;
            this.BackToDashboard.Click += new System.EventHandler(this.GoBack);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "Email Code";
            // 
            // CodeField
            // 
            this.CodeField.Enabled = false;
            this.CodeField.Location = new System.Drawing.Point(23, 242);
            this.CodeField.Name = "CodeField";
            this.CodeField.Size = new System.Drawing.Size(407, 26);
            this.CodeField.TabIndex = 64;
            this.CodeField.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 67;
            this.label4.Text = "New Password";
            // 
            // NewPasswordField
            // 
            this.NewPasswordField.Enabled = false;
            this.NewPasswordField.Location = new System.Drawing.Point(23, 309);
            this.NewPasswordField.Name = "NewPasswordField";
            this.NewPasswordField.Size = new System.Drawing.Size(407, 26);
            this.NewPasswordField.TabIndex = 66;
            this.NewPasswordField.TextChanged += new System.EventHandler(this.FieldChanged);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Enabled = false;
            this.SubmitButton.Location = new System.Drawing.Point(23, 361);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(407, 37);
            this.SubmitButton.TabIndex = 68;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitEvent);
            // 
            // SuccessMessage
            // 
            this.SuccessMessage.AutoSize = true;
            this.SuccessMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SuccessMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SuccessMessage.Location = new System.Drawing.Point(23, 409);
            this.SuccessMessage.Name = "SuccessMessage";
            this.SuccessMessage.Size = new System.Drawing.Size(187, 22);
            this.SuccessMessage.TabIndex = 69;
            this.SuccessMessage.Text = "Success: changes saved";
            this.SuccessMessage.Visible = false;
            // 
            // PasswordResetMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 446);
            this.Controls.Add(this.SuccessMessage);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NewPasswordField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CodeField);
            this.Controls.Add(this.BackToDashboard);
            this.Controls.Add(this.SendConfirmButton);
            this.Controls.Add(this.ResetPasswordButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EmailField);
            this.Controls.Add(this.label1);
            this.Name = "PasswordResetMenu";
            this.Text = "PasswordResetMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EmailField;
        private System.Windows.Forms.Button ResetPasswordButton;
        private System.Windows.Forms.Button SendConfirmButton;
        private System.Windows.Forms.Button BackToDashboard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CodeField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NewPasswordField;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label SuccessMessage;
    }
}