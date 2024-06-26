using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nea_prototype_full
{
    public class Assignment
    {
        // fields
        private int assignmentId;
        private User setter;
        private string homeworkName;
        private DateTime homeworkDueDate;

        // properties
        public int AssignmentId { get { return assignmentId; }  set { assignmentId = value; } }
        public User Setter { get { return setter; } set { setter = value; } }
        public string HomeworkName { get { return homeworkName; } set { homeworkName = value; } }
        public DateTime HomeworkDueDate { get { return homeworkDueDate; } set { homeworkDueDate = value; } }

        // constructor
        public Assignment(int assignmentId, User setter, string homeworkName, DateTime homeworkDueDate)
        {
            this.assignmentId = assignmentId;
            this.setter = setter;
            this.homeworkName = homeworkName;
            this.homeworkDueDate = homeworkDueDate;
        }
    }
}
