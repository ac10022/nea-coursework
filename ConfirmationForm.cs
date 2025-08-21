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
    public partial class ConfirmationForm : Form
    {
        public bool wasSuccess = false;

        public ConfirmationForm(string message = "")
        {
            InitializeComponent();
            ConfirmationMessage.Text = message;
        }

        private void Confirmed(object sender, EventArgs e)
        {
            wasSuccess = true;
            Close();
        }

        private void CloseForm(object sender, EventArgs e)
        {
            Close();
        }
    }
}
