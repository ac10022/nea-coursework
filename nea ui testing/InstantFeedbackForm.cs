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
    /// A form which displays each time a student submits an answer to a question. Displays instant feedback, and then shows the question answer key to show the student the correct question working.
    /// </summary>
    public partial class InstantFeedbackForm : Form
    {
        private Question questionRef;
        private List<Question> questionList;
        private Assignment assignmentRef;
        private Form formReturn;

        public InstantFeedbackForm(Question questionRef = null, List<Question> questionList = null, bool wasCorrect = false, Assignment assignmentRef = null, Form formReturnRef = null)
        {
            InitializeComponent();

            this.questionRef = questionRef;
            this.questionList = questionList;
            this.assignmentRef = assignmentRef;
            formReturn = formReturnRef;

            // if a question has just been answered
            if (questionRef != null)
            {
                // show correctness in label
                CorrectnessLabel.Text = wasCorrect ? "Correct!" : "Incorrect!";

                // show the answers in the feedback message if incorrect
                FeedbackMessage.Text = wasCorrect ? "You answered correctly!" : $"Your answer was incorrect, the correct answer(s) was/were {string.Join(", ", questionRef.Answer)}";

                // if an answer key is available for this question, display this
                if (questionRef.AnswerKey != null)
                {
                    AnswerKeyBox.Text = questionRef.AnswerKey;
                }
            }
        }

        /// <summary>
        /// When continue is selected: remove this question from the question series and progress to the next question.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinueEvent(object sender, EventArgs e)
        {
            // if there are more questions to practice
            if (questionList.Count != 0)
            {
                Hide();

                // continue the question attempts with the remaining questions
                QuestionAttemptMenu qam = new QuestionAttemptMenu(questionList, assignmentRef, formReturn);

                // form closed events
                qam.Closed += (s, args) =>
                {
                    Close();
                };
                qam.Show();
            }
            // otherwise close the menu and return to the independent practice menu/assignments menu
            else
            {
                Hide();
                formReturn.Show();
                Close();
            }
        }
    }
}
