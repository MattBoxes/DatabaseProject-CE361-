using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class Admin : People,IComparable

    {
        List<Course> ListOfCourses;
        List<People> ListOfUsers;
        /// <summary>
        /// Admin Constructor. The default name of the admin is "Admin". The default Id is "0"
        /// </summary>
        public Admin(string firstname, string lastname, string id, string pw)
            : base(firstname, lastname, id, pw)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Id = id;
            this.Password = pw;
        }
        public Admin addCourse(string courseName)
        {

        }
        public Admin removeCourse(string courseName)
        {

        }
        public Admin editCourseName(string courseName, string newCourseName)
        {

        }
        public Admin addUser(string firstname, string lastname, string id, string pw)
        {

        }
        public Admin removeUser(string firstname, string lastname)
        {

        }
        public Admin editUserName(string nfirstName, string nlastname, string firstname, string lastname)
        {

        }
        public Admin editStudentGrade(string firstname, string lastname, string coursename, string newGrade)
        {

        }
        public Admin addStudentToCourse(string firstname, string lastname, string coursename)
        {

        }
        public Admin addProfToCourse(string firstname, string lastname, string coursename)
        {

        }
        public Admin removeStudentFromCourse(string firstname, string lastname, string coursename)
        {

        }
        public Admin removeProfFromCourse(string firstname, string lastname, string coursename)
        {

        }
        public Admin viewListOfCourses()
        {

        }
        public Admin viewListOfUsers()
        {

        }
        public Admin editStudentMajor(string firstname, string lastname, string newMajor)
        {

        }
        public Admin promoteUser(string firstname, string lastname)
        {

        }

        public int CompareTo(object obj)
        {
            try
            {
                if (obj == null)
                {
                    throw new NullReferenceException("Attempting to Compare NULL reference");
                }
                else
                {

                }
            }
            catch (NullReferenceException nEx)
            {
                
            }           
        }

    }
}
