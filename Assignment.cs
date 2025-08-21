using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nea_backend
{
    public class Assignment
    {
        // fields
        private int assignmentId;
        private User setter;
        private string homeworkName;
        private DateTime homeworkDueDate;
        private List<Question> questionList;
        private Class targetClass;

        // properties
        public int AssignmentId { get { return assignmentId; }  set { assignmentId = value; } }
        public User Setter { get { return setter; } set { setter = value; } }
        public string HomeworkName { get { return homeworkName; } set { homeworkName = value; } }
        public DateTime HomeworkDueDate { get { return homeworkDueDate; } set { homeworkDueDate = value; } }
        public List<Question> QuestionList { get { return questionList; } set { questionList = value; } }
        public Class TargetClass { get { return targetClass; } set { targetClass = value; } }

        // constructor
        public Assignment(int assignmentId, User setter, string homeworkName, DateTime homeworkDueDate, List<Question> questionList, Class targetClass)
        {
            this.assignmentId = assignmentId;
            this.setter = setter;
            this.homeworkName = homeworkName;
            this.homeworkDueDate = homeworkDueDate;
            this.questionList = questionList;
            this.targetClass = targetClass;
        }
    }
}
