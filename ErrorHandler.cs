using nea_ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nea_backend
{
    // class for cleaner exception handling, if an exception does not crash the program, it will be displayed in the error box instead
    internal class ErrorHandler
    {
        string exceptionMessage;

        public ErrorHandler(string exceptionMessage)
        {
            this.exceptionMessage = exceptionMessage;
        }

        public void DisplayErrorForm()
        {
            ErrorForm errorForm = new ErrorForm(exceptionMessage);
            errorForm.Show();
        }
    }
}
