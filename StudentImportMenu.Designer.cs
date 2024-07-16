namespace nea_prototype_full
{
    partial class StudentImportMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentImportMenu));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UploadButton = new System.Windows.Forms.Button();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(25, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(368, 44);
            this.label2.TabIndex = 2;
            this.label2.Text = "Import students";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 84);
            this.label1.MaximumSize = new System.Drawing.Size(380, 200);
            this.label1.MinimumSize = new System.Drawing.Size(380, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 200);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // UploadButton
            // 
            this.UploadButton.Location = new System.Drawing.Point(25, 287);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(173, 48);
            this.UploadButton.TabIndex = 4;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadEvent);
            // 
            // OFD
            // 
            this.OFD.FileName = "OFD";
            // 
            // StudentImportMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 362);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "StudentImportMenu";
            this.Text = "StudentImportMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.OpenFileDialog OFD;
    }
}