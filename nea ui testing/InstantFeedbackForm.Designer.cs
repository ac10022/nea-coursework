namespace nea_ui_testing
{
    partial class InstantFeedbackForm
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
            this.ContinueButton = new System.Windows.Forms.Button();
            this.FeedbackMessage = new System.Windows.Forms.Label();
            this.CorrectnessLabel = new System.Windows.Forms.Label();
            this.AnswerKeyBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ContinueButton
            // 
            this.ContinueButton.Location = new System.Drawing.Point(27, 311);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(112, 41);
            this.ContinueButton.TabIndex = 7;
            this.ContinueButton.Text = "Continue";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueEvent);
            // 
            // FeedbackMessage
            // 
            this.FeedbackMessage.AutoSize = true;
            this.FeedbackMessage.Location = new System.Drawing.Point(23, 88);
            this.FeedbackMessage.MaximumSize = new System.Drawing.Size(350, 40);
            this.FeedbackMessage.MinimumSize = new System.Drawing.Size(350, 40);
            this.FeedbackMessage.Name = "FeedbackMessage";
            this.FeedbackMessage.Size = new System.Drawing.Size(350, 40);
            this.FeedbackMessage.TabIndex = 6;
            this.FeedbackMessage.Text = "Your answer [ANSWER] was incorrect.\r\nThe actual answer was [ACTUALANSWER].\r\n";
            // 
            // CorrectnessLabel
            // 
            this.CorrectnessLabel.AutoSize = true;
            this.CorrectnessLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.CorrectnessLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CorrectnessLabel.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CorrectnessLabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.CorrectnessLabel.Location = new System.Drawing.Point(27, 30);
            this.CorrectnessLabel.Name = "CorrectnessLabel";
            this.CorrectnessLabel.Size = new System.Drawing.Size(237, 44);
            this.CorrectnessLabel.TabIndex = 5;
            this.CorrectnessLabel.Text = "Incorrect!";
            // 
            // AnswerKeyBox
            // 
            this.AnswerKeyBox.AutoSize = true;
            this.AnswerKeyBox.Location = new System.Drawing.Point(23, 148);
            this.AnswerKeyBox.MaximumSize = new System.Drawing.Size(350, 150);
            this.AnswerKeyBox.MinimumSize = new System.Drawing.Size(350, 150);
            this.AnswerKeyBox.Name = "AnswerKeyBox";
            this.AnswerKeyBox.Size = new System.Drawing.Size(350, 150);
            this.AnswerKeyBox.TabIndex = 8;
            this.AnswerKeyBox.Text = "Marking Scheme:\r\n[1] for expanding brackets:\r\n2(x+2) = 0 -> 2x+4 = 0\r\n[1] for sim" +
    "plifying expression:\r\n2x+4 = 0 -> 2x = -4\r\n[1] for simplifying expression:\r\n2x =" +
    " -4 -> x = -2";
            // 
            // InstantFeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 381);
            this.Controls.Add(this.AnswerKeyBox);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.FeedbackMessage);
            this.Controls.Add(this.CorrectnessLabel);
            this.Name = "InstantFeedbackForm";
            this.Text = "InstantFeedbackForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.Label FeedbackMessage;
        private System.Windows.Forms.Label CorrectnessLabel;
        private System.Windows.Forms.Label AnswerKeyBox;
    }
}