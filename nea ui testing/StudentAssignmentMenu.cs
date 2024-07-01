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
        public StudentAssignmentMenu()
        {
            InitializeComponent();

            DatabaseHelper dbh = new DatabaseHelper();
            List<Assignment> assignmentList = new List<Assignment>();

            // for each class the student is in, fetch all assignments for that class
            foreach (Class _class in dbh.GetClassesOfStudent(Program.loggedInUser))
            {
                assignmentList.AddRange(dbh.GetClassAssignments(_class));
            }

            for (int i = 0; i < assignmentList.Count; i++)
            {
                Assignment currentAssignment = assignmentList[i];

                Label newLabel = new Label();

                newLabel.AutoSize = true;
                newLabel.BackColor = System.Drawing.Color.Azure;
                newLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                newLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                newLabel.Location = new System.Drawing.Point(16, 70 + 40*i);
                newLabel.Name = $"label{i+1}";
                newLabel.Size = new System.Drawing.Size(637, 28);
                newLabel.TabIndex = 44 + 2*i;
                newLabel.Text = $"{currentAssignment.HomeworkName} \tset by {currentAssignment.Setter.FirstName} {currentAssignment.Setter.Surname} \tdue {currentAssignment.HomeworkDueDate}";

                Controls.Add(newLabel);

                Button newButton = new Button();

                newButton.Location = new System.Drawing.Point(450, 68 + 40*i);
                newButton.Name = $"button{i+1}";
                newButton.Size = new System.Drawing.Size(70, 25);
                newButton.TabIndex = 45 + 2*i;
                newButton.Text = "Begin";
                newButton.UseVisualStyleBackColor = true;
                newButton.BringToFront();

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
            QuestionAttemptMenu qam = new QuestionAttemptMenu(assignmentQuestions, assignment);

            // form closed events
            qam.Closed += (s, args) =>
            {
                Show();
            };
            qam.Show();
        }
    }
}
