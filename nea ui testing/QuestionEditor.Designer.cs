namespace nea_ui_testing
{
    partial class QuestionEditor
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
            this.SubmitButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ContentField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DifficultyPicker = new System.Windows.Forms.ComboBox();
            this.TopicPicker = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AnswerField = new System.Windows.Forms.TextBox();
            this.MultipleChoiceCheckbox = new System.Windows.Forms.CheckBox();
            this.IncorrectAnswersLabel = new System.Windows.Forms.Label();
            this.IncorrectAnswersField = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RemoveImageButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.UploadImageButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ImageTrackingList = new System.Windows.Forms.ListBox();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.AnswerKeyField = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuccessMessage = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(420, 322);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(134, 109);
            this.SubmitButton.TabIndex = 19;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitQuestion);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Question content";
            // 
            // ContentField
            // 
            this.ContentField.Location = new System.Drawing.Point(10, 29);
            this.ContentField.Name = "ContentField";
            this.ContentField.Size = new System.Drawing.Size(360, 26);
            this.ContentField.TabIndex = 17;
            this.ContentField.TextChanged += new System.EventHandler(this.TestForData);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(28, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 44);
            this.label1.TabIndex = 16;
            this.label1.Text = "Question editor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Question difficulty";
            // 
            // DifficultyPicker
            // 
            this.DifficultyPicker.FormattingEnabled = true;
            this.DifficultyPicker.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.DifficultyPicker.Location = new System.Drawing.Point(10, 94);
            this.DifficultyPicker.Name = "DifficultyPicker";
            this.DifficultyPicker.Size = new System.Drawing.Size(166, 28);
            this.DifficultyPicker.TabIndex = 22;
            this.DifficultyPicker.SelectedIndexChanged += new System.EventHandler(this.TestForData);
            // 
            // TopicPicker
            // 
            this.TopicPicker.FormattingEnabled = true;
            this.TopicPicker.Location = new System.Drawing.Point(204, 94);
            this.TopicPicker.Name = "TopicPicker";
            this.TopicPicker.Size = new System.Drawing.Size(166, 28);
            this.TopicPicker.TabIndex = 24;
            this.TopicPicker.SelectedIndexChanged += new System.EventHandler(this.TestForData);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Topic";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Answer(s) (comma separated)";
            // 
            // AnswerField
            // 
            this.AnswerField.Location = new System.Drawing.Point(10, 170);
            this.AnswerField.Name = "AnswerField";
            this.AnswerField.Size = new System.Drawing.Size(360, 26);
            this.AnswerField.TabIndex = 25;
            this.AnswerField.TextChanged += new System.EventHandler(this.TestForData);
            // 
            // MultipleChoiceCheckbox
            // 
            this.MultipleChoiceCheckbox.AutoSize = true;
            this.MultipleChoiceCheckbox.Location = new System.Drawing.Point(10, 213);
            this.MultipleChoiceCheckbox.Name = "MultipleChoiceCheckbox";
            this.MultipleChoiceCheckbox.Size = new System.Drawing.Size(139, 24);
            this.MultipleChoiceCheckbox.TabIndex = 27;
            this.MultipleChoiceCheckbox.Text = "Multiple choice";
            this.MultipleChoiceCheckbox.UseVisualStyleBackColor = true;
            this.MultipleChoiceCheckbox.CheckedChanged += new System.EventHandler(this.EnableMultipleChoiceEvent);
            // 
            // IncorrectAnswersLabel
            // 
            this.IncorrectAnswersLabel.AutoSize = true;
            this.IncorrectAnswersLabel.Location = new System.Drawing.Point(6, 252);
            this.IncorrectAnswersLabel.Name = "IncorrectAnswersLabel";
            this.IncorrectAnswersLabel.Size = new System.Drawing.Size(319, 20);
            this.IncorrectAnswersLabel.TabIndex = 29;
            this.IncorrectAnswersLabel.Text = "Other incorrect answers (comma separated)";
            // 
            // IncorrectAnswersField
            // 
            this.IncorrectAnswersField.Location = new System.Drawing.Point(10, 275);
            this.IncorrectAnswersField.Name = "IncorrectAnswersField";
            this.IncorrectAnswersField.Size = new System.Drawing.Size(360, 26);
            this.IncorrectAnswersField.TabIndex = 28;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(16, 85);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(398, 351);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.IncorrectAnswersLabel);
            this.tabPage1.Controls.Add(this.IncorrectAnswersField);
            this.tabPage1.Controls.Add(this.ContentField);
            this.tabPage1.Controls.Add(this.MultipleChoiceCheckbox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.AnswerField);
            this.tabPage1.Controls.Add(this.DifficultyPicker);
            this.tabPage1.Controls.Add(this.TopicPicker);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(390, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Metadata";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RemoveImageButton);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.UploadImageButton);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.ImageTrackingList);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(390, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Images";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RemoveImageButton
            // 
            this.RemoveImageButton.Location = new System.Drawing.Point(10, 271);
            this.RemoveImageButton.Name = "RemoveImageButton";
            this.RemoveImageButton.Size = new System.Drawing.Size(264, 41);
            this.RemoveImageButton.TabIndex = 34;
            this.RemoveImageButton.Text = "Remove selected image";
            this.RemoveImageButton.UseVisualStyleBackColor = true;
            this.RemoveImageButton.Click += new System.EventHandler(this.RemoveImageEvent);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "Upload image (max size 256Kb)";
            // 
            // UploadImageButton
            // 
            this.UploadImageButton.Location = new System.Drawing.Point(10, 31);
            this.UploadImageButton.Name = "UploadImageButton";
            this.UploadImageButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UploadImageButton.Size = new System.Drawing.Size(150, 58);
            this.UploadImageButton.TabIndex = 32;
            this.UploadImageButton.Text = "Upload";
            this.UploadImageButton.UseVisualStyleBackColor = true;
            this.UploadImageButton.Click += new System.EventHandler(this.UploadImageEvent);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "Tracking list";
            // 
            // ImageTrackingList
            // 
            this.ImageTrackingList.FormattingEnabled = true;
            this.ImageTrackingList.ItemHeight = 20;
            this.ImageTrackingList.Location = new System.Drawing.Point(9, 141);
            this.ImageTrackingList.Name = "ImageTrackingList";
            this.ImageTrackingList.Size = new System.Drawing.Size(355, 124);
            this.ImageTrackingList.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.AnswerKeyField);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(390, 318);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Answer Key";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // AnswerKeyField
            // 
            this.AnswerKeyField.Location = new System.Drawing.Point(10, 36);
            this.AnswerKeyField.Name = "AnswerKeyField";
            this.AnswerKeyField.Size = new System.Drawing.Size(360, 26);
            this.AnswerKeyField.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Answer Key (not required)";
            // 
            // SuccessMessage
            // 
            this.SuccessMessage.AutoSize = true;
            this.SuccessMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SuccessMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SuccessMessage.Location = new System.Drawing.Point(20, 444);
            this.SuccessMessage.Name = "SuccessMessage";
            this.SuccessMessage.Size = new System.Drawing.Size(72, 22);
            this.SuccessMessage.TabIndex = 31;
            this.SuccessMessage.Text = "Success";
            // 
            // QuestionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 478);
            this.Controls.Add(this.SuccessMessage);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "QuestionEditor";
            this.Text = "QuestionEditor";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ContentField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DifficultyPicker;
        private System.Windows.Forms.ComboBox TopicPicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AnswerField;
        private System.Windows.Forms.CheckBox MultipleChoiceCheckbox;
        private System.Windows.Forms.Label IncorrectAnswersLabel;
        private System.Windows.Forms.TextBox IncorrectAnswersField;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox ImageTrackingList;
        private System.Windows.Forms.Button RemoveImageButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button UploadImageButton;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox AnswerKeyField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label SuccessMessage;
    }
}