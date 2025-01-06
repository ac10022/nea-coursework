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
    /// <summary>
    /// A form through which teachers can import a CSV of students, check these are suitable for the program, and create them automatically.
    /// </summary>
    public partial class StudentImportMenu : Form
    {
        private List<StudentImportLayout> acceptedStudents;
        private List<StudentImportLayout> rejectedStudents;

        private DatabaseHelper dbh = new DatabaseHelper();
        private HashingHelper hh = new HashingHelper();

        public StudentImportMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On upload: let the user locate the CSV file, if this is successful, read the CSV, use the student import helper to check each entry and parse the successful entries into the DB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadEvent(object sender, EventArgs e)
        {
            // use an open-file directory to allow the user to choose exclusively CSV files
            OFD.InitialDirectory = @"C:\";
            OFD.RestoreDirectory = true;
            OFD.Title = "Choose the student CSV file";
            OFD.DefaultExt = "csv";
            OFD.Filter = "CSV files (*.csv)|*.csv";

            OFD.CheckPathExists = true;
            OFD.CheckFileExists = true;
            
            // if file exists
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                // use student import helper to filter students to accept/reject
                StudentImportHelper sh = new StudentImportHelper(OFD.FileName);
                (acceptedStudents, rejectedStudents) = sh.ImportStudents();

                // accepted students
                foreach (StudentImportLayout student in acceptedStudents)
                {
                    // create a new salt and hashed password, then parse the data into the program
                    (string salt, string hashedPassword) = hh.ComputeSaltAndHash(student.Password);
                    dbh.CreateNewStudent(student.FirstName, student.Surname, student.Email, hashedPassword, salt);
                }

                // rejected students: build notice
                StringBuilder notice = new StringBuilder();
                notice.AppendLine($"Accepted {acceptedStudents.Count} students.");
                notice.AppendLine();
                
                if (rejectedStudents.Count != 0)
                {
                    notice.AppendLine($"Rejected the following {rejectedStudents.Count}:");
                    foreach (StudentImportLayout student in rejectedStudents)
                    {
                        notice.AppendLine(student.ToString());
                    }
                }

                // display notice in a message box
                MessageBox.Show(notice.ToString());
                Close();
            }
        }
    }
}
