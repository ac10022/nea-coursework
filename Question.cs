using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nea_prototype_full
{
    internal class Question
    {
        // fields
        private int questionId;
        private Topic topic;
        private User author;
        private int difficulty;
        private string questionContent;
        private bool isMc;
        private List<string> answer;
        private string answerKey;
        private List<string> mcAnswers;
        private Image questionImage;
        
        // properties
        public int QuestionId { get { return questionId; } private set { questionId = value; } }
        public Topic Topic { get { return topic; } private set { topic = value; } }
        public User Author { get { return author; } private set { author = value; } }
        public int Difficulty
        {
            get { return difficulty; }
            // limits the difficulty to an integer between 1 and 4
            private set { difficulty = Math.Abs(value) > 4 ? 4 : value; }
        }
        public string QuestionContent { get { return questionContent; } private set { questionContent = value; } }
        public bool IsMc { get { return isMc; } private set { isMc = value; } }
        // question may have more than 1 answer, e.g., two roots of an equation
        public List<string> Answer { get { return answer; } private set { answer = value; } }
        public string AnswerKey { get { return answerKey; } private set { answerKey = value; } }
        public List<string> McAnswers { get { return mcAnswers; } private set { mcAnswers = value; } }
        public Image QuestionImage { get { return questionImage; } private set { questionImage = value; } }

        // constructor
        public Question(Topic topic, int difficulty, string questionContent, List<string> answer, int questionId = -1, User author = null, string answerKey = "")
        {
            this.questionId = questionId;
            this.author = author;
            this.topic = topic;
            this.difficulty = difficulty;
            this.questionContent = questionContent;
            this.answer = answer;
            this.answerKey = answerKey;

            // mc and image fields, not initialised here
            this.isMc = false;
            this.mcAnswers = new List<string>();
            this.questionImage = new Bitmap(1, 1);
        }

        public void ForceMc(List<string> mcAnswers)
        {
            this.isMc = true;
            this.mcAnswers = mcAnswers;
        }

        public void AppendImage(Image image)
        {
            this.questionImage = image;
        }

        public override string ToString()
        {
            return $"QuestionId:\t{questionId}\nTopicId:\t{topic}\nAuthorId:\t{author}\nDifficulty:\t{difficulty}\nContent:\t{questionContent}\nAnswer(s):\t{string.Join(", ", answer)}\nAnswer Key\t{answerKey}\nMultiple Choice?\t{isMc}\nMC Answers\t{string.Join(", ", mcAnswers)}";
        }
    }
}
