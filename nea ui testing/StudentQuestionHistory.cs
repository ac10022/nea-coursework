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
            questionAttempts = dbh.GetStudentQuestionAttempts(studentRef);
            topicAnalysis = sh.AnalyseStudentQuestionAttempts(questionAttempts);

            int topicsToTake = Math.Min(3, topicAnalysis.Count);
            List<Topic> worstAnsweredTopics = sh.GetWorstAnsweredTopics(topicAnalysis).Take(topicsToTake).Select(x => dbh.GetTopicFromId(x)).ToList();
            List<Topic> bestAnsweredTopics = sh.GetBestAnsweredTopics(topicAnalysis).Take(topicsToTake).Select(x => dbh.GetTopicFromId(x)).ToList();

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

            AttemptList.DataSource = questionAttempts.Select(x => $"{x.TimeOfAttempt.ToShortDateString()}\t{(x.WasCorrect ? '✓' : '✗')}\t{(x.Question != null ? x.Question.QuestionContent.Substring(0, Math.Min(20, x.Question.QuestionContent.Length)) : PLACEHOLDER_TEXT)}...").ToArray();
        }

        private void QuestionSelectEvent(object sender, EventArgs e)
        {
            try
            {
                QuestionAttempt questionAttempt = questionAttempts[AttemptList.SelectedIndex];

                if (questionAttempt.Question != null)
                {
                    TopicLabel.Text = $"Topic: {questionAttempt.Question.Topic.TopicName}";
                    DifficultyLabel.Text = $"Difficulty: {questionAttempt.Question.Difficulty}";
                    ContentLabel.Text = $"Content preview: {questionAttempt.Question.QuestionContent.Substring(0, Math.Min(50, questionAttempt.Question.QuestionContent.Length))}";
                    AnswerLabel.Text = $"Answer: {string.Join(", ", questionAttempt.Question.Answer)}";
                }
                else
                {
                    TopicLabel.Text = "Topic: N/A (RGQ)";
                    DifficultyLabel.Text = "Difficulty: N/A (RGQ)";
                    ContentLabel.Text = "Content preview: N/A (RGQ)";
                    AnswerLabel.Text = "Answer: N/A (RGQ)";
                }

                StudentAnswerLabel.Text = $"Student answer: {questionAttempt.StudentAnswer}";

                // if correct, highlight green, else highlight red
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
                    timeDifference = questionAttempt.TimeOfAttempt.Subtract(questionAttempt.TimeQuestionOpened);
                }
                TimeTakenLabel.Text = $"{timeDifference.Minutes}m {timeDifference.Seconds}s";
            }
            catch (Exception ex)
            {
                ErrorHandler eh = new ErrorHandler(ex.Message);
                eh.DisplayErrorForm();
            }
        }
    }
}
