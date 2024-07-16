using nea_prototype_full;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_ui_testing
{
    public partial class ClassManagementMenu : Form
    {
        private bool canSubmit = false;
        private List<Class> foundClasses;

        private List<User> studentsInSelectedClass;
        private List<User> teachersInSelectedClass;
        private List<Assignment> selectedClassAssignments;

        private DatabaseHelper dbh = new DatabaseHelper();

        public ClassManagementMenu()
        {
            InitializeComponent();
            SearchForClassButton.Enabled = false;
            EditClassnameButton.Enabled = false;
            DeleteAssignmentButton.Enabled = false;
            SuccessMessage.Visible = false;
        }

        private void GoToClassCreatorMenu(object sender, EventArgs e)
        {
            Hide();
            ClassCreator cc = new ClassCreator();

            // form closed events
            cc.Closed += (s, args) =>
            {
                Show();
            };
            cc.Show();
        }

        private void SearchForClass(object sender, EventArgs e)
        {
            try
            {
                foundClasses = dbh.SearchForClasses(ClassNameFilter.Text);
                ClassListBox.DataSource = foundClasses.Select(x => $"{x.ClassId}\t{x.ClassName}").ToArray();
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void TestForData(object sender, EventArgs e)
        {
            SuccessMessage.Visible = false;
            canSubmit = ClassNameFilter.TextLength != 0;
            SearchForClassButton.Enabled = canSubmit;
        }

        private void NewClassSelected(object sender, EventArgs e)
        {
            try
            {
                Class selectedClass = foundClasses[(sender as ListBox).SelectedIndex];
                ClassnameLabel.Text = $"Name: {selectedClass.ClassName}";
                EditClassnameButton.Enabled = true;

                studentsInSelectedClass = dbh.GetStudentsInClass(selectedClass);
                teachersInSelectedClass = dbh.GetTeachersInClass(selectedClass);
                selectedClassAssignments = dbh.GetClassAssignments(selectedClass);

                StudentsInClass.DataSource = studentsInSelectedClass.Select(x => $"{x.FirstName} {x.Surname}").ToArray();
                StudentsInClass.ClearSelected();
                TeachersInClass.DataSource = teachersInSelectedClass.Select(x => $"{x.FirstName} {x.Surname}").ToArray();
                TeachersInClass.ClearSelected();
                AssignmentsListBox.DataSource = selectedClassAssignments.Select(x => $"{x.HomeworkName}\tdue {x.HomeworkDueDate}\t set by {x.Setter.FirstName} {x.Setter.Surname}").ToArray();
                AssignmentsListBox.ClearSelected();
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void GoToAddUserMenu(object sender, EventArgs e)
        {
            Hide();
            AddUserToClass autc = new AddUserToClass(foundClasses[ClassListBox.SelectedIndex]);

            // form closed events
            autc.Closed += (s, args) =>
            {
                Show();
                if (ClassNameFilter.TextLength != 0) SearchForClass(null, null);
                SuccessMessage.Visible = false;
            };
            autc.Show();
        }

        private void StudentChoiceChanged(object sender, EventArgs e)
        {
            if (TeachersInClass.SelectedIndex != -1 && StudentsInClass.SelectedIndex != -1) TeachersInClass.ClearSelected();
        }

        private void TeacherChoiceChanged(object sender, EventArgs e)
        {
            if (StudentsInClass.SelectedIndex != -1 && TeachersInClass.SelectedIndex != -1) StudentsInClass.ClearSelected();
        }

        private void RemoveUserEvent(object sender, EventArgs e)
        {
            try
            {
                Class selectedClass = foundClasses[ClassListBox.SelectedIndex];

                Hide();
                ConfirmationForm cf = new ConfirmationForm($"Are you sure you want to remove this user from {selectedClass.ClassName}?");
                bool wasSuccess = false;

                // form closed events
                cf.FormClosing += (s, args) =>
                {
                    wasSuccess = cf.wasSuccess;
                };
                cf.Closed += (s, args) =>
                {
                    if (wasSuccess)
                    {
                        if (StudentsInClass.SelectedIndex != -1)
                        {
                            User selectedStudent = studentsInSelectedClass[StudentsInClass.SelectedIndex];
                            dbh.RemoveStudentFromClass(selectedStudent, selectedClass);

                            SuccessMessage.Text = $"Removed {selectedStudent.FirstName} {selectedStudent.Surname} from selected class.";
                            SuccessMessage.Visible = true;
                        }
                        else
                        {
                            User selectedTeacher = teachersInSelectedClass[TeachersInClass.SelectedIndex];
                            dbh.RemoveTeacherFromClass(selectedTeacher, selectedClass);

                            SuccessMessage.Text = $"Removed {selectedTeacher.FirstName} {selectedTeacher.Surname} from selected class.";
                            SuccessMessage.Visible = true;
                        }

                        // refresh search
                        SearchForClass(null, null);
                    }
                    Show();
                };
                cf.Show();
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void ReturnToDashboard(object sender, EventArgs e)
        {
            Close();
        }

        private void EditClassNameEvent(object sender, EventArgs e)
        {
            Hide();
            ClassCreator cc = new ClassCreator(foundClasses[ClassListBox.SelectedIndex]);

            // form closed events
            cc.Closed += (s, args) =>
            {
                Show();
            };
            cc.Show();
        }

        private void DeleteAssignmentEvent(object sender, EventArgs e)
        {
            try
            {
                if (AssignmentsListBox.SelectedIndex != -1)
                {
                    Assignment selectedAssignment = selectedClassAssignments[AssignmentsListBox.SelectedIndex];

                    Hide();
                    ConfirmationForm cf = new ConfirmationForm($"Are you sure you want to delete this assignment: {selectedAssignment.HomeworkName}?");
                    bool wasSuccess = false;

                    // form closed events
                    cf.FormClosing += (s, args) =>
                    {
                        wasSuccess = cf.wasSuccess;
                    };
                    cf.Closed += (s, args) =>
                    {
                        if (wasSuccess)
                        {
                            dbh.DeleteAssignment(selectedAssignment);
                            // refresh class assignments
                            NewClassSelected(null, null);
                        }
                        Show();
                    };
                    cf.Show();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void AssignmentSelected(object sender, EventArgs e)
        {
            DeleteAssignmentButton.Enabled = AssignmentsListBox.SelectedIndex != -1;
        }
    }
}
