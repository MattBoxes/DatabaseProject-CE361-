using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

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
            : base(firstname, lastname, id, pw)  {}


        public void AddCourse(string courseID, string courseName)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Course (CourseId, CourseName) " +
                                                        $"VALUES ({courseID}, {courseName})";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }
        public void removeCourse(string courseName)
        {

        }
        public void editCourseName(string courseName, string newCourseName)
        {

        }
        public void addUser(string firstname, string lastname, string id, string pw)
        {

        }
        public void removeUser(string firstname, string lastname)
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
        public void viewListOfCourses()
        {
            List<string> CourseIds = new List<string>();
            List<string> CourseNames = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Course_ID from Course", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    CourseIds.Add(query.GetString(0));
                }

                selectCommand.CommandText = "SELECT Course_Name from Course";

                while (query.Read())
                {
                    CourseNames.Add(query.GetString(0));
                }

                db.Close();
            }

            //TO DO: show the 2 lists in listview
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
