using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nea_prototype_full
{
    public enum _Subject
    {
        English = 1,
        Maths = 2
    }
    public class Subject
    {
        private int subjectId;
        private string subjectName;

        public int SubjectId { get { return subjectId; } }
        public string SubjectName { get { return subjectName; } }

        public Subject(int subjectId, string subjectName)
        {
            this.subjectId = subjectId;
            this.subjectName = subjectName;
        }
    }
}
