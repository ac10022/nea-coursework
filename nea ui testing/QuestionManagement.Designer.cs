namespace nea_ui_testing
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
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
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
            this.DifficultyCheckbox1 = new System.Windows.Forms.CheckBox();
            this.DifficultyCheckbox2 = new System.Windows.Forms.CheckBox();
            this.DifficultyCheckbox4 = new System.Windows.Forms.CheckBox();
            this.DifficultyCheckbox3 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(792, 359);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(170, 43);
            this.button5.TabIndex = 39;
            this.button5.Text = "Delete question";
            this.button5.UseVisualStyleBackColor = true;
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(596, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 43);
            this.button2.TabIndex = 36;
            this.button2.Text = "Edit question";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(592, 323);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(311, 20);
            this.label11.TabIndex = 35;
            this.label11.Text = "Content preview: [TRUNCATEDCONTENT]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(592, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 20);
            this.label10.TabIndex = 34;
            this.label10.Text = "Difficulty: [DIFFICULTY]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(592, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "Author: [AUTHOR]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(592, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 20);
            this.label7.TabIndex = 32;
            this.label7.Text = "Subject: [SUBJECT]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(592, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 31;
            this.label8.Text = "Topic: [TOPIC]";
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
            // QuestionManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 518);
            this.Controls.Add(this.DifficultyCheckbox4);
            this.Controls.Add(this.DifficultyCheckbox3);
            this.Controls.Add(this.DifficultyCheckbox2);
            this.Controls.Add(this.DifficultyCheckbox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TopicPicker);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
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

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.CheckBox DifficultyCheckbox1;
        private System.Windows.Forms.CheckBox DifficultyCheckbox2;
        private System.Windows.Forms.CheckBox DifficultyCheckbox4;
        private System.Windows.Forms.CheckBox DifficultyCheckbox3;
    }
}