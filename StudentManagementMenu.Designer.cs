namespace nea_ui
{
    partial class StudentManagementMenu
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
            this.NameField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ClassPicker = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StudentMatches = new System.Windows.Forms.ListBox();
            this.SearchForStudents = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ClassLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.LastLoginLabel = new System.Windows.Forms.Label();
            this.EditStudentButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.DeleteStudentButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(393, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "Student Manager";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(24, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search for a student";
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(24, 153);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(228, 26);
            this.NameField.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name";
            // 
            // ClassPicker
            // 
            this.ClassPicker.FormattingEnabled = true;
            this.ClassPicker.Location = new System.Drawing.Point(269, 153);
            this.ClassPicker.Name = "ClassPicker";
            this.ClassPicker.Size = new System.Drawing.Size(148, 28);
            this.ClassPicker.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Class";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Matches";
            // 
            // StudentMatches
            // 
            this.StudentMatches.FormattingEnabled = true;
            this.StudentMatches.ItemHeight = 20;
            this.StudentMatches.Location = new System.Drawing.Point(24, 261);
            this.StudentMatches.Name = "StudentMatches";
            this.StudentMatches.Size = new System.Drawing.Size(393, 124);
            this.StudentMatches.TabIndex = 9;
            this.StudentMatches.SelectedIndexChanged += new System.EventHandler(this.UpdateStudentInformation);
            // 
            // SearchForStudents
            // 
            this.SearchForStudents.Location = new System.Drawing.Point(24, 194);
            this.SearchForStudents.Name = "SearchForStudents";
            this.SearchForStudents.Size = new System.Drawing.Size(393, 33);
            this.SearchForStudents.TabIndex = 10;
            this.SearchForStudents.Text = "Search";
            this.SearchForStudents.UseVisualStyleBackColor = true;
            this.SearchForStudents.Click += new System.EventHandler(this.SearchForStudents_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightBlue;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FloralWhite;
            this.label6.Location = new System.Drawing.Point(452, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 34);
            this.label6.TabIndex = 11;
            this.label6.Text = "Student information";
            // 
            // ClassLabel
            // 
            this.ClassLabel.AutoSize = true;
            this.ClassLabel.Location = new System.Drawing.Point(448, 230);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(315, 20);
            this.ClassLabel.TabIndex = 13;
            this.ClassLabel.Text = "Classes: [CLASS1], [CLASS2], [CLASS3] ...";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(448, 199);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(113, 20);
            this.NameLabel.TabIndex = 12;
            this.NameLabel.Text = "Name: [NAME]";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(448, 259);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(113, 20);
            this.EmailLabel.TabIndex = 14;
            this.EmailLabel.Text = "Email: [EMAIL]";
            // 
            // LastLoginLabel
            // 
            this.LastLoginLabel.AutoSize = true;
            this.LastLoginLabel.Location = new System.Drawing.Point(448, 290);
            this.LastLoginLabel.Name = "LastLoginLabel";
            this.LastLoginLabel.Size = new System.Drawing.Size(232, 20);
            this.LastLoginLabel.TabIndex = 16;
            this.LastLoginLabel.Text = "Last Login: [LASTLOGINDATE]";
            // 
            // EditStudentButton
            // 
            this.EditStudentButton.Location = new System.Drawing.Point(452, 355);
            this.EditStudentButton.Name = "EditStudentButton";
            this.EditStudentButton.Size = new System.Drawing.Size(181, 43);
            this.EditStudentButton.TabIndex = 17;
            this.EditStudentButton.Text = "Edit student";
            this.EditStudentButton.UseVisualStyleBackColor = true;
            this.EditStudentButton.Click += new System.EventHandler(this.EditStudentEvent);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(454, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(179, 43);
            this.button3.TabIndex = 18;
            this.button3.Text = "Create a new student";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.GoToCreateStudentMenu);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button4.Location = new System.Drawing.Point(452, 21);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(357, 43);
            this.button4.TabIndex = 19;
            this.button4.Text = "Back to dashboard";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.GoBackToDashboard);
            // 
            // DeleteStudentButton
            // 
            this.DeleteStudentButton.Location = new System.Drawing.Point(639, 355);
            this.DeleteStudentButton.Name = "DeleteStudentButton";
            this.DeleteStudentButton.Size = new System.Drawing.Size(170, 43);
            this.DeleteStudentButton.TabIndex = 20;
            this.DeleteStudentButton.Text = "Delete student";
            this.DeleteStudentButton.UseVisualStyleBackColor = true;
            this.DeleteStudentButton.Click += new System.EventHandler(this.DeleteStudentEvent);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(639, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 43);
            this.button1.TabIndex = 21;
            this.button1.Text = "Import from CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GoToStudentImportMenu);
            // 
            // StudentManagementMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 413);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DeleteStudentButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.EditStudentButton);
            this.Controls.Add(this.LastLoginLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.ClassLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SearchForStudents);
            this.Controls.Add(this.StudentMatches);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ClassPicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StudentManagementMenu";
            this.Text = "StudentManagementMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ClassPicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox StudentMatches;
        private System.Windows.Forms.Button SearchForStudents;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ClassLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label LastLoginLabel;
        private System.Windows.Forms.Button EditStudentButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button DeleteStudentButton;
        private System.Windows.Forms.Button button1;
    }
}