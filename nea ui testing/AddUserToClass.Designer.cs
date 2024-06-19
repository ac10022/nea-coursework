namespace nea_ui_testing
{
    partial class AddUserToClass
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.UserList = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NameField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.SuccessMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(28, 151);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(382, 33);
            this.SearchButton.TabIndex = 16;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SubmitSearch);
            // 
            // UserList
            // 
            this.UserList.FormattingEnabled = true;
            this.UserList.ItemHeight = 20;
            this.UserList.Location = new System.Drawing.Point(28, 227);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(382, 104);
            this.UserList.TabIndex = 15;
            this.UserList.SelectedIndexChanged += new System.EventHandler(this.TestForData);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Matches";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Name";
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(28, 110);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(382, 26);
            this.NameField.TabIndex = 12;
            this.NameField.TextChanged += new System.EventHandler(this.TestForData);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 44);
            this.label1.TabIndex = 11;
            this.label1.Text = "Add user to class";
            // 
            // AddUserButton
            // 
            this.AddUserButton.Location = new System.Drawing.Point(28, 354);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(382, 61);
            this.AddUserButton.TabIndex = 17;
            this.AddUserButton.Text = "Add selected user to class: [CLASSNAME]";
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserEvent);
            // 
            // SuccessMessage
            // 
            this.SuccessMessage.AutoSize = true;
            this.SuccessMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SuccessMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SuccessMessage.Location = new System.Drawing.Point(28, 428);
            this.SuccessMessage.Name = "SuccessMessage";
            this.SuccessMessage.Size = new System.Drawing.Size(72, 22);
            this.SuccessMessage.TabIndex = 28;
            this.SuccessMessage.Text = "Success";
            // 
            // AddUserToClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 466);
            this.Controls.Add(this.SuccessMessage);
            this.Controls.Add(this.AddUserButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.UserList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.label1);
            this.Name = "AddUserToClass";
            this.Text = "AddStudentToClass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ListBox UserList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.Label SuccessMessage;
    }
}