using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private int id;
        private string firstName;
        private string surname;
        private string email;
        private _UserType userType;

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
}
