using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_ui
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string errorMessage = "An error occured.")
        {
            InitializeComponent();
            ErrorDescription.Text = errorMessage;
        }

        private void ClearError(object sender, EventArgs e)
        {
            Close();
        }
    }
}
