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

        public int Id { get; set; }

        public int StudentId { get; set; }

        public int ProfessorId { get; set; }

        public Course(string inName, int inID)
        {
            this.Name = inName;
            this.Id = inID;
        }

    }
}
