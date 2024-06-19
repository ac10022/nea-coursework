namespace nea_ui_testing
{
    partial class ClassCreator
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
            this.label3 = new System.Windows.Forms.Label();
            this.NameField = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
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
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 44);
            this.label1.TabIndex = 3;
            this.label1.Text = "Class editor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Class name";
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(21, 105);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(360, 26);
            this.NameField.TabIndex = 6;
            this.NameField.TextChanged += new System.EventHandler(this.TestForData);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(398, 22);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(134, 109);
            this.SubmitButton.TabIndex = 15;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitEvent);
            // 
            // SuccessMessage
            // 
            this.SuccessMessage.AutoSize = true;
            this.SuccessMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SuccessMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SuccessMessage.Location = new System.Drawing.Point(21, 146);
            this.SuccessMessage.Name = "SuccessMessage";
            this.SuccessMessage.Size = new System.Drawing.Size(72, 22);
            this.SuccessMessage.TabIndex = 27;
            this.SuccessMessage.Text = "Success";
            // 
            // ClassCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 185);
            this.Controls.Add(this.SuccessMessage);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.label1);
            this.Name = "ClassCreator";
            this.Text = "ClassCreator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label SuccessMessage;
    }
}