using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    class Course
    {
        public string Name { get; set; }

        public short Id { get; set; }

        public char Grade { get; set; }

        public List<Student> ListOfStudents { get; set; }

        public Professor Prof { get; set; }

        public Course(string inName, short inID)
        {
            this.Name = inName;
            this.Id = inID;
        }

    }
}
