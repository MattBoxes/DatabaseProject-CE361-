using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Windows.UI.Xaml.Controls;

namespace DataAccessLibrary
{
    public class Admin : People, IComparable <Admin>

    {
        List<Course> ListOfCourses;
        List<People> ListOfUsers;

        /// <summary>
        /// Admin Constructor. The default name of the admin is "Admin". The default Id is "0"
        /// </summary>
        public Admin(string firstname, string lastname, int id, string pw)
            : base(firstname, lastname, id, pw) { }

        public void AddCourse(string courseID, string courseName)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO Course (Course_ID, Course_Name) " +
                                                        $"VALUES ('{courseID}', '{courseName}')";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }
        public void RemoveCourse(string courseName)
        {

        }
        public void EditCourseName(string courseName, string newCourseName)
        {

        }
        public void AddUser(string firstname, string lastname, string id, string pw)
        {

        }
        public void RemoveUser(string firstname, string lastname)
        {

        }

        public Admin EditUserName(string nfirstName, string nlastname, string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        public Admin EditStudentGrade(string firstname, string lastname, string coursename, string newGrade)
        {
            throw new NotImplementedException();
        }

        public Admin AddStudentToCourse(string firstname, string lastname, string coursename)
        {
            throw new NotImplementedException();
        }

        public Admin AddProfToCourse(string firstname, string lastname, string coursename)
        {
            throw new NotImplementedException();
        }

        public Admin RemoveStudentFromCourse(string firstname, string lastname, string coursename)
        {
            throw new NotImplementedException();
        }

        public Admin RemoveProfFromCourse(string firstname, string lastname, string coursename)

        {
            throw new NotImplementedException();
        }


        public List<string> GetListOfCourseNames()
        {
            List<string> CourseNames = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Course_Name from Course", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    CourseNames.Add(query.GetString(0));
                }

                db.Close();
            }

            return CourseNames;
        }

        public List<string> GetListOfCourseIDs()
        {
            List<string> CourseIDs = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Course_ID from Course", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    CourseIDs.Add(query.GetString(0));
                }

                db.Close();
            }

            return CourseIDs;
        }



        

        public Admin EditStudentMajor(string firstname, string lastname, string newMajor)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Admin PromoteUser(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public async void DisplayInvalidEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Admin information is invalid.",
                CloseButtonText = "OK"
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync();
        }

        public int CompareTo(Admin obj)
        {
            if (obj != null)
            {
                if (LastName.CompareTo(obj.LastName) == 0)
                {
                    if (FirstName.CompareTo(obj.FirstName) == 0)
                    {
                        return Id - obj.Id;
                    }
                    return FirstName.CompareTo(obj.FirstName);
                }
                return LastName.CompareTo(obj.LastName);
            }
            else
            {
                DisplayInvalidEntry();
                return -1;
            }
        }
    }
}
