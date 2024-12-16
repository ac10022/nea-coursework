using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nea_prototype_full
{
    public class StudentImportHelper
    {
        private string path;

        public StudentImportHelper(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// A method, which given a path, parses in all student data from the given CSV file, validates this information, and forms a list of students to accept and students to reject into the system.
        /// </summary>
        /// <returns>A tuple: list of students to be accepted, list of students to be rejected.</returns>
        public (List<StudentImportLayout> students, List<StudentImportLayout> rejectedStudents) ImportStudents()
        {
            // open stream
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            List<StudentImportLayout> students = new List<StudentImportLayout>();
            List<StudentImportLayout> rejectedStudents = new List<StudentImportLayout>();

            while (!sr.EndOfStream)
            {
                // get and split record into components
                string currentStudent = sr.ReadLine();
                string[] parts = currentStudent.Split(',');

                // in the form: FirstName, LastName, Email, Password
                StudentImportLayout student = new StudentImportLayout(parts[0], parts[1], parts[2], parts[3]);

                // if succeeds validation, add to student list, otherwise add to rejected student list
                if (student.ValidateStudent()) students.Add(student);
                else rejectedStudents.Add(student);
            }

            // close file streams
            sr.Close();
            fs.Close();

            return (students, rejectedStudents);
        }
    }
}
