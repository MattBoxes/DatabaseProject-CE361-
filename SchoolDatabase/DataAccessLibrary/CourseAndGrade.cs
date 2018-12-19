using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class CourseAndGrade
    {
        public string CourseName { get; set; }
        public int GradeInClass { get; set; }

        public CourseAndGrade(string cname, int gr)
        {
            this.CourseName = cname;
            this.GradeInClass = gr;
        }
    }
}
