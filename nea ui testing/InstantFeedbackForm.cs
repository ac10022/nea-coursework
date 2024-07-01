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
    public partial class InstantFeedbackForm : Form
    {
        private Question questionRef;
        private List<Question> questionList;
        private Assignment assignmentRef;
        public InstantFeedbackForm(Question questionRef = null, List<Question> questionList = null, bool wasCorrect = false, Assignment assignmentRef = null)
        {
            InitializeComponent();

            this.questionRef = questionRef;
            this.questionList = questionList;
            this.assignmentRef = assignmentRef;

            if (questionRef != null)
            {
                CorrectnessLabel.Text = wasCorrect ? "Correct!" : "Incorrect!";
                FeedbackMessage.Text = wasCorrect ? "You answered correctly!" : $"Your answer was incorrect, the correct answer(s) was/were {string.Join(", ", questionRef.Answer)}";
                if (questionRef.AnswerKey != null)
                {
                    AnswerKeyBox.Text = questionRef.AnswerKey;
                }
            }
        }

        private void ContinueEvent(object sender, EventArgs e)
        {
            if (questionList.Count != 0)
            {
                Hide();
                QuestionAttemptMenu qam = new QuestionAttemptMenu(questionList, assignmentRef);

                // form closed events
                qam.Closed += (s, args) =>
                {
                    Close();
                };
                qam.Show();
            }
            else
            {
                Close();
            }
        }
    }
}
