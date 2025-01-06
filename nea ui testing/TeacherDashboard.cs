using nea_prototype_full;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_ui_testing
{
    /// <summary>
    /// A form to act as the homepage for students: students can view their details and go to the other parts of the program.
    /// </summary>
    public partial class TeacherDashboard : Form
    {
        public TeacherDashboard()
        {
            InitializeComponent();

            DatabaseHelper dbh = new DatabaseHelper();

            // load logged in teacher details
            ClassesLabel.Text = $"Classes: {string.Join(", ", dbh.GetClassesOfTeacher(Program.loggedInUser).Select(x => x.ClassName))}";
            NameLabel.Text = $"Name: {Program.loggedInUser.FirstName} {Program.loggedInUser.Surname}";
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
        /// Hides this form, opens the student management menu, then shows this form again once that form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToStudentManager(object sender, EventArgs e)
        {
            Hide();
            StudentManagementMenu smm = new StudentManagementMenu();

            // form closed events
            smm.Closed += (s, args) =>
            {
                Show();
            };
            smm.Show();
        }

        /// <summary>
        /// Hides this form, opens the class management menu, then shows this form again once that form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToClassManager(object sender, EventArgs e)
        {
            Hide();
            ClassManagementMenu cmm = new ClassManagementMenu();

            // form closed events
            cmm.Closed += (s, args) =>
            {
                Show();
            };
            cmm.Show();
        }

        /// <summary>
        /// Hides this form, opens the question management menu, then shows this form again once that form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToQuestionManager(object sender, EventArgs e)
        {
            Hide();
            QuestionManagement qmm = new QuestionManagement();

            // form closed events
            qmm.Closed += (s, args) =>
            {
                Show();
            };
            qmm.Show();
        }

        /// <summary>
        /// Hides this form, opens the assignment management menu, then shows this form again once that form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToAssignmentManager(object sender, EventArgs e)
        {
            Hide();
            AssignmentMenu am = new AssignmentMenu();

            // form closed events
            am.Closed += (s, args) =>
            {
                Show();
            };
            am.Show();
        }

        /// <summary>
        /// Hides this form, opens the teacher overview menu, then shows this form again once that form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToTeacherOverview(object sender, EventArgs e)
        {
            Hide();
            TeacherOverview to = new TeacherOverview();

            // form closed events
            to.Closed += (s, args) =>
            {
                Show();
            };
            to.Show();
        }

        /// <summary>
        /// Hides this form, opens the SOW management menu, then shows this form again once that form closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToSOWManager(object sender, EventArgs e)
        {
            Hide();
            SchemeOfWorkManager sowm = new SchemeOfWorkManager();

            // form closed events
            sowm.Closed += (s, args) =>
            {
                Show();
            };
            sowm.Show();
        }
    }
}
