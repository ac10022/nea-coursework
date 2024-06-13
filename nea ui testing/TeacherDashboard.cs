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
    }
}
