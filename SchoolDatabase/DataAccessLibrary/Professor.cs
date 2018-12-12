using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Professor : People
    {
        public string Prof_Degree;
        public List<Course> ListOfCourses;

        public Professor(string firstname, string lastname, int id, string pw, string degree)
            : base(firstname, lastname, id, pw)
        {
            this.Prof_Degree = degree;
        }

        public void DropStudentFromCourse (Student std, Course course)
        {

        }

        public void ChangeGrade (Student std, char newGrade)
        {

        }

        public void AddStudentToCourse (Student std, Course course)
        {

        }
    }
}
