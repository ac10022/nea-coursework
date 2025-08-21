namespace nea_ui
{
    partial class QuestionManagement
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
            this.DeleteQuestionButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.EditQuestionButton = new System.Windows.Forms.Button();
            this.ContentLabel = new System.Windows.Forms.Label();
            this.DifficultyLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.TopicLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.QuestionMatches = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AuthorPicker = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TopicPicker = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.AnswerPreviewButton = new System.Windows.Forms.Button();
            this.AnswerPreviewLabel = new System.Windows.Forms.Label();
            this.PrintButton = new System.Windows.Forms.Button();
            this.DifficultyCheckbox1 = new System.Windows.Forms.CheckBox();
            this.DifficultyCheckbox2 = new System.Windows.Forms.CheckBox();
            this.DifficultyCheckbox3 = new System.Windows.Forms.CheckBox();
            this.DifficultyCheckbox4 = new System.Windows.Forms.CheckBox();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.SuccessMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DeleteQuestionButton
            // 
            this.DeleteQuestionButton.Location = new System.Drawing.Point(792, 450);
            this.DeleteQuestionButton.Name = "DeleteQuestionButton";
            this.DeleteQuestionButton.Size = new System.Drawing.Size(170, 43);
            this.DeleteQuestionButton.TabIndex = 39;
            this.DeleteQuestionButton.Text = "Delete question";
            this.DeleteQuestionButton.UseVisualStyleBackColor = true;
            this.DeleteQuestionButton.Click += new System.EventHandler(this.DeleteQuestionEvent);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button4.Location = new System.Drawing.Point(639, 75);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(314, 43);
            this.button4.TabIndex = 38;
            this.button4.Text = "Back to dashboard";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.BackToDashboard);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(639, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(314, 43);
            this.button3.TabIndex = 37;
            this.button3.Text = "Create a new question";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.GoToCreateQuestionMenu);
            // 
            // EditQuestionButton
            // 
            this.EditQuestionButton.Location = new System.Drawing.Point(596, 450);
            this.EditQuestionButton.Name = "EditQuestionButton";
            this.EditQuestionButton.Size = new System.Drawing.Size(181, 43);
            this.EditQuestionButton.TabIndex = 36;
            this.EditQuestionButton.Text = "Edit question";
            this.EditQuestionButton.UseVisualStyleBackColor = true;
            this.EditQuestionButton.Click += new System.EventHandler(this.EditQuestionEvent);
            // 
            // ContentLabel
            // 
            this.ContentLabel.AutoSize = true;
            this.ContentLabel.Location = new System.Drawing.Point(592, 323);
            this.ContentLabel.Name = "ContentLabel";
            this.ContentLabel.Size = new System.Drawing.Size(311, 20);
            this.ContentLabel.TabIndex = 35;
            this.ContentLabel.Text = "Content preview: [TRUNCATEDCONTENT]";
            // 
            // DifficultyLabel
            // 
            this.DifficultyLabel.AutoSize = true;
            this.DifficultyLabel.Location = new System.Drawing.Point(592, 293);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(179, 20);
            this.DifficultyLabel.TabIndex = 34;
            this.DifficultyLabel.Text = "Difficulty: [DIFFICULTY]";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(592, 263);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(141, 20);
            this.AuthorLabel.TabIndex = 33;
            this.AuthorLabel.Text = "Author: [AUTHOR]";
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Location = new System.Drawing.Point(592, 234);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(152, 20);
            this.SubjectLabel.TabIndex = 32;
            this.SubjectLabel.Text = "Subject: [SUBJECT]";
            // 
            // TopicLabel
            // 
            this.TopicLabel.AutoSize = true;
            this.TopicLabel.Location = new System.Drawing.Point(592, 203);
            this.TopicLabel.Name = "TopicLabel";
            this.TopicLabel.Size = new System.Drawing.Size(110, 20);
            this.TopicLabel.TabIndex = 31;
            this.TopicLabel.Text = "Topic: [TOPIC]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightBlue;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FloralWhite;
            this.label6.Location = new System.Drawing.Point(596, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(377, 34);
            this.label6.TabIndex = 30;
            this.label6.Text = "Question information";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(24, 234);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(540, 33);
            this.SearchButton.TabIndex = 29;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchEvent);
            // 
            // QuestionMatches
            // 
            this.QuestionMatches.FormattingEnabled = true;
            this.QuestionMatches.ItemHeight = 20;
            this.QuestionMatches.Location = new System.Drawing.Point(24, 309);
            this.QuestionMatches.Name = "QuestionMatches";
            this.QuestionMatches.Size = new System.Drawing.Size(540, 184);
            this.QuestionMatches.TabIndex = 28;
            this.QuestionMatches.SelectedIndexChanged += new System.EventHandler(this.UpdateQuestionInformation);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Matches";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Authoring teacher";
            // 
            // AuthorPicker
            // 
            this.AuthorPicker.FormattingEnabled = true;
            this.AuthorPicker.Location = new System.Drawing.Point(309, 162);
            this.AuthorPicker.Name = "AuthorPicker";
            this.AuthorPicker.Size = new System.Drawing.Size(255, 28);
            this.AuthorPicker.TabIndex = 25;
            this.AuthorPicker.SelectedIndexChanged += new System.EventHandler(this.TestForData);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(24, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 34);
            this.label2.TabIndex = 22;
            this.label2.Text = "Search for a question";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 44);
            this.label1.TabIndex = 21;
            this.label1.Text = "Question Manager";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "Topic";
            // 
            // TopicPicker
            // 
            this.TopicPicker.FormattingEnabled = true;
            this.TopicPicker.Location = new System.Drawing.Point(24, 163);
            this.TopicPicker.Name = "TopicPicker";
            this.TopicPicker.Size = new System.Drawing.Size(148, 28);
            this.TopicPicker.TabIndex = 40;
            this.TopicPicker.SelectedIndexChanged += new System.EventHandler(this.TestForData);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(185, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 46;
            this.label12.Text = "Difficulty";
            // 
            // AnswerPreviewButton
            // 
            this.AnswerPreviewButton.Location = new System.Drawing.Point(596, 357);
            this.AnswerPreviewButton.Name = "AnswerPreviewButton";
            this.AnswerPreviewButton.Size = new System.Drawing.Size(181, 43);
            this.AnswerPreviewButton.TabIndex = 51;
            this.AnswerPreviewButton.Text = "Preview answer";
            this.AnswerPreviewButton.UseVisualStyleBackColor = true;
            this.AnswerPreviewButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PreviewAnswerEvent);
            this.AnswerPreviewButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HideAnswerEvent);
            // 
            // AnswerPreviewLabel
            // 
            this.AnswerPreviewLabel.AutoSize = true;
            this.AnswerPreviewLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AnswerPreviewLabel.Location = new System.Drawing.Point(598, 413);
            this.AnswerPreviewLabel.Name = "AnswerPreviewLabel";
            this.AnswerPreviewLabel.Size = new System.Drawing.Size(313, 22);
            this.AnswerPreviewLabel.TabIndex = 52;
            this.AnswerPreviewLabel.Text = "Content preview: [TRUNCATEDCONTENT]";
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(792, 357);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(170, 43);
            this.PrintButton.TabIndex = 53;
            this.PrintButton.Text = "Print question";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintQuestionEvent);
            // 
            // DifficultyCheckbox1
            // 
            this.DifficultyCheckbox1.AutoSize = true;
            this.DifficultyCheckbox1.Location = new System.Drawing.Point(189, 164);
            this.DifficultyCheckbox1.Name = "DifficultyCheckbox1";
            this.DifficultyCheckbox1.Size = new System.Drawing.Size(44, 24);
            this.DifficultyCheckbox1.TabIndex = 47;
            this.DifficultyCheckbox1.Text = "1";
            this.DifficultyCheckbox1.UseVisualStyleBackColor = true;
            this.DifficultyCheckbox1.CheckedChanged += new System.EventHandler(this.TestForData);
            // 
            // DifficultyCheckbox2
            // 
            this.DifficultyCheckbox2.AutoSize = true;
            this.DifficultyCheckbox2.Location = new System.Drawing.Point(239, 164);
            this.DifficultyCheckbox2.Name = "DifficultyCheckbox2";
            this.DifficultyCheckbox2.Size = new System.Drawing.Size(44, 24);
            this.DifficultyCheckbox2.TabIndex = 48;
            this.DifficultyCheckbox2.Text = "2";
            this.DifficultyCheckbox2.UseVisualStyleBackColor = true;
            this.DifficultyCheckbox2.CheckedChanged += new System.EventHandler(this.TestForData);
            // 
            // DifficultyCheckbox3
            // 
            this.DifficultyCheckbox3.AutoSize = true;
            this.DifficultyCheckbox3.Location = new System.Drawing.Point(189, 194);
            this.DifficultyCheckbox3.Name = "DifficultyCheckbox3";
            this.DifficultyCheckbox3.Size = new System.Drawing.Size(44, 24);
            this.DifficultyCheckbox3.TabIndex = 49;
            this.DifficultyCheckbox3.Text = "3";
            this.DifficultyCheckbox3.UseVisualStyleBackColor = true;
            this.DifficultyCheckbox3.CheckedChanged += new System.EventHandler(this.TestForData);
            // 
            // DifficultyCheckbox4
            // 
            this.DifficultyCheckbox4.AutoSize = true;
            this.DifficultyCheckbox4.Location = new System.Drawing.Point(239, 194);
            this.DifficultyCheckbox4.Name = "DifficultyCheckbox4";
            this.DifficultyCheckbox4.Size = new System.Drawing.Size(44, 24);
            this.DifficultyCheckbox4.TabIndex = 50;
            this.DifficultyCheckbox4.Text = "4";
            this.DifficultyCheckbox4.UseVisualStyleBackColor = true;
            this.DifficultyCheckbox4.CheckedChanged += new System.EventHandler(this.TestForData);
            // 
            // SuccessMessage
            // 
            this.SuccessMessage.AutoSize = true;
            this.SuccessMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SuccessMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SuccessMessage.Location = new System.Drawing.Point(461, 31);
            this.SuccessMessage.Name = "SuccessMessage";
            this.SuccessMessage.Size = new System.Drawing.Size(72, 22);
            this.SuccessMessage.TabIndex = 54;
            this.SuccessMessage.Text = "Success";
            // 
            // QuestionManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 518);
            this.Controls.Add(this.SuccessMessage);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.AnswerPreviewLabel);
            this.Controls.Add(this.AnswerPreviewButton);
            this.Controls.Add(this.DifficultyCheckbox4);
            this.Controls.Add(this.DifficultyCheckbox3);
            this.Controls.Add(this.DifficultyCheckbox2);
            this.Controls.Add(this.DifficultyCheckbox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TopicPicker);
            this.Controls.Add(this.DeleteQuestionButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.EditQuestionButton);
            this.Controls.Add(this.ContentLabel);
            this.Controls.Add(this.DifficultyLabel);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.SubjectLabel);
            this.Controls.Add(this.TopicLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.QuestionMatches);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AuthorPicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QuestionManagement";
            this.Text = "QuestionManagement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeleteQuestionButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button EditQuestionButton;
        private System.Windows.Forms.Label ContentLabel;
        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label SubjectLabel;
        private System.Windows.Forms.Label TopicLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ListBox QuestionMatches;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AuthorPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TopicPicker;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button AnswerPreviewButton;
        private System.Windows.Forms.Label AnswerPreviewLabel;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.CheckBox DifficultyCheckbox1;
        private System.Windows.Forms.CheckBox DifficultyCheckbox2;
        private System.Windows.Forms.CheckBox DifficultyCheckbox3;
        private System.Windows.Forms.CheckBox DifficultyCheckbox4;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.Label SuccessMessage;
    }
}