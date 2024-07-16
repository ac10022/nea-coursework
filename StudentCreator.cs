using nea_ui_testing;
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
        private User studentRef;
        public StudentCreator(User studentRef = null)
        {
            InitializeComponent();
            SubmitButton.Enabled = false;
            SuccessMessage.Visible = false;

            if (studentRef != null)
            {
                this.studentRef = studentRef;
                FirstnameInput.Text = studentRef.FirstName;
                LastnameInput.Text = studentRef.Surname;
                EmailInput.Text = studentRef.Email;
            }
        }

        private void UserSubmit(object sender, EventArgs e)
        {
            try
            {
                Hide();
                ConfirmationForm cf = new ConfirmationForm($"Are you sure you want to create student {FirstnameInput.Text} {LastnameInput.Text}?");
                bool wasSuccess = false;

                // form closed events
                cf.FormClosing += (s, args) =>
                {
                    wasSuccess = cf.wasSuccess;
                };
                cf.Closed += (s, args) =>
                {
                    Show();
                    if (wasSuccess)
                    {
                        HashingHelper hh = new HashingHelper();
                        (string salt, string hashedPassword) = hh.ComputeSaltAndHash(PasswordInput.Text);
                        DatabaseHelper dbh = new DatabaseHelper();
                        if (studentRef == null)
                        {
                            dbh.CreateNewStudent(FirstnameInput.Text, LastnameInput.Text, EmailInput.Text, hashedPassword, salt);
                            SuccessMessage.Visible = true;
                            SuccessMessage.Text = $"Successfully created student: {FirstnameInput.Text} {LastnameInput.Text}";
                        }
                        else
                        {
                            dbh.EditStudentDetails(studentRef, FirstnameInput.Text, LastnameInput.Text, EmailInput.Text, hashedPassword, salt);
                            SuccessMessage.Visible = true;
                            SuccessMessage.Text = $"Successfully edited student";
                        }
                    }
                };
                cf.Show();
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
