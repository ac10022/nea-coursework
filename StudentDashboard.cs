using nea_ui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_backend
{
    /// <summary>
    /// A form to act as the homepage for students: students can view their details and go to the other parts of the program
    /// </summary>
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();

            DatabaseHelper dbh = new DatabaseHelper();

            // load logged in student details
            ClassesLabel.Text = $"Classes: {string.Join(", ", dbh.GetClassesOfStudent(Program.loggedInUser).Select(x => x.ClassName))}";
            NameLabel.Text = $"Name: {Program.loggedInUser.FirstName} {Program.loggedInUser.Surname}";
        }

        /// <summary>
        /// Hides this form, opens the independent practice menu, then shows this form again once that form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToIndependentPracticeMenu(object sender, EventArgs e)
        {
            Hide();
            IndependentPracticeMenu ipm = new IndependentPracticeMenu();

            // form closed events
            ipm.Closed += (s, args) =>
            {
                Show();
            };
            ipm.Show();
        }

        /// <summary>
        /// Closes the dashboard and logs the user out: redirects to the login form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogoutFromHere(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Hides this form, opens the student assignments menu, then shows this form again once that form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToAssignments(object sender, EventArgs e)
        {
            Hide();
            StudentAssignmentMenu sam = new StudentAssignmentMenu();

            // form closed events
            sam.Closed += (s, args) =>
            {
                Show();
            };
            sam.Show();
        }

        /// <summary>
        /// Hides this form, opens the scheme of work tracker menu, then shows this form again once that form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToSchemeOfWork(object sender, EventArgs e)
        {
            Hide();
            SchemeOfWorkTracker sowt = new SchemeOfWorkTracker();

            // form closed events
            sowt.Closed += (s, args) =>
            {
                Show();
            };
            sowt.Show();
        }
    }
}
