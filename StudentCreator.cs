using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_prototype_full
{
    public partial class StudentCreator : Form
    {
        private bool canCreate = false;
        public StudentCreator()
        {
            InitializeComponent();
            SubmitButton.Enabled = false;
            SuccessMessage.Visible = false;
        }

        private void UserSubmit(object sender, EventArgs e)
        {
            try
            {
                HashingHelper hh = new HashingHelper();
                (string salt, string hashedPassword) = hh.ComputeSaltAndHash(PasswordInput.Text);
                DatabaseHelper dbh = new DatabaseHelper();
                dbh.CreateNewStudent(FirstnameInput.Text, LastnameInput.Text, EmailInput.Text, hashedPassword, salt);
                SuccessMessage.Visible = true;
                SuccessMessage.Text = $"Successfully created student: {FirstnameInput.Text} {LastnameInput.Text}";
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void TestForData(object sender, EventArgs e)
        {
            // hide success message - new student being created
            SuccessMessage.Visible = false;
            // can only click log-in if fields are all filled
            canCreate = FirstnameInput.TextLength != 0 && LastnameInput.TextLength != 0 && EmailInput.TextLength != 0 && PasswordInput.TextLength != 0;
            // password and email validation
            if (canCreate)
            {
                // if email is in the form ___@___.___
                canCreate = Regex.IsMatch(EmailInput.Text, @".+@.+\..+", RegexOptions.None);
                // tests for: is longer than 8 characters, contains at least one capital letter, contains at least one number, contains no non-ascii symbols
                canCreate = PasswordInput.TextLength >= 8 && PasswordInput.Text.Count(x => (int)x >= 65 && (int)x <= 90) != 0 && Regex.Matches(PasswordInput.Text, @"[0-9]").Count != 0 && PasswordInput.Text.Count(x => (int)x >= 128) == 0;
            }
            if (canCreate) SubmitButton.Enabled = true;
            else SubmitButton.Enabled = false;
        }
    }
}
