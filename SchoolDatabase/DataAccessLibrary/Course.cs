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

        public int StudentId { get; set; }

        public int ProfessorId { get; set; }

        public Course(string inName, string inID)
        {
            this.Name = inName;
            this.Id = inID;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
