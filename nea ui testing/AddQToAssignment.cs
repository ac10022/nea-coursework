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
    public partial class AddQToAssignment : Form
    {
        private List<Topic> topicList;
        private List<User> teacherList;
        private bool canSearch = false;
        private AssignmentMenu menuRef;

        private List<Question> questionsFromSearch;
        public Question selectedQuestion;

        public AddQToAssignment(AssignmentMenu menuRef = null)
        {
            InitializeComponent();

            SearchButton.Enabled = false;
            AddQToAssignmentButton.Enabled = false;

            DatabaseHelper dbh = new DatabaseHelper();
            topicList = dbh.GetAllTopics();
            teacherList = dbh.GetAllTeachers();

            TopicPicker.DataSource = topicList.Select(x => x.TopicName).ToArray();
            TopicPicker.SelectedIndex = -1;
            AuthorPicker.DataSource = teacherList.Select(x => $"{x.FirstName} {x.Surname}").ToArray();
            AuthorPicker.SelectedIndex = -1;

            this.menuRef = menuRef;
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

                QuestionMatches.DataSource = questionsFromSearch.Select(x => $"{x.Topic.TopicName}\t{x.QuestionContent.Substring(0, Math.Min(20, x.QuestionContent.Length))}...\tD{x.Difficulty}\tby {x.Author.FirstName} {x.Author.Surname}").ToArray();

                TestForSelectedQuestion(null, null);
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void TestForData(object sender, EventArgs e)
        {
            canSearch = DifficultyCheckbox1.Checked || DifficultyCheckbox2.Checked || DifficultyCheckbox3.Checked || DifficultyCheckbox4.Checked;
            SearchButton.Enabled = canSearch;
        }

        private void AddQToAssignmentEvent(object sender, EventArgs e)
        {
            // add q to assignment
            try
            {
                selectedQuestion = questionsFromSearch[QuestionMatches.SelectedIndex];
                if (menuRef != null)
                {
                    menuRef.AddQuestionToTrackingList(selectedQuestion);
                }
                else
                {
                    throw new Exception("No reference to tracking list.");
                }
                Close();
                
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void TestForSelectedQuestion(object sender, EventArgs e)
        {
            if (questionsFromSearch != null)
            {
                AddQToAssignmentButton.Enabled = questionsFromSearch.Count != 0 && QuestionMatches.SelectedIndex != -1;
            }
        }
    }
}
