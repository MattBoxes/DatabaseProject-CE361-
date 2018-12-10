using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Course
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public int Grade { get; set; }

        public List<Student> ListOfStudents { get; set; }

        public Professor Prof { get; set; }

        public Course(string inName, string inID)
        {
            this.Name = inName;
            this.Id = inID;
        }

    }
}
