namespace nea_prototype_full
{
    partial class SchemeOfWorkManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.TopicList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ClassPicker = new System.Windows.Forms.ComboBox();
            this.SOWLabel = new System.Windows.Forms.Label();
            this.TopicPicker = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AddTopicButton = new System.Windows.Forms.Button();
            this.RemoveTopicButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.BackToDashboard = new System.Windows.Forms.Button();
            this.SuccessMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 44);
            this.label1.TabIndex = 48;
            this.label1.Text = "SOW Manager";
            // 
            // TopicList
            // 
            this.TopicList.FormattingEnabled = true;
            this.TopicList.ItemHeight = 20;
            this.TopicList.Location = new System.Drawing.Point(21, 107);
            this.TopicList.Name = "TopicList";
            this.TopicList.Size = new System.Drawing.Size(320, 324);
            this.TopicList.TabIndex = 49;
            this.TopicList.SelectedIndexChanged += new System.EventHandler(this.SOWTopicSelected);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(361, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Selected class";
            // 
            // ClassPicker
            // 
            this.ClassPicker.FormattingEnabled = true;
            this.ClassPicker.Location = new System.Drawing.Point(365, 107);
            this.ClassPicker.Name = "ClassPicker";
            this.ClassPicker.Size = new System.Drawing.Size(233, 28);
            this.ClassPicker.TabIndex = 51;
            // 
            // SOWLabel
            // 
            this.SOWLabel.AutoEllipsis = true;
            this.SOWLabel.AutoSize = true;
            this.SOWLabel.Location = new System.Drawing.Point(21, 81);
            this.SOWLabel.MaximumSize = new System.Drawing.Size(315, 20);
            this.SOWLabel.MinimumSize = new System.Drawing.Size(315, 20);
            this.SOWLabel.Name = "SOWLabel";
            this.SOWLabel.Size = new System.Drawing.Size(315, 20);
            this.SOWLabel.TabIndex = 52;
            this.SOWLabel.Text = "[CLASS]\'s SOW";
            // 
            // TopicPicker
            // 
            this.TopicPicker.FormattingEnabled = true;
            this.TopicPicker.Location = new System.Drawing.Point(365, 209);
            this.TopicPicker.Name = "TopicPicker";
            this.TopicPicker.Size = new System.Drawing.Size(233, 28);
            this.TopicPicker.TabIndex = 54;
            this.TopicPicker.SelectedIndexChanged += new System.EventHandler(this.TopicToAddChosen);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "Topics";
            // 
            // AddTopicButton
            // 
            this.AddTopicButton.Location = new System.Drawing.Point(365, 243);
            this.AddTopicButton.Name = "AddTopicButton";
            this.AddTopicButton.Size = new System.Drawing.Size(233, 40);
            this.AddTopicButton.TabIndex = 55;
            this.AddTopicButton.Text = "Add topic";
            this.AddTopicButton.UseVisualStyleBackColor = true;
            this.AddTopicButton.Click += new System.EventHandler(this.AddTopicEvent);
            // 
            // RemoveTopicButton
            // 
            this.RemoveTopicButton.Location = new System.Drawing.Point(365, 345);
            this.RemoveTopicButton.Name = "RemoveTopicButton";
            this.RemoveTopicButton.Size = new System.Drawing.Size(233, 40);
            this.RemoveTopicButton.TabIndex = 56;
            this.RemoveTopicButton.Text = "Remove selected topic";
            this.RemoveTopicButton.UseVisualStyleBackColor = true;
            this.RemoveTopicButton.Click += new System.EventHandler(this.RemoveTopicEvent);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(365, 391);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(233, 40);
            this.SaveButton.TabIndex = 57;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveEvent);
            // 
            // BackToDashboard
            // 
            this.BackToDashboard.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackToDashboard.Location = new System.Drawing.Point(365, 21);
            this.BackToDashboard.Name = "BackToDashboard";
            this.BackToDashboard.Size = new System.Drawing.Size(233, 43);
            this.BackToDashboard.TabIndex = 63;
            this.BackToDashboard.Text = "Back to dashboard";
            this.BackToDashboard.UseVisualStyleBackColor = false;
            this.BackToDashboard.Click += new System.EventHandler(this.GoBackToDashboard);
            // 
            // SuccessMessage
            // 
            this.SuccessMessage.AutoSize = true;
            this.SuccessMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SuccessMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SuccessMessage.Location = new System.Drawing.Point(365, 308);
            this.SuccessMessage.Name = "SuccessMessage";
            this.SuccessMessage.Size = new System.Drawing.Size(72, 22);
            this.SuccessMessage.TabIndex = 64;
            this.SuccessMessage.Text = "Success";
            // 
            // SchemeOfWorkManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 450);
            this.Controls.Add(this.SuccessMessage);
            this.Controls.Add(this.BackToDashboard);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.RemoveTopicButton);
            this.Controls.Add(this.AddTopicButton);
            this.Controls.Add(this.TopicPicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SOWLabel);
            this.Controls.Add(this.ClassPicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TopicList);
            this.Controls.Add(this.label1);
            this.Name = "SchemeOfWorkManager";
            this.Text = "SchemeOfWorkManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox TopicList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ClassPicker;
        private System.Windows.Forms.Label SOWLabel;
        private System.Windows.Forms.ComboBox TopicPicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button AddTopicButton;
        private System.Windows.Forms.Button RemoveTopicButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button BackToDashboard;
        private System.Windows.Forms.Label SuccessMessage;
    }
}