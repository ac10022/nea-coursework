using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nea_backend
{
    public class Class
    {
        // fields
        private int classId;
        private string className;

        // properties
        public int ClassId { get { return classId; } }
        public string ClassName { get { return className; } }

        // constructor
        public Class(int classId, string className)
        {
            this.classId = classId;
            this.className = className;
        }
    }
}
