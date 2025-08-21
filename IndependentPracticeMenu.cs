using nea_backend;
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

namespace nea_ui
{
    public partial class IndependentPracticeMenu : Form
    {
        private bool canSubmit = false;
        private List<Topic> topicList;
        private List<Question> questionsFromSearch;

        private _Topic[] topicsWithRGQ = { _Topic.AdjectivesAdverbs, _Topic.Graphs, _Topic.Inequalities, _Topic.Sequences, _Topic.SimultaneousEq, _Topic.Quadratics, _Topic.AveragesRangesModeMedian, _Topic.PerimeterAreaVolume };
        int[] indexesOfTopicsWithRGQ;

        private DatabaseHelper dbh = new DatabaseHelper();
        private StatisticsHelper sh = new StatisticsHelper();

        public IndependentPracticeMenu()
        {
            InitializeComponent();
            SearchButton.Enabled = false;
            PracticeThisQButton.Enabled = false;
            RGQCheckbox.Enabled = false;

            // initialise a panel for graph drawing
            PanelForDrawing.SendToBack();
            PanelForDrawing.Width = 400;
            PanelForDrawing.Height = 400;

            topicList = dbh.GetAllTopics();

            // fetch the indexes from the topicList where the topic has rgqs available
            indexesOfTopicsWithRGQ = topicList.Where(x => topicsWithRGQ.Contains((_Topic)x.TopicId)).Select(x => topicList.IndexOf(x)).ToArray();

            // practice qs individually from database
            TopicPicker.DataSource = topicList.Select(x => x.TopicName).ToArray();
            TopicPicker.SelectedIndex = -1;

            // practice qs by topic
            TopicPicker2.DataSource = topicList.Select(x => x.TopicName).ToArray();
            TopicPicker2.SelectedIndex = -1;

            LoadStudentAnalysis();
        }

        /// <summary>
        /// A method to test fields for data. Here: only allow questions to be searched for if at least one difficulty has been selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestForData(object sender, EventArgs e)
        {
            PracticeThisQButton.Enabled = false;
            canSubmit = (DifficultyCheckbox1.Checked || DifficultyCheckbox2.Checked || DifficultyCheckbox3.Checked || DifficultyCheckbox4.Checked);
            SearchButton.Enabled = canSubmit;
        }

