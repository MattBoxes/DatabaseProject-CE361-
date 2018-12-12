using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Student : IComparable
    {
        // Variables in scope
        public string Student_Major; 
        /// <summary>
        /// Create default value constructor 
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="id"></param>
        /// <param name="pw"></param>
        /// <param name="major"></param>
        public Student(string firstname, string lastname, string id, string pw, string major)
            //: base(firstname, lastname, pw, id)
        {
            this.Student_Major = major;
        }
        public int CompareTo(object obj)
        {
            return 0;
        }
    }
}
