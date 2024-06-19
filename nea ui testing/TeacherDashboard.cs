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
    public partial class TeacherDashboard : Form
    {
        public TeacherDashboard()
        {
            InitializeComponent();
        }

        private void LogoutFromHere(object sender, EventArgs e)
        {
            Close();
        }

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
    }
}
