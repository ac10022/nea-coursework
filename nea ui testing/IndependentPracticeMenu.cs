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
using ListExtensionMethods;
using automatic_question_generation_testing;

namespace nea_ui_testing
{
    public partial class IndependentPracticeMenu : Form
    {
        private bool canSubmit = false;
        private List<Topic> topicList;
        private List<Question> questionsFromSearch;

        private _Topic[] topicsWithRGQ = { _Topic.SubjectVerbAgreement, _Topic.AdjectivesAdverbs, _Topic.Algebra, _Topic.Graphs, _Topic.Inequalities, _Topic.Sequences, _Topic.RatioProportion, _Topic.SimultaneousEq, _Topic.Quadratics, _Topic.AveragesRangesModeMedian, _Topic.PerimeterAreaVolume };
        int[] indexesOfTopicsWithRGQ;

        private DatabaseHelper dbh = new DatabaseHelper();
        private StatisticsHelper sh = new StatisticsHelper();

        public IndependentPracticeMenu()
        {
            InitializeComponent();
            SearchButton.Enabled = false;
            PracticeThisQButton.Enabled = false;
            RGQCheckbox.Enabled = false;

            PanelForDrawing.SendToBack();
            PanelForDrawing.Width = 400;
            PanelForDrawing.Height = 400;

            topicList = dbh.GetAllTopics();

            indexesOfTopicsWithRGQ = topicList.Where(x => topicsWithRGQ.Contains((_Topic)x.TopicId)).Select(x => topicList.IndexOf(x)).ToArray();

            // from database
            TopicPicker.DataSource = topicList.Select(x => x.TopicName).ToArray();
            TopicPicker.SelectedIndex = -1;

            // by topic
            TopicPicker2.DataSource = topicList.Select(x => x.TopicName).ToArray();
            TopicPicker2.SelectedIndex = -1;

            LoadStudentAnalysis();
        }

        private void TestForData(object sender, EventArgs e)
        {
            PracticeThisQButton.Enabled = false;
            canSubmit = (DifficultyCheckbox1.Checked || DifficultyCheckbox2.Checked || DifficultyCheckbox3.Checked || DifficultyCheckbox4.Checked);
            SearchButton.Enabled = canSubmit;
        }

