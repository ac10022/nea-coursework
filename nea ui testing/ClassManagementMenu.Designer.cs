namespace nea_ui_testing
{
    partial class ClassManagementMenu
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
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClassnameLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SearchForClassButton = new System.Windows.Forms.Button();
            this.ClassListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ClassNameFilter = new System.Windows.Forms.TextBox();
            this.StudentsInClass = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TeachersInClass = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.DeleteAssignmentButton = new System.Windows.Forms.Button();
            this.AssignmentsListBox = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.EditClassnameButton = new System.Windows.Forms.Button();
            this.SuccessMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button4.Location = new System.Drawing.Point(850, 76);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(357, 43);
            this.button4.TabIndex = 23;
            this.button4.Text = "Back to dashboard";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.ReturnToDashboard);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(850, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(357, 43);
            this.button3.TabIndex = 22;
            this.button3.Text = "Create a new class";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.GoToClassCreatorMenu);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(23, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 34);
            this.label2.TabIndex = 21;
            this.label2.Text = "Search for a class";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 44);
            this.label1.TabIndex = 20;
            this.label1.Text = "Class Manager";
            // 
            // ClassnameLabel
            // 
            this.ClassnameLabel.AutoSize = true;
            this.ClassnameLabel.Location = new System.Drawing.Point(447, 207);
            this.ClassnameLabel.Name = "ClassnameLabel";
            this.ClassnameLabel.Size = new System.Drawing.Size(113, 20);
            this.ClassnameLabel.TabIndex = 30;
            this.ClassnameLabel.Text = "Name: [NAME]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightBlue;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FloralWhite;
            this.label6.Location = new System.Drawing.Point(451, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(315, 34);
            this.label6.TabIndex = 29;
            this.label6.Text = "Class information";
            // 
            // SearchForClassButton
            // 
            this.SearchForClassButton.Location = new System.Drawing.Point(23, 202);
            this.SearchForClassButton.Name = "SearchForClassButton";
            this.SearchForClassButton.Size = new System.Drawing.Size(393, 33);
            this.SearchForClassButton.TabIndex = 28;
            this.SearchForClassButton.Text = "Search";
            this.SearchForClassButton.UseVisualStyleBackColor = true;
            this.SearchForClassButton.Click += new System.EventHandler(this.SearchForClass);
            // 
            // ClassListBox
            // 
            this.ClassListBox.FormattingEnabled = true;
            this.ClassListBox.ItemHeight = 20;
            this.ClassListBox.Location = new System.Drawing.Point(23, 269);
            this.ClassListBox.Name = "ClassListBox";
            this.ClassListBox.Size = new System.Drawing.Size(393, 324);
            this.ClassListBox.TabIndex = 27;
            this.ClassListBox.SelectedIndexChanged += new System.EventHandler(this.NewClassSelected);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Matches";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Name";
            // 
            // ClassNameFilter
            // 
            this.ClassNameFilter.Location = new System.Drawing.Point(23, 161);
            this.ClassNameFilter.Name = "ClassNameFilter";
            this.ClassNameFilter.Size = new System.Drawing.Size(393, 26);
            this.ClassNameFilter.TabIndex = 24;
            this.ClassNameFilter.TextChanged += new System.EventHandler(this.TestForData);
            // 
            // StudentsInClass
            // 
            this.StudentsInClass.FormattingEnabled = true;
            this.StudentsInClass.ItemHeight = 20;
            this.StudentsInClass.Location = new System.Drawing.Point(451, 269);
            this.StudentsInClass.Name = "StudentsInClass";
            this.StudentsInClass.Size = new System.Drawing.Size(393, 104);
            this.StudentsInClass.TabIndex = 32;
            this.StudentsInClass.SelectedIndexChanged += new System.EventHandler(this.StudentChoiceChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Students";
            // 
            // TeachersInClass
            // 
            this.TeachersInClass.FormattingEnabled = true;
            this.TeachersInClass.ItemHeight = 20;
            this.TeachersInClass.Location = new System.Drawing.Point(451, 415);
            this.TeachersInClass.Name = "TeachersInClass";
            this.TeachersInClass.Size = new System.Drawing.Size(393, 104);
            this.TeachersInClass.TabIndex = 34;
            this.TeachersInClass.SelectedIndexChanged += new System.EventHandler(this.TeacherChoiceChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(447, 392);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "Teachers";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(451, 536);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(189, 57);
            this.button2.TabIndex = 35;
            this.button2.Text = "Remove selected student/teacher";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.RemoveUserEvent);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(655, 536);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(189, 57);
            this.button5.TabIndex = 36;
            this.button5.Text = "Add new student/teacher";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.GoToAddUserMenu);
            // 
            // DeleteAssignmentButton
            // 
            this.DeleteAssignmentButton.Location = new System.Drawing.Point(1018, 536);
            this.DeleteAssignmentButton.Name = "DeleteAssignmentButton";
            this.DeleteAssignmentButton.Size = new System.Drawing.Size(189, 57);
            this.DeleteAssignmentButton.TabIndex = 43;
            this.DeleteAssignmentButton.Text = "Delete selected assignment";
            this.DeleteAssignmentButton.UseVisualStyleBackColor = true;
            this.DeleteAssignmentButton.Click += new System.EventHandler(this.DeleteAssignmentEvent);
            // 
            // AssignmentsListBox
            // 
            this.AssignmentsListBox.FormattingEnabled = true;
            this.AssignmentsListBox.ItemHeight = 20;
            this.AssignmentsListBox.Location = new System.Drawing.Point(880, 235);
            this.AssignmentsListBox.Name = "AssignmentsListBox";
            this.AssignmentsListBox.Size = new System.Drawing.Size(327, 284);
            this.AssignmentsListBox.TabIndex = 40;
            this.AssignmentsListBox.SelectedIndexChanged += new System.EventHandler(this.AssignmentSelected);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(876, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 20);
            this.label10.TabIndex = 39;
            this.label10.Text = "Assignments";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.LightBlue;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FloralWhite;
            this.label12.Location = new System.Drawing.Point(880, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(327, 34);
            this.label12.TabIndex = 37;
            this.label12.Text = "Class assignments";
            // 
            // EditClassnameButton
            // 
            this.EditClassnameButton.Location = new System.Drawing.Point(741, 211);
            this.EditClassnameButton.Name = "EditClassnameButton";
            this.EditClassnameButton.Size = new System.Drawing.Size(103, 41);
            this.EditClassnameButton.TabIndex = 44;
            this.EditClassnameButton.Text = "Edit";
            this.EditClassnameButton.UseVisualStyleBackColor = true;
            this.EditClassnameButton.Click += new System.EventHandler(this.EditClassNameEvent);
            // 
            // SuccessMessage
            // 
            this.SuccessMessage.AutoSize = true;
            this.SuccessMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SuccessMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SuccessMessage.Location = new System.Drawing.Point(388, 27);
            this.SuccessMessage.Name = "SuccessMessage";
            this.SuccessMessage.Size = new System.Drawing.Size(72, 22);
            this.SuccessMessage.TabIndex = 45;
            this.SuccessMessage.Text = "Success";
            // 
            // ClassManagementMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 632);
            this.Controls.Add(this.SuccessMessage);
            this.Controls.Add(this.EditClassnameButton);
            this.Controls.Add(this.DeleteAssignmentButton);
            this.Controls.Add(this.AssignmentsListBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TeachersInClass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.StudentsInClass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ClassnameLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SearchForClassButton);
            this.Controls.Add(this.ClassListBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ClassNameFilter);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ClassManagementMenu";
            this.Text = "ClassManagementMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ClassnameLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SearchForClassButton;
        private System.Windows.Forms.ListBox ClassListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ClassNameFilter;
        private System.Windows.Forms.ListBox StudentsInClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox TeachersInClass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button DeleteAssignmentButton;
        private System.Windows.Forms.ListBox AssignmentsListBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button EditClassnameButton;
        private System.Windows.Forms.Label SuccessMessage;
    }
}