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
    /// <summary>
    /// A form through which a teacher can view all past question attempts of a student and it's attached data.
    /// </summary>
    public partial class StudentQuestionHistory : Form
    {
        private User studentRef;
        private List<QuestionAttempt> questionAttempts;
        private const string PLACEHOLDER_TEXT = "Randomly generated question";
        private Dictionary<int, double> topicAnalysis;

        private DatabaseHelper dbh = new DatabaseHelper();
        private StatisticsHelper sh = new StatisticsHelper();
        public StudentQuestionHistory(User studentRef = null)
        {
            InitializeComponent();

            this.studentRef = studentRef;

            // loads student question history into the listbox
            RefreshQuestionHistoryData();
        }

        /// <summary>
        /// On question attempt selection: fetch question attempt and display all data attached to it in corresponding fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuestionSelectEvent(object sender, EventArgs e)
        {
            try
            {
                // if a question attempt is selected
                if (AttemptList.SelectedIndex != -1)
                {
                    // fetch selected question attempt
                    QuestionAttempt questionAttempt = questionAttempts[AttemptList.SelectedIndex];

                    // if the question attempt is a teacher-generated question, not RGQ (RGQs are not saved in question attempts)
                    if (questionAttempt.Question != null)
                    {
                        // display question data in textboxes
                        TopicLabel.Text = $"Topic: {questionAttempt.Question.Topic.TopicName}";
                        DifficultyLabel.Text = $"Difficulty: {questionAttempt.Question.Difficulty}";
                        ContentLabel.Text = $"Content preview: {questionAttempt.Question.QuestionContent.Substring(0, Math.Min(50, questionAttempt.Question.QuestionContent.Length))}";
                        AnswerLabel.Text = $"Answer: {string.Join(", ", questionAttempt.Question.Answer)}";
                    }
                    // else show fields as unavailable, it was a RGQ
                    else
                    {
                        TopicLabel.Text = "Topic: N/A (RGQ)";
                        DifficultyLabel.Text = "Difficulty: N/A (RGQ)";
                        ContentLabel.Text = "Content preview: N/A (RGQ)";
                        AnswerLabel.Text = "Answer: N/A (RGQ)";
                    }

                    StudentAnswerLabel.Text = $"Student answer: {questionAttempt.StudentAnswer}";

                    // if correct, highlight student answer green, else highlight red
                    if (questionAttempt.WasCorrect) StudentAnswerLabel.BackColor = Color.LightGreen;
                    else StudentAnswerLabel.BackColor = Color.Red;

                    TimeSpan timeDifference;
                    if (questionAttempt.TimeQuestionOpened == null)
                    {
                        // if none, default to 1 minute
                        timeDifference = new TimeSpan(0, 1, 0);
                    }
                    else
                    {
                        // else display time the student took to answer the question (time answered - time opened)
                        timeDifference = questionAttempt.TimeOfAttempt.Subtract(questionAttempt.TimeQuestionOpened);
                    }
                    TimeTakenLabel.Text = $"{timeDifference.Minutes}m {timeDifference.Seconds}s";
                }
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// On answer correctness override: flip correctness of a student's question attempt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OverrideEvent(object sender, EventArgs e)
        {
            try
            {
                // fetch question attempt to alter
                QuestionAttempt questionAttempt = questionAttempts[AttemptList.SelectedIndex];

                // alter correctness in database
                dbh.OverrideAttemptCorrectness(questionAttempt, !questionAttempt.WasCorrect);

                // refresh student question attempts on the form
                RefreshQuestionHistoryData();
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }

        /// <summary>
        /// A method to fetch a students question history, perform statistical analysis on it, and display this data on the form.
        /// </summary>
        private void RefreshQuestionHistoryData()
        {
            AttemptList.SelectedIndex = -1;
            
            // fetch question attempts from DB
            questionAttempts = dbh.GetStudentQuestionAttempts(studentRef);

            // perform statistical analysis
            topicAnalysis = sh.AnalyseStudentQuestionAttempts(questionAttempts);

            // take best and worst answered topics, if the student has studies fewer than 3 topics, take all
            int topicsToTake = Math.Min(3, topicAnalysis.Count);
            List<Topic> worstAnsweredTopics = sh.GetWorstAnsweredTopics(topicAnalysis).Take(topicsToTake).Select(x => dbh.GetTopicFromId(x)).ToList();
            List<Topic> bestAnsweredTopics = sh.GetBestAnsweredTopics(topicAnalysis).Take(topicsToTake).Select(x => dbh.GetTopicFromId(x)).ToList();

            // create a list of strength and weakness topics
            StringBuilder analysisText = new StringBuilder();
            analysisText.AppendLine("Weaknesses:");

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

            // change the data source to show current state of DB for a students question attempts
            AttemptList.DataSource = questionAttempts.Select(x => $"{x.TimeOfAttempt.ToShortDateString()}\t{(x.WasCorrect ? '✓' : '✗')}\t{(x.Question != null ? x.Question.QuestionContent.Substring(0, Math.Min(20, x.Question.QuestionContent.Length)) : PLACEHOLDER_TEXT)}...").ToArray();
        }
    }
}
