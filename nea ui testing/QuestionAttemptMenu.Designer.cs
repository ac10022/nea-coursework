namespace nea_ui_testing
{
    partial class QuestionAttemptMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionAttemptMenu));
            this.DashboardButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.DifficultyLabel = new System.Windows.Forms.Label();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.TopicLabel = new System.Windows.Forms.Label();
            this.MCALabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.MCA_A = new System.Windows.Forms.RadioButton();
            this.MCA_B = new System.Windows.Forms.RadioButton();
            this.MCA_D = new System.Windows.Forms.RadioButton();
            this.MCA_C = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.FILabel = new System.Windows.Forms.Label();
            this.FI_FIELD1 = new System.Windows.Forms.Label();
            this.FI_1 = new System.Windows.Forms.TextBox();
            this.FI_2 = new System.Windows.Forms.TextBox();
            this.FI_FIELD2 = new System.Windows.Forms.Label();
            this.FI_4 = new System.Windows.Forms.TextBox();
            this.FI_FIELD4 = new System.Windows.Forms.Label();
            this.FI_3 = new System.Windows.Forms.TextBox();
            this.FI_FIELD3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.QuestionContentBox = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ImageBox = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.DisplayImageButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DashboardButton
            // 
            this.DashboardButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.DashboardButton.Location = new System.Drawing.Point(794, 21);
            this.DashboardButton.Name = "DashboardButton";
            this.DashboardButton.Size = new System.Drawing.Size(240, 43);
            this.DashboardButton.TabIndex = 24;
            this.DashboardButton.Text = "Back to dashboard";
            this.DashboardButton.UseVisualStyleBackColor = false;
            this.DashboardButton.Click += new System.EventHandler(this.GoBackToDashboard);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AuthorLabel);
            this.groupBox1.Controls.Add(this.DifficultyLabel);
            this.groupBox1.Controls.Add(this.SubjectLabel);
            this.groupBox1.Controls.Add(this.TopicLabel);
            this.groupBox1.Location = new System.Drawing.Point(24, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 99);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Question information";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(211, 61);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(141, 20);
            this.AuthorLabel.TabIndex = 29;
            this.AuthorLabel.Text = "Author: [AUTHOR]";
            // 
            // DifficultyLabel
            // 
            this.DifficultyLabel.AutoSize = true;
            this.DifficultyLabel.Location = new System.Drawing.Point(211, 29);
            this.DifficultyLabel.Name = "DifficultyLabel";
            this.DifficultyLabel.Size = new System.Drawing.Size(179, 20);
            this.DifficultyLabel.TabIndex = 28;
            this.DifficultyLabel.Text = "Difficulty: [DIFFICULTY]";
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Location = new System.Drawing.Point(9, 61);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(152, 20);
            this.SubjectLabel.TabIndex = 27;
            this.SubjectLabel.Text = "Subject: [SUBJECT]";
            // 
            // TopicLabel
            // 
            this.TopicLabel.AutoEllipsis = true;
            this.TopicLabel.Location = new System.Drawing.Point(9, 29);
            this.TopicLabel.MaximumSize = new System.Drawing.Size(190, 50);
            this.TopicLabel.Name = "TopicLabel";
            this.TopicLabel.Size = new System.Drawing.Size(190, 26);
            this.TopicLabel.TabIndex = 26;
            this.TopicLabel.Text = "Topic: [TOPIC]";
            // 
            // MCALabel
            // 
            this.MCALabel.AccessibleDescription = "MULTIPLE_CHOICE";
            this.MCALabel.AutoSize = true;
            this.MCALabel.Location = new System.Drawing.Point(20, 464);
            this.MCALabel.Name = "MCALabel";
            this.MCALabel.Size = new System.Drawing.Size(113, 20);
            this.MCALabel.TabIndex = 27;
            this.MCALabel.Text = "Select answer:";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(794, 530);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(240, 36);
            this.SubmitButton.TabIndex = 29;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitEvent);
            // 
            // MCA_A
            // 
            this.MCA_A.AccessibleDescription = "MULTIPLE_CHOICE";
            this.MCA_A.AutoSize = true;
            this.MCA_A.Location = new System.Drawing.Point(24, 496);
            this.MCA_A.Name = "MCA_A";
            this.MCA_A.Size = new System.Drawing.Size(141, 24);
            this.MCA_A.TabIndex = 30;
            this.MCA_A.TabStop = true;
            this.MCA_A.Text = "A: [ANSWER1]";
            this.MCA_A.UseVisualStyleBackColor = true;
            this.MCA_A.CheckedChanged += new System.EventHandler(this.TestForData);
            // 
            // MCA_B
            // 
            this.MCA_B.AccessibleDescription = "MULTIPLE_CHOICE";
            this.MCA_B.AutoSize = true;
            this.MCA_B.Location = new System.Drawing.Point(322, 496);
            this.MCA_B.Name = "MCA_B";
            this.MCA_B.Size = new System.Drawing.Size(141, 24);
            this.MCA_B.TabIndex = 31;
            this.MCA_B.TabStop = true;
            this.MCA_B.Text = "B: [ANSWER2]";
            this.MCA_B.UseVisualStyleBackColor = true;
            this.MCA_B.CheckedChanged += new System.EventHandler(this.TestForData);
            // 
            // MCA_D
            // 
            this.MCA_D.AccessibleDescription = "MULTIPLE_CHOICE";
            this.MCA_D.AutoSize = true;
            this.MCA_D.Location = new System.Drawing.Point(322, 530);
            this.MCA_D.Name = "MCA_D";
            this.MCA_D.Size = new System.Drawing.Size(142, 24);
            this.MCA_D.TabIndex = 33;
            this.MCA_D.TabStop = true;
            this.MCA_D.Text = "D: [ANSWER4]";
            this.MCA_D.UseVisualStyleBackColor = true;
            this.MCA_D.CheckedChanged += new System.EventHandler(this.TestForData);
            // 
            // MCA_C
            // 
            this.MCA_C.AccessibleDescription = "MULTIPLE_CHOICE";
            this.MCA_C.AutoSize = true;
            this.MCA_C.Location = new System.Drawing.Point(24, 530);
            this.MCA_C.Name = "MCA_C";
            this.MCA_C.Size = new System.Drawing.Size(141, 24);
            this.MCA_C.TabIndex = 32;
            this.MCA_C.TabStop = true;
            this.MCA_C.Text = "C: [ANSWER3]";
            this.MCA_C.UseVisualStyleBackColor = true;
            this.MCA_C.CheckedChanged += new System.EventHandler(this.TestForData);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(607, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 425);
            this.panel1.TabIndex = 34;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(607, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 34);
            this.button3.TabIndex = 35;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // FILabel
            // 
            this.FILabel.AccessibleDescription = "FREE_INPUT";
            this.FILabel.AutoSize = true;
            this.FILabel.Location = new System.Drawing.Point(20, 422);
            this.FILabel.Name = "FILabel";
            this.FILabel.Size = new System.Drawing.Size(125, 20);
            this.FILabel.TabIndex = 36;
            this.FILabel.Text = "Enter answer(s):";
            // 
            // FI_FIELD1
            // 
            this.FI_FIELD1.AccessibleDescription = "FREE_INPUT";
            this.FI_FIELD1.AutoSize = true;
            this.FI_FIELD1.Location = new System.Drawing.Point(22, 455);
            this.FI_FIELD1.Name = "FI_FIELD1";
            this.FI_FIELD1.Size = new System.Drawing.Size(73, 20);
            this.FI_FIELD1.TabIndex = 37;
            this.FI_FIELD1.Text = "[FIELD1]";
            // 
            // FI_1
            // 
            this.FI_1.AccessibleDescription = "FREE_INPUT";
            this.FI_1.Location = new System.Drawing.Point(26, 478);
            this.FI_1.Name = "FI_1";
            this.FI_1.Size = new System.Drawing.Size(202, 26);
            this.FI_1.TabIndex = 38;
            this.FI_1.TextChanged += new System.EventHandler(this.TestForData);
            // 
            // FI_2
            // 
            this.FI_2.AccessibleDescription = "FREE_INPUT";
            this.FI_2.Location = new System.Drawing.Point(322, 478);
            this.FI_2.Name = "FI_2";
            this.FI_2.Size = new System.Drawing.Size(202, 26);
            this.FI_2.TabIndex = 40;
            this.FI_2.TextChanged += new System.EventHandler(this.TestForData);
            // 
            // FI_FIELD2
            // 
            this.FI_FIELD2.AccessibleDescription = "FREE_INPUT";
            this.FI_FIELD2.AutoSize = true;
            this.FI_FIELD2.Location = new System.Drawing.Point(318, 455);
            this.FI_FIELD2.Name = "FI_FIELD2";
            this.FI_FIELD2.Size = new System.Drawing.Size(73, 20);
            this.FI_FIELD2.TabIndex = 39;
            this.FI_FIELD2.Text = "[FIELD2]";
            // 
            // FI_4
            // 
            this.FI_4.AccessibleDescription = "FREE_INPUT";
            this.FI_4.Location = new System.Drawing.Point(322, 529);
            this.FI_4.Name = "FI_4";
            this.FI_4.Size = new System.Drawing.Size(202, 26);
            this.FI_4.TabIndex = 44;
            this.FI_4.TextChanged += new System.EventHandler(this.TestForData);
            // 
            // FI_FIELD4
            // 
            this.FI_FIELD4.AccessibleDescription = "FREE_INPUT";
            this.FI_FIELD4.AutoSize = true;
            this.FI_FIELD4.Location = new System.Drawing.Point(318, 507);
            this.FI_FIELD4.Name = "FI_FIELD4";
            this.FI_FIELD4.Size = new System.Drawing.Size(73, 20);
            this.FI_FIELD4.TabIndex = 43;
            this.FI_FIELD4.Text = "[FIELD4]";
            // 
            // FI_3
            // 
            this.FI_3.AccessibleDescription = "FREE_INPUT";
            this.FI_3.Location = new System.Drawing.Point(26, 530);
            this.FI_3.Name = "FI_3";
            this.FI_3.Size = new System.Drawing.Size(202, 26);
            this.FI_3.TabIndex = 42;
            this.FI_3.TextChanged += new System.EventHandler(this.TestForData);
            // 
            // FI_FIELD3
            // 
            this.FI_FIELD3.AccessibleDescription = "FREE_INPUT";
            this.FI_FIELD3.AutoSize = true;
            this.FI_FIELD3.Location = new System.Drawing.Point(22, 507);
            this.FI_FIELD3.Name = "FI_FIELD3";
            this.FI_FIELD3.Size = new System.Drawing.Size(73, 20);
            this.FI_FIELD3.TabIndex = 41;
            this.FI_FIELD3.Text = "[FIELD3]";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(24, 126);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(550, 316);
            this.tabControl1.TabIndex = 45;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.QuestionContentBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(542, 283);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Question";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // QuestionContentBox
            // 
            this.QuestionContentBox.AutoSize = true;
            this.QuestionContentBox.Location = new System.Drawing.Point(6, 3);
            this.QuestionContentBox.MaximumSize = new System.Drawing.Size(530, 0);
            this.QuestionContentBox.Name = "QuestionContentBox";
            this.QuestionContentBox.Size = new System.Drawing.Size(528, 220);
            this.QuestionContentBox.TabIndex = 46;
            this.QuestionContentBox.Text = resources.GetString("QuestionContentBox.Text");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DisplayImageButton);
            this.tabPage2.Controls.Add(this.ImageBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(542, 283);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Image(s)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ImageBox
            // 
            this.ImageBox.AutoScroll = true;
            this.ImageBox.Location = new System.Drawing.Point(9, 54);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(525, 525);
            this.ImageBox.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // DisplayImageButton
            // 
            this.DisplayImageButton.Location = new System.Drawing.Point(9, 6);
            this.DisplayImageButton.Name = "DisplayImageButton";
            this.DisplayImageButton.Size = new System.Drawing.Size(186, 42);
            this.DisplayImageButton.TabIndex = 1;
            this.DisplayImageButton.Text = "Display large image";
            this.DisplayImageButton.UseVisualStyleBackColor = true;
            this.DisplayImageButton.Click += new System.EventHandler(this.DisplayLargeImageEvent);
            // 
            // QuestionAttemptMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 581);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.FI_4);
            this.Controls.Add(this.FI_FIELD4);
            this.Controls.Add(this.FI_3);
            this.Controls.Add(this.FI_FIELD3);
            this.Controls.Add(this.FI_2);
            this.Controls.Add(this.FI_FIELD2);
            this.Controls.Add(this.FI_1);
            this.Controls.Add(this.FI_FIELD1);
            this.Controls.Add(this.FILabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MCA_D);
            this.Controls.Add(this.MCA_C);
            this.Controls.Add(this.MCA_B);
            this.Controls.Add(this.MCA_A);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.MCALabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DashboardButton);
            this.Name = "QuestionAttemptMenu";
            this.Text = "QuestionAttemptMenu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DashboardButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label SubjectLabel;
        private System.Windows.Forms.Label TopicLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label DifficultyLabel;
        private System.Windows.Forms.Label MCALabel;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.RadioButton MCA_A;
        private System.Windows.Forms.RadioButton MCA_B;
        private System.Windows.Forms.RadioButton MCA_D;
        private System.Windows.Forms.RadioButton MCA_C;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label FILabel;
        private System.Windows.Forms.Label FI_FIELD1;
        private System.Windows.Forms.TextBox FI_1;
        private System.Windows.Forms.TextBox FI_2;
        private System.Windows.Forms.Label FI_FIELD2;
        private System.Windows.Forms.TextBox FI_4;
        private System.Windows.Forms.Label FI_FIELD4;
        private System.Windows.Forms.TextBox FI_3;
        private System.Windows.Forms.Label FI_FIELD3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label QuestionContentBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel ImageBox;
        private System.Windows.Forms.Button DisplayImageButton;
    }
}