using nea_prototype_full;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_ui_testing
{
    public partial class LoginForm : Form
    {
        private bool canLogIn = false;
        private bool canForgotPwd = false;
        public LoginForm()
        {
            InitializeComponent();

            // disable login button for now as fields are empty
            LoginButton.Enabled = false;
            ResetPasswordButton.Enabled = false;
            LoggedOutLabel.Visible = false;

            // FOR DEBUGGING
            EmailField.Text = @"udayjolly@gmail.com";
            PasswordField.Text = "Password123";
            //
        }

        private void AttemptLogin(object sender, EventArgs e)
        {
            try
            {
                // check whether they are attempting to log in as a student or teacher
                _UserType userType = TeacherRadioButton.Checked ? _UserType.Teacher : _UserType.Student;

                DatabaseHelper dbh = new DatabaseHelper();

                // get salt attached to given email
                string salt = dbh.GetSaltFromEmail(EmailField.Text, userType);
                HashingHelper hh = new HashingHelper();

                // find out what the hashed password would be for this password/salt combination
                string hashedPassword = hh.GetHashFromSaltAndPassword(PasswordField.Text, salt);

                // if hashed password matches, set user to global logged in user, otherwise an exception will be thrown
                Program.loggedInUser = dbh.GetUserFromSaltAndPassword(salt, hashedPassword, userType);

                // if a valid user
                if (Program.loggedInUser != null && Program.loggedInUser.UserType == _UserType.Teacher)
                {
                    // show teacher dashboard and hide this form
                    LoggedOutLabel.Visible = false;
                    Hide();
                    TeacherDashboard td = new TeacherDashboard();

                    // form closed events -> log out and clear fields on this form
                    td.Closed += (s, args) =>
                    {
                        LogOutEvent();
                        ClearFields();
                        Show();
                        LoggedOutLabel.Visible = true;
                    };
                    td.Show();
                }
                else if (Program.loggedInUser != null && Program.loggedInUser.UserType == _UserType.Student)
                {
                    // show teacher dashboard and hide this form
                    LoggedOutLabel.Visible = false;
                    Hide();
                    StudentDashboard sd = new StudentDashboard();

                    // form closed events -> log out and clear fields on this form
                    sd.Closed += (s, args) =>
                    {
                        LogOutEvent();
                        ClearFields();
                        Show();
                        LoggedOutLabel.Visible = true;
                    };
                    sd.Show();
                }

            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void CheckForData(object sender, EventArgs e)
        {
            // can only click log-in if fields are all filled
            canLogIn = EmailField.TextLength != 0 && PasswordField.TextLength != 0 && (StudentRadioButton.Checked || TeacherRadioButton.Checked);
            canForgotPwd = EmailField.TextLength != 0;

            if (canLogIn) LoginButton.Enabled = true;
            else LoginButton.Enabled = false;

            ResetPasswordButton.Enabled = canForgotPwd;
        }

        private void ClearFields()
        {
            EmailField.Text = string.Empty;
            PasswordField.Text = string.Empty;
            StudentRadioButton.Checked = false;
            TeacherRadioButton.Checked = false;
        }

        static void LogOutEvent()
        {
            Program.loggedInUser = null;
        }

        private void ResetPwdEvent(object sender, EventArgs e)
        {
            Hide();
            PasswordResetMenu prm = new PasswordResetMenu(EmailField.Text);

            // form closed events
            prm.Closed += (s, args) =>
            {
                Show();
            };
            prm.Show();
        }
    }
}
