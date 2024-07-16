using nea_prototype_full;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_ui_testing
{
    public partial class QuestionManagement : Form
    {
        private bool canSubmit = false;
        private List<Topic> topicList;
        private List<User> teacherList;
        private List<Question> questionsFromSearch;

        private DatabaseHelper dbh = new DatabaseHelper();

        public QuestionManagement()
        {
            InitializeComponent();
            SearchButton.Enabled = false;
            AnswerPreviewButton.Enabled = false;
            PrintButton.Enabled = false;
            EditQuestionButton.Enabled = false;
            DeleteQuestionButton.Enabled = false;
            AnswerPreviewLabel.Visible = false;
            SuccessMessage.Visible = false;

            // load in all teachers and topics for selection
            topicList = dbh.GetAllTopics();
            TopicPicker.DataSource = topicList.Select(x => x.TopicName).ToArray();

            teacherList = dbh.GetAllTeachers();
            AuthorPicker.DataSource = teacherList.Select(x => $"{x.FirstName} {x.Surname}").ToArray();

            TopicPicker.SelectedIndex = -1;
            AuthorPicker.SelectedIndex = -1;
        }

        private void GoToCreateQuestionMenu(object sender, EventArgs e)
        {
            Hide();
            QuestionEditor qem = new QuestionEditor();

            // form closed events
            qem.Closed += (s, args) =>
            {
                Show();
                SearchEvent(null, null);
            };
            qem.Show();
        }

        private void TestForData(object sender, EventArgs e)
        {
            canSubmit = (DifficultyCheckbox1.Checked || DifficultyCheckbox2.Checked || DifficultyCheckbox3.Checked || DifficultyCheckbox4.Checked);
            AnswerPreviewButton.Enabled = false;
            PrintButton.Enabled = false;
            EditQuestionButton.Enabled = false;
            DeleteQuestionButton.Enabled = false;
            SearchButton.Enabled = canSubmit;
        }

        private void BackToDashboard(object sender, EventArgs e)
        {
            Close();
        }

        private void SearchEvent(object sender, EventArgs e)
        {
            AnswerPreviewButton.Enabled = false;
            PrintButton.Enabled = false;
            EditQuestionButton.Enabled = false;
            DeleteQuestionButton.Enabled = false;
            try
            {
                // get label of checked checkboxes (so get all difficulties)
                List<int> selectedDifficulties = this.Controls.OfType<CheckBox>().Where(x => x.Checked).Select(x => int.Parse(x.Text)).ToList();
                Topic selectedTopic = null;
                User selectedAuthor = null;
                if (TopicPicker.SelectedIndex != -1) selectedTopic = topicList[TopicPicker.SelectedIndex];
                if (AuthorPicker.SelectedIndex != -1) selectedAuthor = teacherList[AuthorPicker.SelectedIndex];

                questionsFromSearch = dbh.GetQuestionsMultimetric(selectedDifficulties, selectedTopic, selectedAuthor);

                QuestionMatches.DataSource = questionsFromSearch.Select(x => $"{x.Topic.TopicName}\t{x.QuestionContent.Substring(0, Math.Min(20, x.QuestionContent.Length))}...\tD{x.Difficulty}\tby {x.Author.FirstName} {x.Author.Surname}").ToArray();
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void UpdateQuestionInformation(object sender, EventArgs e)
        {
            Question selectedQuestion = questionsFromSearch[QuestionMatches.SelectedIndex];
            TopicLabel.Text = $"Topic: {selectedQuestion.Topic.TopicName}";
            SubjectLabel.Text = $"Subject: {selectedQuestion.Topic.Subject.SubjectName}";
            AuthorLabel.Text = $"Author: {selectedQuestion.Author.FirstName} {selectedQuestion.Author.Surname}";
            DifficultyLabel.Text = $"Difficulty: D{selectedQuestion.Difficulty}";
            ContentLabel.Text = $"{selectedQuestion.QuestionContent.Substring(0, Math.Min(50, selectedQuestion.QuestionContent.Length))}...";
            AnswerPreviewLabel.Text = string.Join(",", selectedQuestion.Answer);
            AnswerPreviewButton.Enabled = true;
            PrintButton.Enabled = true;
            EditQuestionButton.Enabled = true;
            DeleteQuestionButton.Enabled = true;
        }

        private void PreviewAnswerEvent(object sender, MouseEventArgs e)
        {
            AnswerPreviewLabel.Visible = true;
        }

        private void HideAnswerEvent(object sender, MouseEventArgs e)
        {
            AnswerPreviewLabel.Visible = false;
        }

        private void PrintQuestionEvent(object sender, EventArgs e)
        {
            try
            {
                Question selectedQuestion = questionsFromSearch[QuestionMatches.SelectedIndex];
                string path = string.Empty;

                SFD.InitialDirectory = @"C:\";
                SFD.Title = @"Choose where to save the question";
                SFD.DefaultExt = @".doc";
                SFD.CheckPathExists = true;
                SFD.Filter = @"DOC files (*.doc)|*.doc";
                SFD.RestoreDirectory = true;

                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    path = SFD.FileName;
                    PrintingHelper ph = new PrintingHelper(selectedQuestion, path);
                    ph.PrintQuestion();
                    SuccessMessage.Visible = true;
                    SuccessMessage.Text = $"Printed question to {path}";
                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void EditQuestionEvent(object sender, EventArgs e)
        {
            Question selectedQuestion = questionsFromSearch[QuestionMatches.SelectedIndex];

            Hide();
            QuestionEditor qem = new QuestionEditor(true, selectedQuestion);

            // form closed events
            qem.Closed += (s, args) =>
            {
                Show();

                // refresh search
                SearchEvent(null, null);
            };
            qem.Show();
        }

        private void DeleteQuestionEvent(object sender, EventArgs e)
        {
            Hide();
            ConfirmationForm cf = new ConfirmationForm($"Are you sure you want to delete this question?");
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
                    Question selectedQuestion = questionsFromSearch[QuestionMatches.SelectedIndex];
                    dbh.DeleteQuestion(selectedQuestion);
                    // refresh search
                    SearchEvent(null, null);
                }
                Show();
            };
            cf.Show();
        }
    }
}