        private void SubmitSearch(object sender, EventArgs e)
        {
            try
            {
                List<int> selectedDifficulties = new List<int>();
                if (DifficultyCheckbox1.Checked) selectedDifficulties.Add(1);
                if (DifficultyCheckbox2.Checked) selectedDifficulties.Add(2);
                if (DifficultyCheckbox3.Checked) selectedDifficulties.Add(3);
                if (DifficultyCheckbox4.Checked) selectedDifficulties.Add(4);

                Topic selectedTopic = null;
                if (TopicPicker.SelectedIndex != -1) selectedTopic = topicList[TopicPicker.SelectedIndex];

                questionsFromSearch = dbh.GetQuestionsMultimetric(selectedDifficulties, selectedTopic, null);

                QuestionMatches.DataSource = questionsFromSearch.Select(x => $"{x.Topic.TopicName}\t{x.QuestionContent.Substring(0, Math.Min(x.QuestionContent.Length, 20))}...\tD{x.Difficulty}\tby {x.Author.FirstName} {x.Author.Surname}").ToArray();
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void QuestionSelectedEvent(object sender, EventArgs e)
        {
            PracticeThisQButton.Enabled = true;
        }

        private void GoBackToDashboard(object sender, EventArgs e)
        {
            Close();
        }

        private void StartPracticeFromQuestion(object sender, EventArgs e)
        {
            Question selectedQuestion = questionsFromSearch[QuestionMatches.SelectedIndex];

            Hide();
            QuestionAttemptMenu qam = new QuestionAttemptMenu(new List<Question> { selectedQuestion }, null, this);
            qam.Show();
        }

        private void CheckForRandomQs(object sender, EventArgs e)
        {
            if (TopicPicker2.SelectedIndex == -1) return; 
            if (indexesOfTopicsWithRGQ.Contains(TopicPicker2.SelectedIndex)) RGQCheckbox.Enabled = true;
            else
            {
                RGQCheckbox.Enabled = false;
                RGQCheckbox.Checked = false;
            }
        }

        private void StartPracticeFromTopic(object sender, EventArgs e)
        {
            try
            {
                int noOfQuestions = (int)Math.Abs(Math.Round(NoQuestionSelector.Value));
                Topic selectedTopic = topicList[TopicPicker2.SelectedIndex];

                // any difficulty, selected topic, any teacher
                List<Question> topicQuestions = dbh.GetQuestionsMultimetric(new List<int> { 1, 2, 3, 4 }, selectedTopic, null);

                List<Question> listToPractice;

                RandomQuestionHelper rqh = new RandomQuestionHelper();
                rqh.PanelForDrawing = PanelForDrawing;

                // cases: less qs than noOfQuestions and no rgqs, <= qs than noOfQuestions and no rgqs, less qs than noOfQuestions and rgqs, <= qs than noOfQuestions and rgqs

                if (!RGQCheckbox.Checked)
                {
                    if (topicQuestions.Count < noOfQuestions)
                    {
                        // use questions available and tell user that practice has been shortened
                        listToPractice = topicQuestions.RandomiseList();
                    }
                    else
                    {
                        // take first noOfQuestions questions as practice list
                        listToPractice = topicQuestions.RandomiseList().Take(noOfQuestions).ToList();
                    }
                }
                else
                {
                    if (topicQuestions.Count < noOfQuestions)
                    {
                        int questionsToAdd = noOfQuestions - topicQuestions.Count;
                        // use all questions available and fill gaps with rgqs
                        for (int i = 0; i < questionsToAdd; i++)
                        {
                            // panel refresh
                            PanelForDrawing.Invalidate();
                            PanelForDrawing.Refresh();

                            topicQuestions.Add(rqh.GenerateQuestionFromTopic(selectedTopic));
                        }
                        listToPractice = topicQuestions.RandomiseList();
                    }
                    else
                    {
                        // use random questions and database questions in a 50/50 split
                        listToPractice = topicQuestions.RandomiseList().Take(noOfQuestions / 2).ToList();
                        for (int i = 0; i < noOfQuestions / 2; i++)
                        {
                            // panel refresh
                            PanelForDrawing.Invalidate();
                            PanelForDrawing.Refresh();

                            listToPractice.Add(rqh.GenerateQuestionFromTopic(selectedTopic));
                        }
                        listToPractice.RandomiseList().ToList();
                    }
                }

                Hide();
                QuestionAttemptMenu qam = new QuestionAttemptMenu(listToPractice, null, this);
                qam.Show();

            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        private void LoadStudentAnalysis()
        {
            List<QuestionAttempt> questionAttempts = dbh.GetStudentQuestionAttempts(Program.loggedInUser);
            Dictionary<int, double> topicAnalysis = sh.AnalyseStudentQuestionAttempts(questionAttempts);

            int topicsToTake = Math.Min(3, topicAnalysis.Count);
            List<Topic> worstAnsweredTopics = sh.GetWorstAnsweredTopics(topicAnalysis).Take(topicsToTake).Select(x => dbh.GetTopicFromId(x)).ToList();
            List<Topic> bestAnsweredTopics = sh.GetBestAnsweredTopics(topicAnalysis).Take(topicsToTake).Select(x => dbh.GetTopicFromId(x)).ToList();

            StringBuilder analysisText = new StringBuilder();
            analysisText.AppendLine("Topics to practice:");

            foreach (Topic topic in worstAnsweredTopics)
            {
                analysisText.AppendLine($"- {topic.TopicName}: {Math.Round(topicAnalysis[topic.TopicId], 2)}");
            }

            analysisText.AppendLine();
            analysisText.AppendLine("Strengths:");

            foreach (Topic topic in bestAnsweredTopics)
            {
                analysisText.AppendLine($"- {topic.TopicName}: {Math.Round(topicAnalysis[topic.TopicId], 2)}");
            }

            AnalysisLabel.Text = analysisText.ToString();

            List<Topic> lastPracticedTopics = dbh.GetStudentLastPracticedTopics(Program.loggedInUser);
            lastPracticedTopics.Reverse();

            int lastPracticedTopicsToTake = Math.Min(3, lastPracticedTopics.Count);

            StringBuilder whileText = new StringBuilder();
            whileText.AppendLine("Not covered in a while:");
            
            foreach (Topic topic in lastPracticedTopics.Take(lastPracticedTopicsToTake))
            {
                whileText.AppendLine($"- {topic.TopicName}");
            }

            WhileLabel.Text = whileText.ToString();
        }
    }
}
