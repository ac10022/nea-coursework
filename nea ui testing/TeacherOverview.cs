using nea_prototype_full;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_ui_testing
{
    /// <summary>
    /// A form through which teachers can manage class performance, students within classes, and see statistical overviews.
    /// </summary>
    public partial class TeacherOverview : Form
    {
        private List<Class> classList;
        private List<User> studentsInSelectedClass;
        private List<Assignment> selectedClassAssignments;

        private Control[] SAPs;

        private DatabaseHelper dbh = new DatabaseHelper();

        public TeacherOverview()
        {
            InitializeComponent();

            // fetch classes from DB, display these in the class picker
            classList = dbh.GetAllClasses();
            ClassPicker.DataSource = classList.Select(x => x.ClassName).ToArray();
            ClassPicker.SelectedIndex = -1;

            ClassPicker.SelectedIndexChanged += ClassSelected;
            SeeQHistoryButton.Enabled = false;

            SAPs = new Control[] { SAP_5, SAP_4, SAP_3, SAP_2, SAP_1 };
        }

        private void GoBackToDashboard(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// On student selection: show student data and assignment performance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentSelected(object sender, EventArgs e)
        {
            try
            {
                // if a student is selected
                if (StudentsInClass.SelectedIndex != -1)
                {
                    // fetch selected student
                    User selectedStudent = studentsInSelectedClass[StudentsInClass.SelectedIndex];
                    SeeQHistoryButton.Enabled = true;

                    // show name and last login of student in corresponding fields
                    NameField.Text = $"Name: {selectedStudent.FirstName} {selectedStudent.Surname}";
                    LastLoginField.Text = $"Last log-in: {dbh.GetLastLoginOfStudent(selectedStudent).ToShortDateString()}";

                    // student assignment performance

                    // show assignment labels
                    foreach (Control c in SAPs)
                    {
                        SetVisible(c);
                    }

                    // fetch student assignments from the DB
                    List<Assignment> studentAssignments = dbh.GetAllAssignmentsOfStudent(selectedStudent);

                    // fetch at max the last 5 assignments
                    int assignmentsToDisplay = Math.Min(studentAssignments.Count, 5);

                    // hide assignment labels if less than 5 assignments overall have been completed
                    if (assignmentsToDisplay < 5)
                    {
                        for (int i = 0; i < 5 - assignmentsToDisplay; i++)
                        {
                            SetHidden(SAPs[i]);
                        }
                    }

                    // iterate over each assignment and show student completeness data
                    for (int i = 0; i < assignmentsToDisplay; i++)
                    {
                        // reset colour
                        SAPs[4 - i].ForeColor = Color.Black;

                        // if the assignment is incomplete
                        if (dbh.StudentCompletedAssignmentTest(studentAssignments[i], selectedStudent) != (double)1)
                        {
                            // did not finish homework on time
                            if (studentAssignments[i].HomeworkDueDate < DateTime.Today)
                            {
                                SAPs[4 - i].Text = $"{studentAssignments[i].HomeworkName}\t --DNF--";
                                SAPs[4 - i].BackColor = Color.Black;
                                SAPs[4 - i].ForeColor = Color.White;
                            }
                            // homework not due yet, but student has not completed it
                            else
                            {
                                SAPs[4 - i].Text = $"{studentAssignments[i].HomeworkName}\t INCOMPLETE";
                            }
                        }
                        // assignment is complete
                        else
                        {
                            // fetch student performance (as %) from DB
                            double studentPerformance = Math.Round(dbh.StudentCorrectnessAssignmentTest(studentAssignments[i], selectedStudent), 2) * 100;
                            
                            // switch label colour based on assignment performance
                            switch (studentPerformance)
                            {
                                case double pct when pct < 50:
                                    SAPs[4 - i].BackColor = Color.Red;
                                    break;
                                case double pct when (50 <= pct && pct < 70):
                                    SAPs[4 - i].BackColor = Color.Orange;
                                    break;
                                case double pct when (70 <= pct && pct < 85):
                                    SAPs[4 - i].BackColor = Color.YellowGreen;
                                    break;
                                case double pct when (85 <= pct):
                                    SAPs[4 - i].BackColor = Color.ForestGreen;
                                    break;
                                default:
                                    break;
                            }
                            SAPs[4 - i].Text = $"{studentAssignments[i].HomeworkName}\t {studentPerformance}%";
                        }
                    }
                }
                // if no student is selected
                else
                {
                    SeeQHistoryButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// On class selection: show class students and assignments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassSelected(object sender, EventArgs e)
        {
            try
            {
                if (ClassPicker.SelectedIndex != -1)
                {
                    // fetch selected class
                    Class selectedClass = classList[ClassPicker.SelectedIndex];

                    // fetch class students/assignments from DB
                    studentsInSelectedClass = dbh.GetStudentsInClass(selectedClass);
                    selectedClassAssignments = dbh.GetClassAssignments(selectedClass);

                    // display class students/assignments in corresponding listboxes
                    StudentsInClass.DataSource = studentsInSelectedClass.Select(x => $"{x.FirstName} {x.Surname}").ToArray();
                    StudentsInClass.ClearSelected();

                    AssignmentPicker.DataSource = selectedClassAssignments.Select(x => x.HomeworkName).ToArray();
                    AssignmentPicker.SelectedIndex = -1;
                    AssignmentPicker.SelectedIndexChanged += AssignmentSelected;

                    ClassNameField.Text = $"Class Name: {selectedClass.ClassName}";
                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// On assignment selection: fetch assignment performance, perform statistical analysis and display results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssignmentSelected(object sender, EventArgs e)
        {
            try
            {
                if (AssignmentPicker.SelectedIndex != -1)
                {
                    // performance analysis
                    StatisticsHelper sh = new StatisticsHelper();

                    // fetch selected assignment
                    Assignment selectedAssignment = selectedClassAssignments[AssignmentPicker.SelectedIndex];

                    // calculate performance per question
                    Dictionary<Question, double> analysisData = sh.AnalyseAssignmentPerformace(selectedAssignment);

                    // calculate performance per topic
                    Dictionary<string, double> topicAnalysisData = sh.OrganisePerformanceDataByTopic(analysisData);

                    // take at max 3 topics from the assignment, if there were fewer than 3 topics overall in the assignemnt questions, use this amount instead
                    int topicsToTake = Math.Min(topicAnalysisData.Count, 3);

                    // create a string containing best and worse answered topics
                    List<string> topicsForTopicDisplay = new List<string>();
                    topicsForTopicDisplay.AddRange(sh.GetWorstAnsweredTopics(topicAnalysisData).Take(topicsToTake));
                    topicsForTopicDisplay.AddRange(sh.GetBestAnsweredTopics(topicAnalysisData).Take(topicsToTake));

                    StringBuilder topicAnalysisDisplay = new StringBuilder();
                    topicAnalysisDisplay.AppendLine("For improvement:");

                    for (int i = 0; i < topicsToTake; i++)
                    {
                        topicAnalysisDisplay.AppendLine($"- {topicsForTopicDisplay[i]}: {Math.Round(topicAnalysisData[topicsForTopicDisplay[i]], 2)}");
                    }

                    topicAnalysisDisplay.AppendLine();
                    topicAnalysisDisplay.AppendLine("Strengths:");

                    for (int i = topicsToTake; i < topicsForTopicDisplay.Count; i++)
                    {
                        topicAnalysisDisplay.AppendLine($"- {topicsForTopicDisplay[i]}: {Math.Round(topicAnalysisData[topicsForTopicDisplay[i]], 2)}");
                    }

                    TopicAnalysisField.Text = topicAnalysisDisplay.ToString();

                    // correctness percentage per question
                    Dictionary<Question, int> questionPercentages = dbh.PercentagePerAssignmentQuestion(selectedAssignment);

                    // show the percentage correctness of each assignment question
                    CorrectnessPerQuestion.DataSource = questionPercentages.Select(x => $"ID{x.Key.QuestionId}: {x.Value}%").ToArray();

                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// A method to hide and disable a control.
        /// </summary>
        /// <param name="c"></param>
        private void SetHidden(Control c)
        {
            c.Visible = false;
            c.Enabled = false;
            c.SendToBack();
            c.BackColor = Color.Transparent;
        }

        /// <summary>
        /// A method to show and enable a control.
        /// </summary>
        /// <param name="c"></param>
        private void SetVisible(Control c)
        {
            c.Visible = true;
            c.Enabled = true;
            c.BringToFront();
            c.BackColor = Color.Transparent;
        }

        /// <summary>
        /// A method to redirect the user to the student history form: hides this form then reopens this form once the new form has been closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeeStudentHistory(object sender, EventArgs e)
        {
            Hide();
            StudentQuestionHistory sqh = new StudentQuestionHistory(studentsInSelectedClass[StudentsInClass.SelectedIndex]);

            // form closed events
            sqh.Closed += (s, args) =>
            {
                Show();
            };
            sqh.Show();
        }
    }
}
