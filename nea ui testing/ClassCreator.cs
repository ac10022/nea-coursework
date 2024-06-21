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
    public partial class ClassCreator : Form
    {
        private bool canSubmit = false;
        private Class classRef;
        public ClassCreator(Class classRef = null)
        {
            InitializeComponent();
            SubmitButton.Enabled = false;
            SuccessMessage.Visible = false;

            if (classRef != null)
            {
                this.classRef = classRef;
                NameField.Text = classRef.ClassName;
            }
        }

        private void TestForData(object sender, EventArgs e)
        {
            SuccessMessage.Visible = false;
            canSubmit = NameField.TextLength != 0;
            SubmitButton.Enabled = canSubmit;
        }

        private void SubmitEvent(object sender, EventArgs e)
        {
            try
            {
                DatabaseHelper dbh = new DatabaseHelper();
                if (classRef == null)
                {   
                    dbh.CreateNewClass(NameField.Text);
                    SuccessMessage.Visible = true;
                    SuccessMessage.Text = $"Successfully created class: {NameField.Text}";
                }
                else
                {
                    dbh.ChangeClassName(classRef, NameField.Text);
                    SuccessMessage.Visible = true;
                    SuccessMessage.Text = $"Successfully changed class name from {classRef.ClassName} to {NameField.Text}";
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