        /// <summary>
        /// On search: take inputs from fields and parse these into a database query to fetch all questions which match these criteria.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitSearch(object sender, EventArgs e)
        {
            try
            {
                // create a list of difficulties which are selected
                List<int> selectedDifficulties = new List<int>();
                if (DifficultyCheckbox1.Checked) selectedDifficulties.Add(1);
                if (DifficultyCheckbox2.Checked) selectedDifficulties.Add(2);
                if (DifficultyCheckbox3.Checked) selectedDifficulties.Add(3);
                if (DifficultyCheckbox4.Checked) selectedDifficulties.Add(4);

                // determine if/which topic is selected from the dropdown
                Topic selectedTopic = null;
                if (TopicPicker.SelectedIndex != -1) selectedTopic = topicList[TopicPicker.SelectedIndex];

                // fetch questions based on these two criteria
                questionsFromSearch = dbh.GetQuestionsMultimetric(selectedDifficulties, selectedTopic, null);

                // display questions in the listbox, truncate question content.
                QuestionMatches.DataSource = questionsFromSearch.Select(x => $"{x.Topic.TopicName}\t{x.QuestionContent.Substring(0, Math.Min(x.QuestionContent.Length, 20))}...\tD{x.Difficulty}\tby {x.Author.FirstName} {x.Author.Surname}").ToArray();
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// If a question is selected, allow the student to practice this question.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuestionSelectedEvent(object sender, EventArgs e)
        {
            PracticeThisQButton.Enabled = true;
        }

        /// <summary>
        /// A method to close this form and return to the student dashboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackToDashboard(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// On practice start (from single question): once a student selects a question, start a question attempt series with this question only.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartPracticeFromQuestion(object sender, EventArgs e)
        {
            // fetch the selected question
            Question selectedQuestion = questionsFromSearch[QuestionMatches.SelectedIndex];

            // hide this form and create a new QuestionAttemptMenu form, referencing this question as the only one to complete.
            Hide();
            QuestionAttemptMenu qam = new QuestionAttemptMenu(new List<Question> { selectedQuestion }, null, this);
            qam.Show();
        }

        /// <summary>
        /// A method to determine whether there are randomly generated questions for the selected topic.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckForRandomQs(object sender, EventArgs e)
        {
            // if no index selected
            if (TopicPicker2.SelectedIndex == -1) return; 
            // if the selected topic has possible rgqs
            if (indexesOfTopicsWithRGQ.Contains(TopicPicker2.SelectedIndex)) RGQCheckbox.Enabled = true;
            else
            {
                RGQCheckbox.Enabled = false;
                RGQCheckbox.Checked = false;
            }
        }

        /// <summary>
        /// On practice start (from topic select): using criteria, fetch questions from database, then start a practice with this list of questions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartPracticeFromTopic(object sender, EventArgs e)
        {
            try
            {
                // fetch the number of qs and selected topic as criteria
                int noOfQuestions = (int)Math.Abs(Math.Round(NoQuestionSelector.Value));

                // if no questions or topic selected, prevent user from starting practice
                if (noOfQuestions == 0) throw new Exception("Cannot start a practice of 0 questions.");
                if (TopicPicker2.SelectedIndex == -1) throw new Exception("A topic needs to be selected to practice with.");

                Topic selectedTopic = topicList[TopicPicker2.SelectedIndex];

                // any difficulty, selected topic, any teacher
                List<Question> topicQuestions = dbh.GetQuestionsMultimetric(new List<int> { 1, 2, 3, 4 }, selectedTopic, null);

                List<Question> listToPractice;

                RandomQuestionHelper rqh = new RandomQuestionHelper();

                // panel for drawing in case the graphs topic has been selected
                rqh.PanelForDrawing = PanelForDrawing;

                // cases: less qs than noOfQuestions and no rgqs, <= qs than noOfQuestions and no rgqs, less qs than noOfQuestions and rgqs, <= qs than noOfQuestions and rgqs

                // if NOT using rgqs
                if (!RGQCheckbox.Checked)
                {
                    // if there are fewer questions available than requested
                    if (topicQuestions.Count < noOfQuestions)
                    {
                        // use questions available and tell user that practice has been shortened
                        listToPractice = topicQuestions.RandomiseList();
                    }
                    // otherwise
                    else
                    {
                        // take first noOfQuestions questions as practice list
                        listToPractice = topicQuestions.RandomiseList().Take(noOfQuestions).ToList();
                    }
                }
                else
                {
                    // if there are fewer questions available than requested
                    if (topicQuestions.Count < noOfQuestions)
                    {
                        int questionsToAdd = noOfQuestions - topicQuestions.Count;
                        // use all questions available and fill gaps with rgqs
                        for (int i = 0; i < questionsToAdd; i++)
                        {
                            // panel refresh for new drawings
                            PanelForDrawing.Invalidate();
                            PanelForDrawing.Refresh();

                            topicQuestions.Add(rqh.GenerateQuestionFromTopic(selectedTopic));
                        }
                        listToPractice = topicQuestions.RandomiseList();
                    }
                    // otherwise
                    else
                    {
                        // use random questions and database questions in a 50/50 split
                        listToPractice = topicQuestions.RandomiseList().Take(Math.Max(noOfQuestions / 2, 1)).ToList();
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

                if (listToPractice.Count == 0) throw new Exception("Could not find any questions which matched the criteria.");

                Hide();
                // start practice using this question set
                QuestionAttemptMenu qam = new QuestionAttemptMenu(listToPractice, null, this);
                qam.Show();

            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// A method to fetch student performance to allow the student to find out their strengths and weaknesses, and to suggest what to practice next.
        /// </summary>
        private void LoadStudentAnalysis()
        {
            try
            {
                // fetch student question attempts from DB
                List<QuestionAttempt> questionAttempts = dbh.GetStudentQuestionAttempts(Program.loggedInUser);
                // use the statistical analysis method to find out which topics the student performs best in/worst in
                Dictionary<int, double> topicAnalysis = sh.AnalyseStudentQuestionAttempts(questionAttempts);

                // in the case the student has practiced fewer than 3 topics overall
                int topicsToTake = Math.Min(3, topicAnalysis.Count);
                // since the sh method returns only topic ID, fetch topic based on ID from DB
                List<Topic> worstAnsweredTopics = sh.GetWorstAnsweredTopics(topicAnalysis).Take(topicsToTake).Select(x => dbh.GetTopicFromId(x)).ToList();
                List<Topic> bestAnsweredTopics = sh.GetBestAnsweredTopics(topicAnalysis).Take(topicsToTake).Select(x => dbh.GetTopicFromId(x)).ToList();

                // create a string containing topics of strength and weakness and display this
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

                // fetch last practiced topics from the database.
                List<Topic> lastPracticedTopics = dbh.GetStudentLastPracticedTopics(Program.loggedInUser);
                lastPracticedTopics.Reverse();

                // in the case less than 3 topics have been studied overall
                int lastPracticedTopicsToTake = Math.Min(3, lastPracticedTopics.Count);

                // create a string containing topics not studied in a while and display this
                StringBuilder whileText = new StringBuilder();
                whileText.AppendLine("Not covered in a while:");

                foreach (Topic topic in lastPracticedTopics.Take(lastPracticedTopicsToTake))
                {
                    whileText.AppendLine($"- {topic.TopicName}");
                }

                WhileLabel.Text = whileText.ToString();
            }
            catch
            {
                AnalysisLabel.Text = "Unable to load statistical analysis.";
                WhileLabel.Text = "Unable to load statistical analysis";
            }
        }
    }
}
