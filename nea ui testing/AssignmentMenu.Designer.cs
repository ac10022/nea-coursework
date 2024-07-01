namespace nea_ui_testing
{
    partial class AssignmentMenu
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
            this.label3 = new System.Windows.Forms.Label();
            this.ClassPicker = new System.Windows.Forms.ComboBox();
            this.RemoveQFromTrackingList = new System.Windows.Forms.Button();
            this.BackToDashboard = new System.Windows.Forms.Button();
            this.AddQButton = new System.Windows.Forms.Button();
            this.ContentField = new System.Windows.Forms.Label();
            this.DifficultyField = new System.Windows.Forms.Label();
            this.AuthorField = new System.Windows.Forms.Label();
            this.SubjectField = new System.Windows.Forms.Label();
            this.TopicField = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.QuestionTrackingList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SetAssignmentButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.HomeworkNameField = new System.Windows.Forms.TextBox();
            this.SuccessMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "Class";
            // 
            // ClassPicker
            // 
            this.ClassPicker.FormattingEnabled = true;
            this.ClassPicker.Location = new System.Drawing.Point(27, 161);
            this.ClassPicker.Name = "ClassPicker";
            this.ClassPicker.Size = new System.Drawing.Size(148, 28);
            this.ClassPicker.TabIndex = 64;
            this.ClassPicker.SelectedIndexChanged += new System.EventHandler(this.TestForData);
            // 
            // RemoveQFromTrackingList
            // 
            this.RemoveQFromTrackingList.Location = new System.Drawing.Point(599, 357);
            this.RemoveQFromTrackingList.Name = "RemoveQFromTrackingList";
            this.RemoveQFromTrackingList.Size = new System.Drawing.Size(366, 59);
            this.RemoveQFromTrackingList.TabIndex = 63;
            this.RemoveQFromTrackingList.Text = "Remove selected question from tracking list";
            this.RemoveQFromTrackingList.UseVisualStyleBackColor = true;
            this.RemoveQFromTrackingList.Click += new System.EventHandler(this.RemoveQuestionEvent);
            // 
            // BackToDashboard
            // 
            this.BackToDashboard.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackToDashboard.Location = new System.Drawing.Point(642, 73);
            this.BackToDashboard.Name = "BackToDashboard";
            this.BackToDashboard.Size = new System.Drawing.Size(314, 43);
            this.BackToDashboard.TabIndex = 62;
            this.BackToDashboard.Text = "Back to dashboard";
            this.BackToDashboard.UseVisualStyleBackColor = false;
            this.BackToDashboard.Click += new System.EventHandler(this.GoBackToDashboard);
            // 
            // AddQButton
            // 
            this.AddQButton.Location = new System.Drawing.Point(642, 24);
            this.AddQButton.Name = "AddQButton";
            this.AddQButton.Size = new System.Drawing.Size(314, 43);
            this.AddQButton.TabIndex = 61;
            this.AddQButton.Text = "Add question";
            this.AddQButton.UseVisualStyleBackColor = true;
            this.AddQButton.Click += new System.EventHandler(this.GoToAddQMenu);
            // 
            // ContentField
            // 
            this.ContentField.AutoSize = true;
            this.ContentField.Location = new System.Drawing.Point(595, 321);
            this.ContentField.Name = "ContentField";
            this.ContentField.Size = new System.Drawing.Size(311, 20);
            this.ContentField.TabIndex = 59;
            this.ContentField.Text = "Content preview: [TRUNCATEDCONTENT]";
            // 
            // DifficultyField
            // 
            this.DifficultyField.AutoSize = true;
            this.DifficultyField.Location = new System.Drawing.Point(595, 291);
            this.DifficultyField.Name = "DifficultyField";
            this.DifficultyField.Size = new System.Drawing.Size(179, 20);
            this.DifficultyField.TabIndex = 58;
            this.DifficultyField.Text = "Difficulty: [DIFFICULTY]";
            // 
            // AuthorField
            // 
            this.AuthorField.AutoSize = true;
            this.AuthorField.Location = new System.Drawing.Point(595, 261);
            this.AuthorField.Name = "AuthorField";
            this.AuthorField.Size = new System.Drawing.Size(141, 20);
            this.AuthorField.TabIndex = 57;
            this.AuthorField.Text = "Author: [AUTHOR]";
            // 
            // SubjectField
            // 
            this.SubjectField.AutoSize = true;
            this.SubjectField.Location = new System.Drawing.Point(595, 232);
            this.SubjectField.Name = "SubjectField";
            this.SubjectField.Size = new System.Drawing.Size(152, 20);
            this.SubjectField.TabIndex = 56;
            this.SubjectField.Text = "Subject: [SUBJECT]";
            // 
            // TopicField
            // 
            this.TopicField.AutoSize = true;
            this.TopicField.Location = new System.Drawing.Point(595, 201);
            this.TopicField.Name = "TopicField";
            this.TopicField.Size = new System.Drawing.Size(110, 20);
            this.TopicField.TabIndex = 55;
            this.TopicField.Text = "Topic: [TOPIC]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightBlue;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FloralWhite;
            this.label6.Location = new System.Drawing.Point(599, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(377, 34);
            this.label6.TabIndex = 54;
            this.label6.Text = "Question information";
            // 
            // QuestionTrackingList
            // 
            this.QuestionTrackingList.FormattingEnabled = true;
            this.QuestionTrackingList.ItemHeight = 20;
            this.QuestionTrackingList.Location = new System.Drawing.Point(27, 232);
            this.QuestionTrackingList.Name = "QuestionTrackingList";
            this.QuestionTrackingList.Size = new System.Drawing.Size(540, 184);
            this.QuestionTrackingList.TabIndex = 52;
            this.QuestionTrackingList.SelectedIndexChanged += new System.EventHandler(this.UpdateQuestionInformation);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 20);
            this.label5.TabIndex = 51;
            this.label5.Text = "Question tracking list";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(27, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 34);
            this.label2.TabIndex = 48;
            this.label2.Text = "Set an assignment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 44);
            this.label1.TabIndex = 47;
            this.label1.Text = "Assignment Manager";
            // 
            // DueDatePicker
            // 
            this.DueDatePicker.Location = new System.Drawing.Point(197, 161);
            this.DueDatePicker.Name = "DueDatePicker";
            this.DueDatePicker.Size = new System.Drawing.Size(200, 26);
            this.DueDatePicker.TabIndex = 66;
            this.DueDatePicker.ValueChanged += new System.EventHandler(this.TestForData);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 67;
            this.label4.Text = "Due date";
            // 
            // SetAssignmentButton
            // 
            this.SetAssignmentButton.Location = new System.Drawing.Point(366, 434);
            this.SetAssignmentButton.Name = "SetAssignmentButton";
            this.SetAssignmentButton.Size = new System.Drawing.Size(201, 39);
            this.SetAssignmentButton.TabIndex = 68;
            this.SetAssignmentButton.Text = "Set assignment";
            this.SetAssignmentButton.UseVisualStyleBackColor = true;
            this.SetAssignmentButton.Click += new System.EventHandler(this.SetAssignmentEvent);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 422);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 20);
            this.label7.TabIndex = 70;
            this.label7.Text = "Homework name";
            // 
            // HomeworkNameField
            // 
            this.HomeworkNameField.Location = new System.Drawing.Point(27, 445);
            this.HomeworkNameField.Name = "HomeworkNameField";
            this.HomeworkNameField.Size = new System.Drawing.Size(252, 26);
            this.HomeworkNameField.TabIndex = 71;
            this.HomeworkNameField.TextChanged += new System.EventHandler(this.TestForData);
            // 
            // SuccessMessage
            // 
            this.SuccessMessage.AutoSize = true;
            this.SuccessMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SuccessMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SuccessMessage.Location = new System.Drawing.Point(599, 449);
            this.SuccessMessage.Name = "SuccessMessage";
            this.SuccessMessage.Size = new System.Drawing.Size(72, 22);
            this.SuccessMessage.TabIndex = 72;
            this.SuccessMessage.Text = "Success";
            // 
            // AssignmentMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 495);
            this.Controls.Add(this.SuccessMessage);
            this.Controls.Add(this.HomeworkNameField);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SetAssignmentButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DueDatePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ClassPicker);
            this.Controls.Add(this.RemoveQFromTrackingList);
            this.Controls.Add(this.BackToDashboard);
            this.Controls.Add(this.AddQButton);
            this.Controls.Add(this.ContentField);
            this.Controls.Add(this.DifficultyField);
            this.Controls.Add(this.AuthorField);
            this.Controls.Add(this.SubjectField);
            this.Controls.Add(this.TopicField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.QuestionTrackingList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AssignmentMenu";
            this.Text = "AssignmentMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ClassPicker;
        private System.Windows.Forms.Button RemoveQFromTrackingList;
        private System.Windows.Forms.Button BackToDashboard;
        private System.Windows.Forms.Button AddQButton;
        private System.Windows.Forms.Label ContentField;
        private System.Windows.Forms.Label DifficultyField;
        private System.Windows.Forms.Label AuthorField;
        private System.Windows.Forms.Label SubjectField;
        private System.Windows.Forms.Label TopicField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox QuestionTrackingList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DueDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SetAssignmentButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox HomeworkNameField;
        private System.Windows.Forms.Label SuccessMessage;
    }
}