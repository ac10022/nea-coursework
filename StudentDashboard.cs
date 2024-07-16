using nea_ui_testing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_prototype_full
{
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

        private void LogoutFromHere(object sender, EventArgs e)
        {
            Close();
        }

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
