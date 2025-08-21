namespace nea_ui
{
    partial class StudentQuestionHistory
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
            this.AttemptList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AnalysisLabel = new System.Windows.Forms.Label();
            this.ContentLabel = new System.Windows.Forms.Label();
            this.DifficultyLabel = new System.Windows.Forms.Label();
            this.TopicLabel = new System.Windows.Forms.Label();
            this.AnswerLabel = new System.Windows.Forms.Label();
            this.StudentAnswerLabel = new System.Windows.Forms.Label();
            this.TimeTakenLabel = new System.Windows.Forms.Label();
            this.OverrideButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AttemptList
            // 
            this.AttemptList.FormattingEnabled = true;
            this.AttemptList.ItemHeight = 20;
            this.AttemptList.Items.AddRange(new object[] {
            ""});
            this.AttemptList.Location = new System.Drawing.Point(23, 106);
            this.AttemptList.Name = "AttemptList";
            this.AttemptList.Size = new System.Drawing.Size(393, 444);
            this.AttemptList.TabIndex = 31;
            this.AttemptList.SelectedIndexChanged += new System.EventHandler(this.QuestionSelectEvent);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "Past question attempts";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 44);
            this.label1.TabIndex = 28;
            this.label1.Text = "Student History";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.LightBlue;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FloralWhite;
            this.label14.Location = new System.Drawing.Point(438, 303);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(338, 34);
            this.label14.TabIndex = 60;
            this.label14.Text = "Question metadata";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(438, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(411, 34);
            this.label2.TabIndex = 61;
            this.label2.Text = "Topics to improve upon";
            // 
            // AnalysisLabel
            // 
            this.AnalysisLabel.AutoSize = true;
            this.AnalysisLabel.Location = new System.Drawing.Point(434, 112);
            this.AnalysisLabel.Name = "AnalysisLabel";
            this.AnalysisLabel.Size = new System.Drawing.Size(190, 100);
            this.AnalysisLabel.TabIndex = 68;
            this.AnalysisLabel.Text = "For improvement:\r\n[TOPIC], [TOPIC], [TOPIC]\r\n\r\nStrengths:\r\n[TOPIC], [TOPIC], [TOP" +
    "IC]";
            // 
            // ContentLabel
            // 
            this.ContentLabel.AutoSize = true;
            this.ContentLabel.Location = new System.Drawing.Point(434, 412);
            this.ContentLabel.Name = "ContentLabel";
            this.ContentLabel.Size = new System.Drawing.Size(311, 20);
            this.ContentLabel.TabIndex = 73;
            this.ContentLabel.Text = "Content preview: [TRUNCATEDCONTENT]";
            // 
            // DifficultyLabel
            // 
            this.DifficultyLabel.AutoSize = true;
            this.DifficultyLabel.Location = new System.Drawing.Point(434, 382);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(179, 20);
            this.DifficultyLabel.TabIndex = 72;
            this.DifficultyLabel.Text = "Difficulty: [DIFFICULTY]";
            // 
            // TopicLabel
            // 
            this.TopicLabel.AutoSize = true;
            this.TopicLabel.Location = new System.Drawing.Point(434, 353);
            this.TopicLabel.Name = "TopicLabel";
            this.TopicLabel.Size = new System.Drawing.Size(110, 20);
            this.TopicLabel.TabIndex = 69;
            this.TopicLabel.Text = "Topic: [TOPIC]";
            // 
            // AnswerLabel
            // 
            this.AnswerLabel.AutoSize = true;
            this.AnswerLabel.Location = new System.Drawing.Point(434, 465);
            this.AnswerLabel.Name = "AnswerLabel";
            this.AnswerLabel.Size = new System.Drawing.Size(149, 20);
            this.AnswerLabel.TabIndex = 74;
            this.AnswerLabel.Text = "Answer: [ANSWER]";
            // 
            // StudentAnswerLabel
            // 
            this.StudentAnswerLabel.AutoSize = true;
            this.StudentAnswerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.StudentAnswerLabel.Location = new System.Drawing.Point(434, 494);
            this.StudentAnswerLabel.Name = "StudentAnswerLabel";
            this.StudentAnswerLabel.Size = new System.Drawing.Size(283, 20);
            this.StudentAnswerLabel.TabIndex = 75;
            this.StudentAnswerLabel.Text = "Student answer: [STUDENTANSWER]";
            // 
            // TimeTakenLabel
            // 
            this.TimeTakenLabel.AutoSize = true;
            this.TimeTakenLabel.Location = new System.Drawing.Point(434, 526);
            this.TimeTakenLabel.Name = "TimeTakenLabel";
            this.TimeTakenLabel.Size = new System.Drawing.Size(193, 20);
            this.TimeTakenLabel.TabIndex = 76;
            this.TimeTakenLabel.Text = "Time taken: [TIMETAKEN]";
            // 
            // OverrideButton
            // 
            this.OverrideButton.Location = new System.Drawing.Point(744, 483);
            this.OverrideButton.Name = "OverrideButton";
            this.OverrideButton.Size = new System.Drawing.Size(116, 42);
            this.OverrideButton.TabIndex = 77;
            this.OverrideButton.Text = "Override";
            this.OverrideButton.UseVisualStyleBackColor = true;
            this.OverrideButton.Click += new System.EventHandler(this.OverrideEvent);
            // 
            // StudentQuestionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 571);
            this.Controls.Add(this.OverrideButton);
            this.Controls.Add(this.TimeTakenLabel);
            this.Controls.Add(this.StudentAnswerLabel);
            this.Controls.Add(this.AnswerLabel);
            this.Controls.Add(this.ContentLabel);
            this.Controls.Add(this.DifficultyLabel);
            this.Controls.Add(this.TopicLabel);
            this.Controls.Add(this.AnalysisLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.AttemptList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "StudentQuestionHistory";
            this.Text = "StudentQuestionHistory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AttemptList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label AnalysisLabel;
        private System.Windows.Forms.Label ContentLabel;
        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.Label TopicLabel;
        private System.Windows.Forms.Label AnswerLabel;
        private System.Windows.Forms.Label StudentAnswerLabel;
        private System.Windows.Forms.Label TimeTakenLabel;
        private System.Windows.Forms.Button OverrideButton;
    }
}