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
    public partial class QuestionManagement : Form
    {
        private bool canSubmit = false;
        private List<Topic> topicList;
        private List<User> teacherList;
        private List<Question> questionsFromSearch;

        public QuestionManagement()
        {
            InitializeComponent();
            SearchButton.Enabled = false;

            // load in all teachers and topics for selection
            DatabaseHelper dbh = new DatabaseHelper();
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
            };
            qem.Show();
        }

        private void TestForData(object sender, EventArgs e)
        {
            canSubmit = (DifficultyCheckbox1.Checked || DifficultyCheckbox2.Checked || DifficultyCheckbox3.Checked || DifficultyCheckbox4.Checked);
            SearchButton.Enabled = canSubmit;
        }

        private void BackToDashboard(object sender, EventArgs e)
        {
            Close();
        }

        private void SearchEvent(object sender, EventArgs e)
        {
            try
            {
                // get label of checked checkboxes (so get all difficulties)
                List<int> selectedDifficulties = this.Controls.OfType<CheckBox>().Where(x => x.Checked).Select(x => int.Parse(x.Text)).ToList();
                Topic selectedTopic = null;
                User selectedAuthor = null;
                if (TopicPicker.SelectedIndex != -1) selectedTopic = topicList[TopicPicker.SelectedIndex];
                if (AuthorPicker.SelectedIndex != -1) selectedAuthor = teacherList[AuthorPicker.SelectedIndex];


                DatabaseHelper dbh = new DatabaseHelper();
                questionsFromSearch = dbh.GetQuestionsMultimetric(selectedDifficulties, selectedTopic, selectedAuthor);

                QuestionMatches.DataSource = questionsFromSearch.Select(x => $"ID{x.QuestionId}\t{x.QuestionContent.Substring(0, 20)}...\tDIF{x.Difficulty}").ToArray();
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }
    }
}
