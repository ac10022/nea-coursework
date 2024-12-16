using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nea_prototype_full
{
    internal class QuestionAttempt
    {
        // fields
        private int attemptId;
        private bool wasCorrect;
        private string studentAns;
        private DateTime timeOfAttempt;
        private DateTime timeQuestionOpened;
        private User student;
        private Question question;
        private _Topic pseudotopic;

        public int AttemptId { get { return attemptId; } set { attemptId = value; } }
        public bool WasCorrect { get { return wasCorrect; } set { wasCorrect = value; } }
        public string StudentAnswer { get { return studentAns; } set { studentAns = value; } }
        public DateTime TimeOfAttempt { get { return timeOfAttempt; } set { timeOfAttempt = value; } }
        public DateTime TimeQuestionOpened { get { return timeQuestionOpened; } set { timeQuestionOpened = value; } }
        public User Student { get { return student; } set { student = value; } }
        public Question Question { get { return question; } set { question = value; } }
        public _Topic Pseudotopic { get { return pseudotopic; } set { pseudotopic = value; } }

        public QuestionAttempt(int attemptId, bool wasCorrect, string studentAns, DateTime timeOfAttempt, DateTime timeQuestionOpened, User student, Question question)
        {
            this.attemptId = attemptId;
            this.wasCorrect = wasCorrect;
            this.studentAns = studentAns;
            this.timeOfAttempt = timeOfAttempt;
            this.timeQuestionOpened = timeQuestionOpened;
            this.student = student;
            this.question = question;
        }

        // pseudotopics are used by randomly generated questions so that topic evalulation can be calculated statistically
        public void AppendPseudotopic(_Topic topic)
        {
            this.pseudotopic = topic;
        }
    }
}
