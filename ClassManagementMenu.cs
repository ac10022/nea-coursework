using nea_backend;
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

namespace nea_ui
{
    /// <summary>
    /// This form is for use by teachers to manage classes: search for classes, modify classes, view class members, add/remove members, view class assignments, remove class assignments.
    /// </summary>
    public partial class ClassManagementMenu : Form
    {
        private bool canSubmit = false;
        private List<Class> foundClasses;

        private List<User> studentsInSelectedClass;
        private List<User> teachersInSelectedClass;
        private List<Assignment> selectedClassAssignments;

        private DatabaseHelper dbh = new DatabaseHelper();

        /// <summary>
        /// On initialisation: hide and disable buttons which may cause erroneous calls.
        /// </summary>
        public ClassManagementMenu()
        {
            InitializeComponent();
            SearchForClassButton.Enabled = false;
            EditClassnameButton.Enabled = false;
            DeleteAssignmentButton.Enabled = false;
            SuccessMessage.Visible = false;
            DeleteClassButton.Enabled = false;
            RemoveUserButton.Enabled = false;
        }

        /// <summary>
        /// A method to hide the current form and redirect the user to the ClassCreator form. Then open this form again once that form has been closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// On search: take in the class name filter and use this to search for classes from the database, then return matches and display this in the class listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchForClass(object sender, EventArgs e)
        {
            try
            {
                foundClasses = dbh.SearchForClasses(ClassNameFilter.Text);
                ClassListBox.DataSource = foundClasses.Select(x => $"{x.ClassId}\t{x.ClassName}").ToArray();
                RemoveUserButton.Enabled = false;
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// A method to test fields for data. Here: only allow classes to be searched if the class name field is filled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestForData(object sender, EventArgs e)
        {
            SuccessMessage.Visible = false;
            canSubmit = ClassNameFilter.TextLength != 0;
            SearchForClassButton.Enabled = canSubmit;
        }

        /// <summary>
        /// On class selection: Fecth the selected class and display information about this class, i.e. list of students, teachers, and assignments.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewClassSelected(object sender, EventArgs e)
        {
            try
            {
                // fetch class
                Class selectedClass = foundClasses[(sender as ListBox).SelectedIndex];
                ClassnameLabel.Text = $"Name: {selectedClass.ClassName}";
                EditClassnameButton.Enabled = true;
                DeleteClassButton.Enabled = true;

                // fetch class information: students, teachers, assignments
                studentsInSelectedClass = dbh.GetStudentsInClass(selectedClass);
                teachersInSelectedClass = dbh.GetTeachersInClass(selectedClass);
                selectedClassAssignments = dbh.GetClassAssignments(selectedClass);

                // update the list boxes to show the fetched information
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

        /// <summary>
        /// A method to hide the current form and redirect the user to the AddUserToClass form. Then open this form again once that form has been closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToAddUserMenu(object sender, EventArgs e)
        {
            Hide();
            AddUserToClass autc = new AddUserToClass(foundClasses[ClassListBox.SelectedIndex]);

            // form closed events
            autc.Closed += (s, args) =>
            {
                Show();
                // refresh class search, so that the new member appears
                if (ClassNameFilter.TextLength != 0) SearchForClass(null, null);
                SuccessMessage.Visible = false;
            };
            autc.Show();
        }

        /// <summary>
        /// A method to ensure only a student is selected from the listboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentChoiceChanged(object sender, EventArgs e)
        {
            if (TeachersInClass.SelectedIndex != -1 && StudentsInClass.SelectedIndex != -1) TeachersInClass.ClearSelected();
            RemoveUserButton.Enabled = true;
        }

        /// <summary>
        /// A method to ensure only a teacher is selected from the listboxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeacherChoiceChanged(object sender, EventArgs e)
        {
            if (StudentsInClass.SelectedIndex != -1 && TeachersInClass.SelectedIndex != -1) StudentsInClass.ClearSelected();
            RemoveUserButton.Enabled = true;
        }

        /// <summary>
        /// On user removal: fetch the class, open a confirmation form to confirm this action; if successful remove the user from class, and send a confirmation message.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUserEvent(object sender, EventArgs e)
        {
            try
            {
                // only remove once a user is selected
                if (StudentsInClass.SelectedIndex == -1 && TeachersInClass.SelectedIndex == -1) throw new Exception("No user selected to remove.");

                Class selectedClass = foundClasses[ClassListBox.SelectedIndex];

                Hide();
                ConfirmationForm cf = new ConfirmationForm($"Are you sure you want to remove this user from {selectedClass.ClassName}?");
                bool wasSuccess = false;

                // form closed events
                cf.FormClosing += (s, args) =>
                {
                    // fetch whether user selected confirm
                    wasSuccess = cf.wasSuccess;
                };
                cf.Closed += (s, args) =>
                {
                    // if they confirmed
                    if (wasSuccess)
                    {
                        // if a student was selected to be removed
                        if (StudentsInClass.SelectedIndex != -1)
                        {
                            User selectedStudent = studentsInSelectedClass[StudentsInClass.SelectedIndex];
                            dbh.RemoveStudentFromClass(selectedStudent, selectedClass);

                            SuccessMessage.Text = $"Removed {selectedStudent.FirstName} {selectedStudent.Surname} from selected class.";
                            SuccessMessage.Visible = true;
                        }
                        // else if a teacher was selected to be removed
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

        /// <summary>
        /// A method to close the current form and return to dashboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnToDashboard(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// A method to hide the current form and redirect the user to the ClassCreator form, to edit the selected class. Then open this form again once that form has been closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// On assignment deletion: fetch the assignment, open a confirmation form to confirm this action; if successful delete this assignment for this class and refresh necessary controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAssignmentEvent(object sender, EventArgs e)
        {
            try
            {
                if (AssignmentsListBox.SelectedIndex != -1)
                {
                    // fetch assignment
                    Assignment selectedAssignment = selectedClassAssignments[AssignmentsListBox.SelectedIndex];

                    Hide();
                    ConfirmationForm cf = new ConfirmationForm($"Are you sure you want to delete this assignment: {selectedAssignment.HomeworkName}?");
                    bool wasSuccess = false;

                    // form closed events
                    cf.FormClosing += (s, args) =>
                    {
                        // fetch whether the user selected confirm
                        wasSuccess = cf.wasSuccess;
                    };
                    cf.Closed += (s, args) =>
                    {
                        // if they confirmed
                        if (wasSuccess)
                        {
                            // delete assignment for this class
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

        /// <summary>
        /// A method which updates every time a new index is selected in the assignment list box. If a valid assignment is selected, allow this assignment to be deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssignmentSelected(object sender, EventArgs e)
        {
            DeleteAssignmentButton.Enabled = AssignmentsListBox.SelectedIndex != -1;
        }

        /// <summary>
        /// On class deletion: fetch the class, open a confirmation form to confirm this action; if successful delete this class in the DB and refresh necessary controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteClassEvent(object sender, EventArgs e)
        {
            try
            {
                if (ClassListBox.SelectedIndex != -1)
                {
                    // fetch class
                    Class selectedClass = foundClasses[ClassListBox.SelectedIndex];

                    Hide();
                    ConfirmationForm cf = new ConfirmationForm($"Are you sure you want to delete this class: {selectedClass.ClassName}?");
                    bool wasSuccess = false;

                    // form closed events
                    cf.FormClosing += (s, args) =>
                    {
                        // fetch if user confirmed action
                        wasSuccess = cf.wasSuccess;
                    };
                    cf.Closed += (s, args) =>
                    {
                        // if they confirmed
                        if (wasSuccess)
                        {
                            dbh.DeleteClass(selectedClass);
                            // refresh class search
                            SearchForClass(null, null);
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
    }
}
