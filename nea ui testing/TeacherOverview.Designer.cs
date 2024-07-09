namespace nea_ui_testing
{
    partial class TeacherOverview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherOverview));
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ClassPicker = new System.Windows.Forms.ComboBox();
            this.StudentsInClass = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SeeQHistoryButton = new System.Windows.Forms.Button();
            this.LastLoginField = new System.Windows.Forms.Label();
            this.NameField = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SAP_1 = new System.Windows.Forms.Label();
            this.SAP_2 = new System.Windows.Forms.Label();
            this.SAP_3 = new System.Windows.Forms.Label();
            this.SAP_5 = new System.Windows.Forms.Label();
            this.SAP_4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ClassNameField = new System.Windows.Forms.Label();
            this.CorrectnessPerQuestion = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.AssignmentPicker = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TopicAnalysisField = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button4.Location = new System.Drawing.Point(690, 29);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(357, 43);
            this.button4.TabIndex = 27;
            this.button4.Text = "Back to dashboard";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.GoBackToDashboard);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(25, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 34);
            this.label2.TabIndex = 25;
            this.label2.Text = "Search for a class";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 44);
            this.label1.TabIndex = 24;
            this.label1.Text = "Teacher Overview";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "Class";
            // 
            // ClassPicker
            // 
            this.ClassPicker.FormattingEnabled = true;
            this.ClassPicker.Location = new System.Drawing.Point(25, 161);
            this.ClassPicker.Name = "ClassPicker";
            this.ClassPicker.Size = new System.Drawing.Size(148, 28);
            this.ClassPicker.TabIndex = 42;
            // 
            // StudentsInClass
            // 
            this.StudentsInClass.FormattingEnabled = true;
            this.StudentsInClass.ItemHeight = 20;
            this.StudentsInClass.Location = new System.Drawing.Point(25, 224);
            this.StudentsInClass.Name = "StudentsInClass";
            this.StudentsInClass.Size = new System.Drawing.Size(148, 324);
            this.StudentsInClass.TabIndex = 45;
            this.StudentsInClass.SelectedIndexChanged += new System.EventHandler(this.StudentSelected);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "Students";
            // 
            // SeeQHistoryButton
            // 
            this.SeeQHistoryButton.Location = new System.Drawing.Point(203, 505);
            this.SeeQHistoryButton.Name = "SeeQHistoryButton";
            this.SeeQHistoryButton.Size = new System.Drawing.Size(254, 43);
            this.SeeQHistoryButton.TabIndex = 52;
            this.SeeQHistoryButton.Text = "See student question history";
            this.SeeQHistoryButton.UseVisualStyleBackColor = true;
            this.SeeQHistoryButton.Click += new System.EventHandler(this.SeeStudentHistory);
            // 
            // LastLoginField
            // 
            this.LastLoginField.AutoSize = true;
            this.LastLoginField.Location = new System.Drawing.Point(199, 215);
            this.LastLoginField.Name = "LastLoginField";
            this.LastLoginField.Size = new System.Drawing.Size(237, 20);
            this.LastLoginField.TabIndex = 48;
            this.LastLoginField.Text = "Last Log-in: [LASTLOGINDATE]";
            // 
            // NameField
            // 
            this.NameField.AutoSize = true;
            this.NameField.Location = new System.Drawing.Point(199, 184);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(113, 20);
            this.NameField.TabIndex = 47;
            this.NameField.Text = "Name: [NAME]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightBlue;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FloralWhite;
            this.label6.Location = new System.Drawing.Point(203, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(326, 34);
            this.label6.TabIndex = 46;
            this.label6.Text = "Individual student";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightBlue;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FloralWhite;
            this.label5.Location = new System.Drawing.Point(203, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 34);
            this.label5.TabIndex = 53;
            this.label5.Text = "Performance";
            // 
            // SAP_1
            // 
            this.SAP_1.AutoSize = true;
            this.SAP_1.BackColor = System.Drawing.Color.Transparent;
            this.SAP_1.Location = new System.Drawing.Point(199, 307);
            this.SAP_1.Name = "SAP_1";
            this.SAP_1.Size = new System.Drawing.Size(242, 20);
            this.SAP_1.TabIndex = 54;
            this.SAP_1.Text = "[ASSIGNMENTNAME]: [SCORE]";
            // 
            // SAP_2
            // 
            this.SAP_2.AutoSize = true;
            this.SAP_2.BackColor = System.Drawing.Color.Transparent;
            this.SAP_2.Location = new System.Drawing.Point(200, 341);
            this.SAP_2.Name = "SAP_2";
            this.SAP_2.Size = new System.Drawing.Size(242, 20);
            this.SAP_2.TabIndex = 55;
            this.SAP_2.Text = "[ASSIGNMENTNAME]: [SCORE]";
            // 
            // SAP_3
            // 
            this.SAP_3.AutoSize = true;
            this.SAP_3.Location = new System.Drawing.Point(200, 375);
            this.SAP_3.Name = "SAP_3";
            this.SAP_3.Size = new System.Drawing.Size(242, 20);
            this.SAP_3.TabIndex = 56;
            this.SAP_3.Text = "[ASSIGNMENTNAME]: [SCORE]";
            // 
            // SAP_5
            // 
            this.SAP_5.AutoSize = true;
            this.SAP_5.Location = new System.Drawing.Point(200, 444);
            this.SAP_5.Name = "SAP_5";
            this.SAP_5.Size = new System.Drawing.Size(242, 20);
            this.SAP_5.TabIndex = 58;
            this.SAP_5.Text = "[ASSIGNMENTNAME]: [SCORE]";
            // 
            // SAP_4
            // 
            this.SAP_4.AutoSize = true;
            this.SAP_4.BackColor = System.Drawing.Color.Transparent;
            this.SAP_4.Location = new System.Drawing.Point(200, 410);
            this.SAP_4.Name = "SAP_4";
            this.SAP_4.Size = new System.Drawing.Size(242, 20);
            this.SAP_4.TabIndex = 57;
            this.SAP_4.Text = "[ASSIGNMENTNAME]: [SCORE]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.LightBlue;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FloralWhite;
            this.label14.Location = new System.Drawing.Point(567, 138);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(333, 34);
            this.label14.TabIndex = 59;
            this.label14.Text = "Class performance";
            // 
            // ClassNameField
            // 
            this.ClassNameField.AutoSize = true;
            this.ClassNameField.Location = new System.Drawing.Point(563, 184);
            this.ClassNameField.Name = "ClassNameField";
            this.ClassNameField.Size = new System.Drawing.Size(156, 20);
            this.ClassNameField.TabIndex = 60;
            this.ClassNameField.Text = "Class Name: [NAME]";
            // 
            // CorrectnessPerQuestion
            // 
            this.CorrectnessPerQuestion.FormattingEnabled = true;
            this.CorrectnessPerQuestion.ItemHeight = 20;
            this.CorrectnessPerQuestion.Items.AddRange(new object[] {
            "Q1   94%",
            "Q2   65%",
            "Q3   100%",
            "Q4   8%"});
            this.CorrectnessPerQuestion.Location = new System.Drawing.Point(567, 307);
            this.CorrectnessPerQuestion.Name = "CorrectnessPerQuestion";
            this.CorrectnessPerQuestion.Size = new System.Drawing.Size(148, 224);
            this.CorrectnessPerQuestion.TabIndex = 63;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(563, 284);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(187, 20);
            this.label17.TabIndex = 62;
            this.label17.Text = "Correctness per question";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(563, 214);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 20);
            this.label15.TabIndex = 65;
            this.label15.Text = "Assignment";
            // 
            // AssignmentPicker
            // 
            this.AssignmentPicker.FormattingEnabled = true;
            this.AssignmentPicker.Location = new System.Drawing.Point(567, 237);
            this.AssignmentPicker.Name = "AssignmentPicker";
            this.AssignmentPicker.Size = new System.Drawing.Size(148, 28);
            this.AssignmentPicker.TabIndex = 64;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.LightBlue;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.FloralWhite;
            this.label18.Location = new System.Drawing.Point(783, 284);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(151, 34);
            this.label18.TabIndex = 66;
            this.label18.Text = "By topic";
            // 
            // TopicAnalysisField
            // 
            this.TopicAnalysisField.AutoSize = true;
            this.TopicAnalysisField.Location = new System.Drawing.Point(779, 330);
            this.TopicAnalysisField.Name = "TopicAnalysisField";
            this.TopicAnalysisField.Size = new System.Drawing.Size(229, 180);
            this.TopicAnalysisField.TabIndex = 67;
            this.TopicAnalysisField.Text = resources.GetString("TopicAnalysisField.Text");
            // 
            // TeacherOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 568);
            this.Controls.Add(this.TopicAnalysisField);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.AssignmentPicker);
            this.Controls.Add(this.CorrectnessPerQuestion);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.ClassNameField);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.SAP_5);
            this.Controls.Add(this.SAP_4);
            this.Controls.Add(this.SAP_3);
            this.Controls.Add(this.SAP_2);
            this.Controls.Add(this.SAP_1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SeeQHistoryButton);
            this.Controls.Add(this.LastLoginField);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.StudentsInClass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ClassPicker);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TeacherOverview";
            this.Text = "TeacherOverview";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ClassPicker;
        private System.Windows.Forms.ListBox StudentsInClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SeeQHistoryButton;
        private System.Windows.Forms.Label LastLoginField;
        private System.Windows.Forms.Label NameField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label SAP_1;
        private System.Windows.Forms.Label SAP_2;
        private System.Windows.Forms.Label SAP_3;
        private System.Windows.Forms.Label SAP_5;
        private System.Windows.Forms.Label SAP_4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label ClassNameField;
        private System.Windows.Forms.ListBox CorrectnessPerQuestion;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox AssignmentPicker;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label TopicAnalysisField;
    }
}