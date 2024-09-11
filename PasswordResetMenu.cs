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

        private void GoBack(object sender, EventArgs e)
        {
            Close();
        }

        private void SendConfirmationEvent(object sender, EventArgs e)
        {
            if (!ValidateEmail(EmailField.Text)) throw new Exception("Email is in an invalid format.");

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

        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            // email regex catcher
            if (!(new Regex(@"[\w.]+@\w+.[\w.]+").IsMatch(email))) return false;
            return true;
        }

        private int GenerateOneTimeCode()
        {
            return new Random().Next(100000, 1000000);
        }

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

        private void FieldChanged(object sender, EventArgs e)
        {
            SubmitButton.Enabled = TestForData();
        }

        private void SubmitEvent(object sender, EventArgs e)
        {
            // if code is correct
            try
            {
                if (int.Parse(CodeField.Text) == oneTimeCode)
                {
                    DatabaseHelper dbh = new DatabaseHelper();
                    HashingHelper hh = new HashingHelper();
                    (string salt, string hashedPassword) = hh.ComputeSaltAndHash(NewPasswordField.Text);

                    if (userType == _UserType.Student)
                    {
                        User student = dbh.GetStudentByEmail(EmailField.Text);
                        dbh.EditStudentDetails(student, student.FirstName, student.Surname, student.Email, hashedPassword, salt);

                    }
                    else if (userType == _UserType.Teacher)
                    {
                        User teacher = dbh.GetTeacherByEmail(EmailField.Text);
                        dbh.EditTeacherDetails(teacher, teacher.FirstName, teacher.Surname, teacher.Email, hashedPassword, salt);
                    }

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
