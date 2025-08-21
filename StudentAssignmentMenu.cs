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
    /// <summary>
    /// A form through which students can view their upcoming and past assignments, and start them.
    /// </summary>
    public partial class StudentAssignmentMenu : Form
    {
        private List<Assignment> assignmentList = new List<Assignment>();
        private bool showCompleted = false;
        private DatabaseHelper dbh = new DatabaseHelper();

        public StudentAssignmentMenu(bool showCompleted = false)
        {
            InitializeComponent();

            ShowCompletedButton.Checked = showCompleted;
            ShowCompletedButton.CheckedChanged += ToggleCompletedEvent;

            List<Class> studentClasses = dbh.GetClassesOfStudent(Program.loggedInUser);

            if (studentClasses.Count == 0)
            {
                new ErrorForm("You are not in any classes! Ask your teacher to add you to the class.").Show();
            }

            // include assignments student has completed
            if (showCompleted)
            {
                this.showCompleted = true;
                // for each class the student is in, fetch all assignments for that class
                foreach (Class _class in studentClasses) assignmentList.AddRange(dbh.GetClassAssignments(_class));
            }
            // exclude assignments student has completed
            else
            {
                foreach (Class _class in studentClasses)
                {
                    foreach (Assignment assignment in dbh.GetClassAssignments(_class))
                    {
                        // only show assignments which are incomplete
                        if (dbh.StudentCompletedAssignmentTest(assignment, Program.loggedInUser) != (double)1)
                        {
                            assignmentList.Add(assignment);
                        }        
                    }
                }
            }

            // create assignment labels
            DrawAssignmentLabels();
        }

        /// <summary>
        /// A method to create controls (one per assignment), which display upcoming assignments and allows student to begin an assignment by clicking on the corresponding button.
        /// </summary>
        public void DrawAssignmentLabels()
        {
            for (int i = 0; i < assignmentList.Count; i++)
            {
                Assignment currentAssignment = assignmentList[i];
                bool studentHasCompleted = false;

                // check if the student has completed this assignment
                if (showCompleted) studentHasCompleted = dbh.StudentCompletedAssignmentTest(currentAssignment, Program.loggedInUser) == (double)1;

                Label newLabel = new Label();

                newLabel.AutoSize = true;
                // if has completed: dark green, if past due: red, if upcoming and incomplete: blue
                if (studentHasCompleted)
                {
                    newLabel.BackColor = System.Drawing.Color.DarkGreen;
                }
                else if (currentAssignment.HomeworkDueDate < DateTime.Today)
                {
                    newLabel.BackColor= System.Drawing.Color.IndianRed;
                }
                else
                {
                    newLabel.BackColor = System.Drawing.Color.Azure;
                }

                // create a new label to display on screen which displays assignment info
                newLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                newLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newLabel.Location = new System.Drawing.Point(16, 70 + 40 * i);
                newLabel.Name = $"label{i + 1}";
                newLabel.Size = new System.Drawing.Size(637, 28);
                newLabel.TabIndex = 44 + 2 * i;
                newLabel.Text = $"{((currentAssignment.HomeworkDueDate < DateTime.Today) ? "-PAST DUE- " : "")}{currentAssignment.HomeworkName} set by {currentAssignment.Setter.FirstName} due {currentAssignment.HomeworkDueDate.ToShortDateString()}";

                Controls.Add(newLabel);

                Button newButton = new Button();

                // create a button through which the student can start this assignment
                newButton.Location = new System.Drawing.Point(450, 88 + 40 * i);
                newButton.Name = $"button{i + 1}";
                newButton.Size = new System.Drawing.Size(70, 25);
                newButton.TabIndex = 45 + 2 * i;
                newButton.Text = "Begin";
                newButton.UseVisualStyleBackColor = true;
                newButton.BringToFront();

                // if the student has already completed this assignment, they shouldn't be able to do it again
                if (studentHasCompleted) newButton.Enabled = false;

                // when this button is clicked, start the assignment it references
                newButton.Click += delegate (object sender, EventArgs e)
                {
                    StartAssignment(currentAssignment);

                    // disable button, so that once the user returns to the form after completion they cannot reattempt the assignment
                    (sender as Button).Enabled = false;
                };

                Controls.Add(newButton);
            }

            // refresh form with new controls
            this.Invalidate();
        }
        
        /// <summary>
        /// On start assignment: hide this form, fetch and start the assignment.
        /// </summary>
        /// <param name="assignment"></param>
        private void StartAssignment(Assignment assignment)
        {
            DatabaseHelper dbh = new DatabaseHelper();
            // fetch assignment questions
            List<Question> assignmentQuestions = dbh.GetQuestionsFromAssignment(assignment);

            Hide();
            // reference these questions and this assignment
            QuestionAttemptMenu qam = new QuestionAttemptMenu(assignmentQuestions, assignment, this);
            qam.Show();
        }


        /// <summary>
        /// A method to close this form and return the user to the dashboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackToDashboard(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// A method which refreshes this form to show/hide completed assignments in assignment selection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleCompletedEvent(object sender, EventArgs e)
        {
            // show completed assignments
            if (ShowCompletedButton.Checked)
            {
                StudentAssignmentMenu sam = new StudentAssignmentMenu(true);
                Hide();
                // form closed events
                sam.Closed += (s, args) =>
                {
                    Close();
                };
                sam.Show();
            }
            // hide completed assignments
            else
            {
                StudentAssignmentMenu sam = new StudentAssignmentMenu(false);
                Hide();
                // form closed events
                sam.Closed += (s, args) =>
                {
                    Close();
                };
                sam.Show();
            }
        }
    }
}
