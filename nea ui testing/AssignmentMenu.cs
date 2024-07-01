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
    public partial class AssignmentMenu : Form
    {
        private List<Class> classList;
        private List<Question> questionTrackingList = new List<Question>();
        private bool canSetAssignment = false;

        public AssignmentMenu()
        {
            InitializeComponent();

            SetAssignmentButton.Enabled = false;
            RemoveQFromTrackingList.Enabled = false;
            SuccessMessage.Visible = false;

            DatabaseHelper dbh = new DatabaseHelper();
            classList = dbh.GetAllClasses();
            // display classes by their class name
            ClassPicker.DataSource = classList.Select(x => x.ClassName).ToArray();
            ClassPicker.SelectedIndex = -1;

            // due date cannot be in the past
            DueDatePicker.MinDate = DateTime.Now;
        }

        private void GoToAddQMenu(object sender, EventArgs e)
        {
            Hide();
            AddQToAssignment aqta = new AddQToAssignment(this);

            // form closed events
            aqta.Closed += (s, args) =>
            {
                Show();
            };
            aqta.Show();
        }

        public void AddQuestionToTrackingList(Question question)
        {
            try
            {
                if (!questionTrackingList.Select(x => x.QuestionId).ToList().Contains(question.QuestionId))
                {
                    questionTrackingList.Add(question);
                    RefreshTrackingList();
                    TestForData(null, null);
                }
                else
                {
                    throw new Exception("This question has already been added to this assignment.");
                }
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
            if (questionTrackingList != null)
            {
                canSetAssignment = ClassPicker.SelectedIndex != -1 && HomeworkNameField.TextLength != 0 && questionTrackingList.Count != 0;
                SetAssignmentButton.Enabled = canSetAssignment;
            }
        }

        private void UpdateQuestionInformation(object sender, EventArgs e)
        {
            if (QuestionTrackingList.SelectedIndex != -1)
            {
                Question selectedQuestion = questionTrackingList[QuestionTrackingList.SelectedIndex];
                TopicField.Text = $"Topic: {selectedQuestion.Topic.TopicName}";
                SubjectField.Text = $"Subject: {selectedQuestion.Topic.Subject.SubjectName}";
                AuthorField.Text = $"Author: {selectedQuestion.Author.FirstName} {selectedQuestion.Author.Surname}";
                DifficultyField.Text = $"Difficulty: {selectedQuestion.Difficulty}";
                ContentField.Text = $"{selectedQuestion.QuestionContent.Substring(0, Math.Min(50, selectedQuestion.QuestionContent.Length))}...";
                RemoveQFromTrackingList.Enabled = true;
            }
            else
            {
                RemoveQFromTrackingList.Enabled = false;
            }
        }

        private void RemoveQuestionEvent(object sender, EventArgs e)
        {
            SuccessMessage.Visible = false;
            if (QuestionTrackingList.SelectedIndex != -1)
            {
                Question selectedQuestion = questionTrackingList[QuestionTrackingList.SelectedIndex];
                questionTrackingList.Remove(selectedQuestion);
                TestForData(null, null);
                RefreshTrackingList();
                UpdateQuestionInformation(null, null);
            }
        }

        private void RefreshTrackingList()
        {
            QuestionTrackingList.DataSource = questionTrackingList.Select(x => $"Q{questionTrackingList.IndexOf(x) + 1}\t{x.Topic.TopicName}\t{x.QuestionContent.Substring(0, Math.Min(20, x.QuestionContent.Length))}...\tD{x.Difficulty}\tby {x.Author.FirstName} {x.Author.Surname}").ToArray();
        }

        private void SetAssignmentEvent(object sender, EventArgs e)
        {
            try
            {
                Class targetClass = classList[ClassPicker.SelectedIndex];
                Assignment assignment = new Assignment(-1, Program.loggedInUser, HomeworkNameField.Text, DueDatePicker.Value, questionTrackingList, targetClass);

                DatabaseHelper dbh = new DatabaseHelper();
                dbh.CreateAssignment(assignment);

                SuccessMessage.Visible = true;
                SuccessMessage.Text = $"Successfully created assignment for class {targetClass.ClassName}";
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void GoBackToDashboard(object sender, EventArgs e)
        {
            Close();
        }
    }
}
