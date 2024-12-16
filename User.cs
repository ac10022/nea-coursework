using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace nea_prototype_full
{
    public enum _UserType
    {
        Teacher,
        Student
    }
    
    public class User
    {
        // fields
        protected int id;
        protected string firstName;
        protected string surname;
        protected string email;
        protected _UserType userType;

        // properties
        public int Id { get { return id; } }
        public string FirstName { get { return firstName; } }
        public string Surname { get { return surname; } }
        public string Email { get { return email; } }
        public _UserType UserType { get { return userType; } }

        // constructor
        public User(int userId, string firstName, string surname, string email, _UserType userType)
        {
            this.id = userId;
            this.firstName = firstName;
            this.surname = surname;
            this.email = email;
            this.userType = userType;
        }
    }

    public class StudentImportLayout : User
    {
        // fields
        private string password;

        // properties
        public string Password { get { return password; } private set { password = value; } }

        // constructor
        public StudentImportLayout(string firstName, string surname, string email, string password) : base(-1, firstName, surname, email, _UserType.Student)
        {
            this.password = password;
        }

        /// <summary>
        /// A method which ensures that a student being imported into the program has sanitised data.
        /// </summary>
        /// <returns>A bool which determines whether to accept or reject the user (dependent on the data given)</returns>
        public bool ValidateStudent()
        {
            // omit if any field is empty
            if (firstName.Length == 0 || surname.Length == 0 || email.Length == 0 || password.Length == 0) return false;

            // entries with a first/last name containing non-alphabetic characters should be sanitised using Regex
            firstName = Regex.Replace(firstName, @"[^a-zA-z]", "");
            surname = Regex.Replace(surname, @"[^a-zA-z]", "");

            // entries with an email which does not contain an ‘@’ or ‘.’ should be omitted
            if (!email.Contains("@") || !email.Contains(".")) return false;

            // the student password must meet the criteria: at least 8 characters long, at least one capital letter, at least one number, no non-ASCII symbols; entries which do not pass these criteria should be omitted
            if (password.Length <= 8) return false;
            if (Regex.Matches(password, @"[A-Z]").Count == 0) return false;
            if (Regex.Matches(password, @"[0-9]").Count == 0) return false;
            if (password.Any(c => c > 127)) return false;

            // entries where a field contains more characters than specified in the data dictionary should be omitted
            if (firstName.Length > 50) return false;
            if (surname.Length > 50) return false;
            if (email.Length > 100) return false;
            if (password.Length > 64) return false;

            // if meets all criteria, return true
            return true;
        }

        public override string ToString()
        {
            return $"{firstName}, {surname}, {email}, {password}";
        }

    }
}

