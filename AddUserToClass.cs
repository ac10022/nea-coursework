using nea_backend;
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
    public partial class AddUserToClass : Form
    {
        private bool canSubmit = false;
        private bool canAdd = false;
        private Class classRef;
        private User[] users;
        public AddUserToClass(Class classRef = null)
        {
            InitializeComponent();
            SearchButton.Enabled = false;
            AddUserButton.Enabled = false;
            SuccessMessage.Visible = false;
            if (classRef != null)
            {
                AddUserButton.Text = $"Add selected user to: {classRef.ClassName}";
                this.classRef = classRef;
            }
        }

        private void TestForData(object sender, EventArgs e)
        {
            SuccessMessage.Visible = false;
            canSubmit = NameField.TextLength != 0;
            canAdd = UserList.SelectedIndex != -1;
            SearchButton.Enabled = canSubmit;
            AddUserButton.Enabled = canAdd;
        }

        private void SubmitSearch(object sender, EventArgs e)
        {
            try
            {
                DatabaseHelper dbh = new DatabaseHelper();
                users = dbh.GetStudentsByFirstName(NameField.Text).Concat(dbh.GetTeachersByFirstName(NameField.Text)).OrderBy(x => x.FirstName).ToArray();
                UserList.DataSource = users.Select(x => $"{x.UserType.ToString()}\t{x.FirstName} {x.Surname}").ToArray();
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void AddUserEvent(object sender, EventArgs e)
        {
            try
            {
                User selectedUser = users[UserList.SelectedIndex];
                DatabaseHelper dbh = new DatabaseHelper();
                if (selectedUser.UserType == _UserType.Student) dbh.AddStudentToClass(selectedUser, classRef);
                else dbh.AddTeacherToClass(selectedUser, classRef);
                SuccessMessage.Text = $"Successfully added {selectedUser.FirstName} {selectedUser.Surname} to {classRef.ClassName}";
                SuccessMessage.Visible = true;
            }
            catch
            {
                ErrorHandler eh = new ErrorHandler($"Unable to add this user to {classRef.ClassName}; this may be because this user is already in this class, or either the class or user no longer exists.");
                eh.DisplayErrorForm();
            }
        }
    }
}
