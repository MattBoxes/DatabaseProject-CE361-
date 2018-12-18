using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Grade
    {
        public string CourseID { get; set; }
        public int StudentID { get; set; }
        public int GradePoint { get; set; }

        public Grade(string courseid, int studentid, int point)
        {
            this.CourseID = courseid;
            this.StudentID = studentid;
            this.GradePoint = point;
        }

    }

    
}
