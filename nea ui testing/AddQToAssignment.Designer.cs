namespace nea_ui_testing
{
    partial class AddQToAssignment
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
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TopicPicker = new System.Windows.Forms.ComboBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.QuestionMatches = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AuthorPicker = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddQToAssignmentButton = new System.Windows.Forms.Button();
            this.DifficultyCheckbox4 = new System.Windows.Forms.CheckBox();
            this.DifficultyCheckbox3 = new System.Windows.Forms.CheckBox();
            this.DifficultyCheckbox2 = new System.Windows.Forms.CheckBox();
            this.DifficultyCheckbox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(188, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 60;
            this.label12.Text = "Difficulty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 55;
            this.label3.Text = "Topic";
            // 
            // TopicPicker
            // 
            this.TopicPicker.FormattingEnabled = true;
            this.TopicPicker.Location = new System.Drawing.Point(27, 164);
            this.TopicPicker.Name = "TopicPicker";
            this.TopicPicker.Size = new System.Drawing.Size(148, 28);
            this.TopicPicker.TabIndex = 54;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(27, 235);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(540, 33);
            this.SearchButton.TabIndex = 53;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchEvent);
            // 
            // QuestionMatches
            // 
            this.QuestionMatches.FormattingEnabled = true;
            this.QuestionMatches.ItemHeight = 20;
            this.QuestionMatches.Location = new System.Drawing.Point(27, 310);
            this.QuestionMatches.Name = "QuestionMatches";
            this.QuestionMatches.Size = new System.Drawing.Size(540, 184);
            this.QuestionMatches.TabIndex = 52;
            this.QuestionMatches.SelectedIndexChanged += new System.EventHandler(this.TestForSelectedQuestion);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 51;
            this.label5.Text = "Matches";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Authoring teacher";
            // 
            // AuthorPicker
            // 
            this.AuthorPicker.FormattingEnabled = true;
            this.AuthorPicker.Location = new System.Drawing.Point(312, 163);
            this.AuthorPicker.Name = "AuthorPicker";
            this.AuthorPicker.Size = new System.Drawing.Size(255, 28);
            this.AuthorPicker.TabIndex = 49;
            this.AuthorPicker.SelectedIndexChanged += new System.EventHandler(this.TestForData);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Rockwell Extra Bold", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(27, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 34);
            this.label2.TabIndex = 48;
            this.label2.Text = "Search for a question";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 44);
            this.label1.TabIndex = 47;
            this.label1.Text = "Add a question";
            // 
            // AddQToAssignmentButton
            // 
            this.AddQToAssignmentButton.Location = new System.Drawing.Point(27, 512);
            this.AddQToAssignmentButton.Name = "AddQToAssignmentButton";
            this.AddQToAssignmentButton.Size = new System.Drawing.Size(267, 36);
            this.AddQToAssignmentButton.TabIndex = 61;
            this.AddQToAssignmentButton.Text = "Add question to assignment";
            this.AddQToAssignmentButton.UseVisualStyleBackColor = true;
            this.AddQToAssignmentButton.Click += new System.EventHandler(this.AddQToAssignmentEvent);
            // 
            // DifficultyCheckbox4
            // 
            this.DifficultyCheckbox4.AutoSize = true;
            this.DifficultyCheckbox4.Location = new System.Drawing.Point(243, 195);
            this.DifficultyCheckbox4.Name = "DifficultyCheckbox4";
            this.DifficultyCheckbox4.Size = new System.Drawing.Size(44, 24);
            this.DifficultyCheckbox4.TabIndex = 65;
            this.DifficultyCheckbox4.Text = "4";
            this.DifficultyCheckbox4.UseVisualStyleBackColor = true;
            this.DifficultyCheckbox4.CheckedChanged += new System.EventHandler(this.TestForData);
            // 
            // DifficultyCheckbox3
            // 
            this.DifficultyCheckbox3.AutoSize = true;
            this.DifficultyCheckbox3.Location = new System.Drawing.Point(193, 195);
            this.DifficultyCheckbox3.Name = "DifficultyCheckbox3";
            this.DifficultyCheckbox3.Size = new System.Drawing.Size(44, 24);
            this.DifficultyCheckbox3.TabIndex = 64;
            this.DifficultyCheckbox3.Text = "3";
            this.DifficultyCheckbox3.UseVisualStyleBackColor = true;
            this.DifficultyCheckbox3.CheckedChanged += new System.EventHandler(this.TestForData);
            // 
            // DifficultyCheckbox2
            // 
            this.DifficultyCheckbox2.AutoSize = true;
            this.DifficultyCheckbox2.Location = new System.Drawing.Point(243, 165);
            this.DifficultyCheckbox2.Name = "DifficultyCheckbox2";
            this.DifficultyCheckbox2.Size = new System.Drawing.Size(44, 24);
            this.DifficultyCheckbox2.TabIndex = 63;
            this.DifficultyCheckbox2.Text = "2";
            this.DifficultyCheckbox2.UseVisualStyleBackColor = true;
            this.DifficultyCheckbox2.CheckedChanged += new System.EventHandler(this.TestForData);
            // 
            // DifficultyCheckbox1
            // 
            this.DifficultyCheckbox1.AutoSize = true;
            this.DifficultyCheckbox1.Location = new System.Drawing.Point(193, 165);
            this.DifficultyCheckbox1.Name = "DifficultyCheckbox1";
            this.DifficultyCheckbox1.Size = new System.Drawing.Size(44, 24);
            this.DifficultyCheckbox1.TabIndex = 62;
            this.DifficultyCheckbox1.Text = "1";
            this.DifficultyCheckbox1.UseVisualStyleBackColor = true;
            this.DifficultyCheckbox1.CheckedChanged += new System.EventHandler(this.TestForData);
            // 
            // AddQToAssignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 570);
            this.Controls.Add(this.DifficultyCheckbox4);
            this.Controls.Add(this.DifficultyCheckbox3);
            this.Controls.Add(this.DifficultyCheckbox2);
            this.Controls.Add(this.DifficultyCheckbox1);
            this.Controls.Add(this.AddQToAssignmentButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TopicPicker);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.QuestionMatches);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AuthorPicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddQToAssignment";
            this.Text = "AddQToAssignment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TopicPicker;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ListBox QuestionMatches;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AuthorPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddQToAssignmentButton;
        private System.Windows.Forms.CheckBox DifficultyCheckbox4;
        private System.Windows.Forms.CheckBox DifficultyCheckbox3;
        private System.Windows.Forms.CheckBox DifficultyCheckbox2;
        private System.Windows.Forms.CheckBox DifficultyCheckbox1;
    }
}