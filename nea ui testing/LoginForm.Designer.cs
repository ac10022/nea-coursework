namespace nea_ui_testing
{
    partial class LoginForm
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
            this.EmailField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PasswordField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StudentRadioButton = new System.Windows.Forms.RadioButton();
            this.TeacherRadioButton = new System.Windows.Forms.RadioButton();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoggedOutLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(31, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome!";
            // 
            // EmailField
            // 
            this.EmailField.Location = new System.Drawing.Point(31, 116);
            this.EmailField.Name = "EmailField";
            this.EmailField.Size = new System.Drawing.Size(188, 26);
            this.EmailField.TabIndex = 1;
            this.EmailField.TextChanged += new System.EventHandler(this.CheckForData);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // PasswordField
            // 
            this.PasswordField.Location = new System.Drawing.Point(31, 192);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.Size = new System.Drawing.Size(188, 26);
            this.PasswordField.TabIndex = 3;
            this.PasswordField.TextChanged += new System.EventHandler(this.CheckForData);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Log-in as:";
            // 
            // StudentRadioButton
            // 
            this.StudentRadioButton.AutoSize = true;
            this.StudentRadioButton.Location = new System.Drawing.Point(43, 277);
            this.StudentRadioButton.Name = "StudentRadioButton";
            this.StudentRadioButton.Size = new System.Drawing.Size(103, 24);
            this.StudentRadioButton.TabIndex = 6;
            this.StudentRadioButton.TabStop = true;
            this.StudentRadioButton.Text = "A student";
            this.StudentRadioButton.UseVisualStyleBackColor = true;
            this.StudentRadioButton.CheckedChanged += new System.EventHandler(this.CheckForData);
            // 
            // TeacherRadioButton
            // 
            this.TeacherRadioButton.AutoSize = true;
            this.TeacherRadioButton.Location = new System.Drawing.Point(43, 306);
            this.TeacherRadioButton.Name = "TeacherRadioButton";
            this.TeacherRadioButton.Size = new System.Drawing.Size(103, 24);
            this.TeacherRadioButton.TabIndex = 7;
            this.TeacherRadioButton.TabStop = true;
            this.TeacherRadioButton.Text = "A teacher";
            this.TeacherRadioButton.UseVisualStyleBackColor = true;
            this.TeacherRadioButton.CheckedChanged += new System.EventHandler(this.CheckForData);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(30, 356);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(189, 43);
            this.LoginButton.TabIndex = 8;
            this.LoginButton.Text = "Log-in";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.AttemptLogin);
            // 
            // LoggedOutLabel
            // 
            this.LoggedOutLabel.AutoSize = true;
            this.LoggedOutLabel.BackColor = System.Drawing.Color.LightCoral;
            this.LoggedOutLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoggedOutLabel.Location = new System.Drawing.Point(558, 27);
            this.LoggedOutLabel.Name = "LoggedOutLabel";
            this.LoggedOutLabel.Size = new System.Drawing.Size(201, 22);
            this.LoggedOutLabel.TabIndex = 9;
            this.LoggedOutLabel.Text = "You have been logged out.";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LoggedOutLabel);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.TeacherRadioButton);
            this.Controls.Add(this.StudentRadioButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EmailField);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "Log-in";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EmailField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PasswordField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton StudentRadioButton;
        private System.Windows.Forms.RadioButton TeacherRadioButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Label LoggedOutLabel;
    }
}

