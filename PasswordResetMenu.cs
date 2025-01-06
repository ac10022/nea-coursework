using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_prototype_full
{
    /// <summary>
    /// A form through which the user can reset their password, by recieving an email and inputting a one-time code.
    /// </summary>
    public partial class PasswordResetMenu : Form
    {
        private int oneTimeCode;
        _UserType userType;

        public PasswordResetMenu(string email = null)
        {
            InitializeComponent();
            if (email != null) EmailField.Text = email;
            oneTimeCode = GenerateOneTimeCode();
        }

        /// <summary>
        /// A method to close this form and return to the log-in menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBack(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// On submit: check the email is valid and exists in the DB, using an SMTP client, email this user with a generated one time code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void SendConfirmationEvent(object sender, EventArgs e)
        {
            // check if this email matches the correct email format
            if (!ValidateEmail(EmailField.Text)) throw new Exception("Email is in an invalid format.");

            // create a SMTP client using the gmail SMTP service, from a predefined project email address.
            SmtpClient client = new SmtpClient(@"smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(@"neaproject4@gmail.com", @"vfct lfzn odvb ermc"),
                EnableSsl = true
            };

            string emailTo = EmailField.Text;

            DatabaseHelper dbh = new DatabaseHelper();
            try
            {
                // if email exists in database
                if (dbh.GetAllTeachers().Select(x => x.Email).Contains(emailTo))
                {
                    dbh.GetSaltFromEmail(emailTo, _UserType.Teacher);
                    userType = _UserType.Teacher;
                }
                else
                {
                    dbh.GetSaltFromEmail(emailTo, _UserType.Student);
                    userType = _UserType.Student;
                }

                // debugging / override email to send to
                emailTo = @"lucamorettam@gmail.com";
                // end debugging

                // send the user an email with the one time code as the email body
                client.Send(@"neaproject4@gmail.com", emailTo, "EMAIL VERIFICATION", $"Use code {oneTimeCode} to verify your email and reset your password.");

                //enable locked fields
                CodeField.Enabled = true;
                NewPasswordField.Enabled = true;
            }
            catch
            {
                ErrorHandler eh = new ErrorHandler("Email doesn't exist in database.");
                eh.DisplayErrorForm();
                return;
            }
        }

        /// <summary>
        /// A method to validate the email of the user, in the correct ____@____.____ format.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>A boolean: expressing whether the email is valid or not.</returns>
        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            // email regex catcher
            if (!(new Regex(@"[\w.]+@\w+.[\w.]+").IsMatch(email))) return false;
            return true;
        }

        /// <summary>
        /// A method to create a new one-time code.
        /// </summary>
        /// <returns>An integer from 100000-999999</returns>
        private int GenerateOneTimeCode()
        {
            return new Random().Next(100000, 1000000);
        }

        /// <summary>
        /// A method to test for whether the one-time code is present and the new password is "valid" for use in the program.
        /// </summary>
        /// <returns>A boolean: expressing whether the code is 6 characters long, integeric, and the password matches the specification of the program.</returns>
        private bool TestForData()
        {
            // code must be 6 chars long
            if (CodeField.TextLength != 6) return false;
            // if not an integer
            if (!int.TryParse(CodeField.Text, out int _)) return false;

            // the password must meet the criteria: at least 8 characters long, at least one capital letter, at least one number, no non-ASCII symbols; entries which do not pass these criteria should be omitted
            if (NewPasswordField.TextLength <= 8) return false;
            if (Regex.Matches(NewPasswordField.Text, @"[A-Z]").Count == 0) return false;
            if (Regex.Matches(NewPasswordField.Text, @"[0-9]").Count == 0) return false;
            if (NewPasswordField.Text.Any(c => c > 127)) return false;

            // password not longer than 64 characters
            if (NewPasswordField.TextLength > 64) return false;

            return true;
        }

        /// <summary>
        /// A method which changes the accessibility of the submit button to whether the fields have been filled in correctly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FieldChanged(object sender, EventArgs e)
        {
            SubmitButton.Enabled = TestForData();
        }

        /// <summary>
        /// On submit: if the code matches, edit the existing user in the database; change the existing password to a hashed version of the new password.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitEvent(object sender, EventArgs e)
        {
            // if code is correct
            try
            {
                if (int.Parse(CodeField.Text) == oneTimeCode)
                {
                    DatabaseHelper dbh = new DatabaseHelper();
                    HashingHelper hh = new HashingHelper();
                    
                    // compute salt and hash for the new password
                    (string salt, string hashedPassword) = hh.ComputeSaltAndHash(NewPasswordField.Text);

                    if (userType == _UserType.Student)
                    {
                        // edit student details in DB
                        User student = dbh.GetStudentByEmail(EmailField.Text);
                        dbh.EditStudentDetails(student, student.FirstName, student.Surname, student.Email, hashedPassword, salt);

                    }
                    else if (userType == _UserType.Teacher)
                    {
                        // edit teacher details in DB
                        User teacher = dbh.GetTeacherByEmail(EmailField.Text);
                        dbh.EditTeacherDetails(teacher, teacher.FirstName, teacher.Surname, teacher.Email, hashedPassword, salt);
                    }

                    // show a success message to notify that the password change has succeeded
                    SuccessMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }
    }
}
