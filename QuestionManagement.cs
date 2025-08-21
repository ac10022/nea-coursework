using nea_backend;
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

namespace nea_ui
{
    /// <summary>
    /// A form from which teachers can search for, view data for, modify, view answers for, and print existing questions. Teachers can also create new questions from this menu.
    /// </summary>
    public partial class QuestionManagement : Form
    {
        private bool canSubmit = false;
        private List<Topic> topicList;
        private List<User> teacherList;
        private List<Question> questionsFromSearch;

        private DatabaseHelper dbh = new DatabaseHelper();

        public QuestionManagement()
        {
            // preload controls to default states
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

            // remove selected item from listboxes
            TopicPicker.SelectedIndex = -1;
            AuthorPicker.SelectedIndex = -1;
        }

        /// <summary>
        /// A method to hide this form, open a new instance of the create question form, and return to this form once that form has been closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// A method to test fields for data. Here: only allow the user to submit their search if at least one difficulty field has been selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestForData(object sender, EventArgs e)
        {
            canSubmit = (DifficultyCheckbox1.Checked || DifficultyCheckbox2.Checked || DifficultyCheckbox3.Checked || DifficultyCheckbox4.Checked);
            AnswerPreviewButton.Enabled = false;
            PrintButton.Enabled = false;
            EditQuestionButton.Enabled = false;
            DeleteQuestionButton.Enabled = false;
            SearchButton.Enabled = canSubmit;
        }

        /// <summary>
        /// A method which closes this form and returns the user to the teacher dashboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToDashboard(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// On search: parse input criteria into a database search, fetch matching questions from DB, then display these in the question list box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchEvent(object sender, EventArgs e)
        {
            // no longer will a question be selected, so disable relevant controls
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

                // if an author/topic has been selected, use these in the search
                if (TopicPicker.SelectedIndex != -1) selectedTopic = topicList[TopicPicker.SelectedIndex];
                if (AuthorPicker.SelectedIndex != -1) selectedAuthor = teacherList[AuthorPicker.SelectedIndex];

                // using these criteria, fetch matching questions from database
                questionsFromSearch = dbh.GetQuestionsMultimetric(selectedDifficulties, selectedTopic, selectedAuthor);

                // display questions in listbox
                QuestionMatches.DataSource = questionsFromSearch.Select(x => $"{x.Topic.TopicName}\t{x.QuestionContent.Substring(0, Math.Min(20, x.QuestionContent.Length))}...\tD{x.Difficulty}\tby {x.Author.FirstName} {x.Author.Surname}").ToArray();
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// A method to update fields once a question has been selected with new question information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateQuestionInformation(object sender, EventArgs e)
        {
            // fetch the selected question
            Question selectedQuestion = questionsFromSearch[QuestionMatches.SelectedIndex];

            // update fields to contain current question information
            TopicLabel.Text = $"Topic: {selectedQuestion.Topic.TopicName}";
            SubjectLabel.Text = $"Subject: {selectedQuestion.Topic.Subject.SubjectName}";
            AuthorLabel.Text = $"Author: {selectedQuestion.Author.FirstName} {selectedQuestion.Author.Surname}";
            DifficultyLabel.Text = $"Difficulty: D{selectedQuestion.Difficulty}";
            ContentLabel.Text = $"{selectedQuestion.QuestionContent.Substring(0, Math.Min(50, selectedQuestion.QuestionContent.Length))}...";
            AnswerPreviewLabel.Text = string.Join(",", selectedQuestion.Answer);

            // since a question is now selected, allow the user to preview answer, print, edit, or delete
            AnswerPreviewButton.Enabled = true;
            PrintButton.Enabled = true;
            EditQuestionButton.Enabled = true;
            DeleteQuestionButton.Enabled = true;
        }

        /// <summary>
        /// A method to display the question answer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewAnswerEvent(object sender, MouseEventArgs e)
        {
            AnswerPreviewLabel.Visible = true;
        }

        /// <summary>
        /// A method to hide the question answer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideAnswerEvent(object sender, MouseEventArgs e)
        {
            AnswerPreviewLabel.Visible = false;
        }

        /// <summary>
        /// On printing: ask the user using a save-file dialog where to save the question, then use the printing helper with the selected question to create a new printable document containing this question.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintQuestionEvent(object sender, EventArgs e)
        {
            try
            {
                // fetch selected question
                Question selectedQuestion = questionsFromSearch[QuestionMatches.SelectedIndex];
                
                // using SFD, ask user where to save the .doc file which will be created
                string path = string.Empty;
                SFD.InitialDirectory = @"C:\";
                SFD.Title = @"Choose where to save the question";
                SFD.DefaultExt = @".doc";
                SFD.CheckPathExists = true;
                SFD.Filter = @"DOC files (*.doc)|*.doc";
                SFD.RestoreDirectory = true;

                // if a successful directory has been selected
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    path = SFD.FileName;

                    // use printing helper to create a new document containing this question
                    PrintingHelper ph = new PrintingHelper(selectedQuestion, path);
                    ph.PrintQuestion();

                    // display success message; question successfully printed
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

        /// <summary>
        /// A method to hide this form, open a new instance of the edit (create) question form, and return to this form once that form has been closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditQuestionEvent(object sender, EventArgs e)
        {
            // fetch selected question to edit
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

        /// <summary>
        /// On deletion: open a confirmation form to confirm question deletion, then, if this is successful, delete all instances of this question from the database and refresh search.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                // if confirmed
                if (wasSuccess)
                {
                    // fetch question and delete all references from the database
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