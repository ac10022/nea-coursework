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
    /// <summary>
    /// A form through which teachers can input the relevant data to create/modify a student.
    /// </summary>
    public partial class StudentCreator : Form
    {
        private bool canCreate = false;
        private User studentRef;
        public StudentCreator(User studentRef = null)
        {
            InitializeComponent();
            SubmitButton.Enabled = false;
            SuccessMessage.Visible = false;

            // if modifying a student: preload fields
            if (studentRef != null)
            {
                this.studentRef = studentRef;
                FirstnameInput.Text = studentRef.FirstName;
                LastnameInput.Text = studentRef.Surname;
                EmailInput.Text = studentRef.Email;
            }
        }

        /// <summary>
        /// On submit: confirm action, then hash new password and parse the new data into the database to create/modify the student.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserSubmit(object sender, EventArgs e)
        {
            try
            {
                Hide();
                // confirm action through confirmation form
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

                    // if the user confirmed the action
                    if (wasSuccess)
                    {
                        // hash the new plaintext password and create a salt
                        HashingHelper hh = new HashingHelper();
                        (string salt, string hashedPassword) = hh.ComputeSaltAndHash(PasswordInput.Text);
                        DatabaseHelper dbh = new DatabaseHelper();

                        // if creating a new student
                        if (studentRef == null)
                        {
                            dbh.CreateNewStudent(FirstnameInput.Text, LastnameInput.Text, EmailInput.Text, hashedPassword, salt);
                            
                            // show success message
                            SuccessMessage.Visible = true;
                            SuccessMessage.Text = $"Successfully created student: {FirstnameInput.Text} {LastnameInput.Text}";
                        }
                        // if editing a pre-existing student
                        else
                        {
                            dbh.EditStudentDetails(studentRef, FirstnameInput.Text, LastnameInput.Text, EmailInput.Text, hashedPassword, salt);

                            // show success message
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

        /// <summary>
        /// A method to test fields for data. Here: only allow data to be submitted if all fields are filled and password matches strength criteria.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestForData(object sender, EventArgs e)
        {
            // hide success message - new student being created
            SuccessMessage.Visible = false;
            // can only click log-in if fields are all filled
            // if email is in the form ___@___.___
            // tests for: is longer than 8 characters, contains at least one capital letter, contains at least one number, contains no non-ascii symbols
            canCreate = FirstnameInput.TextLength != 0 && LastnameInput.TextLength != 0 && EmailInput.TextLength != 0 && PasswordInput.TextLength >= 8 && PasswordInput.Text.Count(x => (int)x >= 65 && (int)x <= 90) != 0 && Regex.Matches(PasswordInput.Text, @"[0-9]").Count != 0 && PasswordInput.Text.Count(x => (int)x >= 128) == 0 && Regex.IsMatch(EmailInput.Text, @".+@.+\..+", RegexOptions.None);
            if (canCreate) SubmitButton.Enabled = true;
            else SubmitButton.Enabled = false;
        }
    }
}
