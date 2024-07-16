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

        private void UploadEvent(object sender, EventArgs e)
        {
            OFD.InitialDirectory = @"C:\";
            OFD.RestoreDirectory = true;
            OFD.Title = "Choose the student CSV file";
            OFD.DefaultExt = "csv";
            OFD.Filter = "CSV files (*.csv)|*.csv";

            OFD.CheckPathExists = true;
            OFD.CheckFileExists = true;

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                StudentImportHelper sh = new StudentImportHelper(OFD.FileName);
                (acceptedStudents, rejectedStudents) = sh.ImportStudents();

                foreach (StudentImportLayout student in acceptedStudents)
                {
                    (string salt, string hashedPassword) = hh.ComputeSaltAndHash(student.Password);
                    dbh.CreateNewStudent(student.FirstName, student.Surname, student.Email, hashedPassword, salt);
                }

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

                MessageBox.Show(notice.ToString());
                Close();
            }
        }
    }
}
