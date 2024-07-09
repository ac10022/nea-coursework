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

        private void StudentSelected(object sender, EventArgs e)
        {
            try
            {
                if (StudentsInClass.SelectedIndex != -1)
                {
                    User selectedStudent = studentsInSelectedClass[StudentsInClass.SelectedIndex];
                    SeeQHistoryButton.Enabled = true;

                    NameField.Text = $"Name: {selectedStudent.FirstName} {selectedStudent.Surname}";
                    LastLoginField.Text = $"Last log-in: {dbh.GetLastLoginOfStudent(selectedStudent).ToShortDateString()}";

                    // student assignment performance

                    foreach (Control c in SAPs)
                    {
                        SetVisible(c);
                    }

                    List<Assignment> studentAssignments = dbh.GetAllAssignmentsOfStudent(selectedStudent);

                    int assignmentsToDisplay = Math.Min(studentAssignments.Count, 5);

                    if (assignmentsToDisplay < 5)
                    {
                        for (int i = 0; i < 5-assignmentsToDisplay; i++)
                        {
                            SetHidden(SAPs[i]);
                        }
                    }

                    for (int i = 0; i < assignmentsToDisplay; i++)
                    {
                        if (dbh.StudentCompletedAssignmentTest(studentAssignments[i], selectedStudent) != (double)1)
                        {
                            SAPs[4 - i].Text = $"{studentAssignments[i].HomeworkName}\t INCOMPLETE";
                        }
                        else
                        {
                            double studentPerformance = Math.Round(dbh.StudentCorrectnessAssignmentTest(studentAssignments[i], selectedStudent), 2) * 100;
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

        private void ClassSelected(object sender, EventArgs e)
        {
            try
            {
                if (ClassPicker.SelectedIndex != -1)
                {
                    Class selectedClass = classList[ClassPicker.SelectedIndex];

                    studentsInSelectedClass = dbh.GetStudentsInClass(selectedClass);
                    selectedClassAssignments = dbh.GetClassAssignments(selectedClass);

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

        private void AssignmentSelected(object sender, EventArgs e)
        {
            try
            {
                if (AssignmentPicker.SelectedIndex != -1)
                {
                    // performance analysis
                    StatisticsHelper sh = new StatisticsHelper();
                    Assignment selectedAssignment = selectedClassAssignments[AssignmentPicker.SelectedIndex];

                    Dictionary<Question, double> analysisData = sh.AnalyseAssignmentPerformace(selectedAssignment);

                    Dictionary<string, double> topicAnalysisData = sh.OrganisePerformanceDataByTopic(analysisData);

                    int topicsToTake = Math.Min(topicAnalysisData.Count, 3);

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

                    CorrectnessPerQuestion.DataSource = questionPercentages.Select(x => $"ID{x.Key.QuestionId}: {x.Value}%").ToArray();

                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void SetHidden(Control c)
        {
            c.Visible = false;
            c.Enabled = false;
            c.SendToBack();
            c.BackColor = Color.Transparent;
        }

        private void SetVisible(Control c)
        {
            c.Visible = true;
            c.Enabled = true;
            c.BringToFront();
            c.BackColor = Color.Transparent;
        }

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
