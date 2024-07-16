using nea_prototype_full;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_ui_testing
{
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

            if (showCompleted)
            {
                this.showCompleted = true;
                // for each class the student is in, fetch all assignments for that class
                foreach (Class _class in dbh.GetClassesOfStudent(Program.loggedInUser)) assignmentList.AddRange(dbh.GetClassAssignments(_class));
            }
            else
            {
                foreach (Class _class in dbh.GetClassesOfStudent(Program.loggedInUser))
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

            DrawAssignmentLabels();
        }

        private void DrawAssignmentLabels()
        {
            for (int i = 0; i < assignmentList.Count; i++)
            {
                Assignment currentAssignment = assignmentList[i];
                bool studentHasCompleted = false;

                if (showCompleted) studentHasCompleted = dbh.StudentCompletedAssignmentTest(currentAssignment, Program.loggedInUser) == (double)1;

                Label newLabel = new Label();

                newLabel.AutoSize = true;
                if (studentHasCompleted)
                {
                    newLabel.BackColor = System.Drawing.Color.DarkGreen;
                }
                else
                {
                    newLabel.BackColor = System.Drawing.Color.Azure;
                }
                newLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                newLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newLabel.Location = new System.Drawing.Point(16, 70 + 40 * i);
                newLabel.Name = $"label{i + 1}";
                newLabel.Size = new System.Drawing.Size(637, 28);
                newLabel.TabIndex = 44 + 2 * i;
                newLabel.Text = $"{currentAssignment.HomeworkName}    set by {currentAssignment.Setter.FirstName}    due {currentAssignment.HomeworkDueDate.ToShortDateString()}";

                Controls.Add(newLabel);

                Button newButton = new Button();

                newButton.Location = new System.Drawing.Point(450, 68 + 40 * i);
                newButton.Name = $"button{i + 1}";
                newButton.Size = new System.Drawing.Size(70, 25);
                newButton.TabIndex = 45 + 2 * i;
                newButton.Text = "Begin";
                newButton.UseVisualStyleBackColor = true;
                newButton.BringToFront();

                if (studentHasCompleted) newButton.Enabled = false;

                // when this button is clicked, start the assignment it references
                newButton.Click += delegate (object sender, EventArgs e)
                {
                    StartAssignment(currentAssignment);
                };

                Controls.Add(newButton);
            }

            this.Invalidate();
        }
        
        private void StartAssignment(Assignment assignment)
        {
            DatabaseHelper dbh = new DatabaseHelper();
            List<Question> assignmentQuestions = dbh.GetQuestionsFromAssignment(assignment);

            Hide();
            QuestionAttemptMenu qam = new QuestionAttemptMenu(assignmentQuestions, assignment, this);
            qam.Show();
        }

        private void GoBackToDashboard(object sender, EventArgs e)
        {
            Close();
        }

        private void ToggleCompletedEvent(object sender, EventArgs e)
        {
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
