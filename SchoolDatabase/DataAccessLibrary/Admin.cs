using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Windows.UI.Xaml.Controls;

namespace DataAccessLibrary
{
    /// <summary>
    /// The Admin class contains the definition and methods used by the database
    /// to define the Admin user, who has full control of the database and all its
    /// information.
    /// </summary>
    public class Admin : People, IComparable <Admin>
    {
        List<Course> ListOfCourses;
        List<People> ListOfUsers;


        /// <summary>
        /// Constructor for Admin Class. Creates the Admin's First Name,
        /// Last Name, Password, and ID.
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="id"></param>
        /// <param name="pw"></param>
        public Admin(string firstname, string lastname, int id, string pw)
            : base(firstname, lastname, id, pw)  {}
      


        /// <summary>
        /// Insert into Course Table if Course ID does not exist yet, if already exists ignore the command
        /// </summary>
        /// <param name="courseID"></param>
        /// <param name="courseName"></param>
        public void AddCourse(string courseID, string courseName)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT OR IGNORE INTO Course (Course_ID, Course_Name) " +
                                                        $"VALUES ('{courseID}', '{courseName}')";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }


        /// <summary>
        /// Remove a course from the Table Course
        /// </summary>
        /// <param name="courseID"></param>
        /// <param name="courseName"></param>
        public void RemoveCourse(string courseID)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"DELETE FROM Course WHERE Course_ID = {courseID};";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public void EditCourseName(string courseName, string newCourseName)
        {
            if ((courseName != null) && (newCourseName != null))
            {
                throw new NotImplementedException();
            }
        }

        public void AddStudent(string firstname, string lastname, int id, string pw)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT OR IGNORE INTO Student (Student_ID, Password, First_Name, Last_Name) " +
                                                        $"VALUES ('{id}', '{pw}', '{firstname}', '{lastname}')";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public void AddProfessor(string firstname, string lastname, int id, string pw)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT OR IGNORE INTO Professor (Professor_ID, Password, First_Name, Last_Name) " +
                                                        $"VALUES ('{id}', '{pw}', '{firstname}', '{lastname}')";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }


        public void RemoveProfessor(int profID)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"DELETE FROM Professor WHERE Professor_ID = {profID};";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public void RemoveStudent(int studentID)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"DELETE FROM Course WHERE Course_ID = {studentID};";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public void EditUserName(string nfirstName, string nlastname, string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        public void EditStudentGrade(string firstname, string lastname, string coursename, string newGrade)
        {
            throw new NotImplementedException();
        }

        public void AddStudentToCourse(string firstname, string lastname, string coursename)
        {
            throw new NotImplementedException();
        }

        public void AddProfToCourse(string firstname, string lastname, string coursename)
        {
            throw new NotImplementedException();
        }
      
        public void RemoveStudentFromCourse(string firstname, string lastname, string coursename)
        {
            throw new NotImplementedException();
        }

        public void RemoveProfFromCourse(string firstname, string lastname, string coursename)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Helper function to get all values of the Course_Name column from Course Table
        /// </summary>
        /// <returns></returns>
        private List<string> GetListOfCourseNames()
        {
            List<string> CourseNames = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Course_Name from Course", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    CourseNames.Add(query.GetString(0));
                }

                db.Close();
            }

            return CourseNames;
        }

        private List<string> GetListOfCourseIDs()
        {
            List<string> CourseIDs = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Course_ID from Course", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    CourseIDs.Add(query.GetString(0));
                }

                db.Close();
            }
            return CourseIDs;
        }

        public List<string> ViewListOfCourses()
        {
            List<Course> courseList = new List<Course>();

            List<string> courseIDs = GetListOfCourseIDs();
            List<string> courseNames = GetListOfCourseNames();
            int i = 0;
            foreach (string s in courseIDs)
            {
                courseList[i] = new Course(courseNames[i], courseIDs[i]);
                i++;
            }

            i = 0;
            List<string> ctlList = new List<string>();
            foreach (Course course in courseList)
            {
                ctlList[i] = courseList[i].ToString();
                i++;
            }

            return ctlList;
        }

        public void ViewListOfUsers()
        {
            throw new NotImplementedException();
        }

        public void EditStudentMajor(string firstname, string lastname, string newMajor)
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

        public void PromoteUser(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Returns the string of the Admin's First Name, Last Name,
        /// and ID
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if ((this.FirstName != null) && (this.LastName != null) && (this.Password != null))
                return $"{this.FirstName} {this.LastName}\nID: {Id}\nPassword {Password}";
            else
                return $"Null character entered";
        }
        
        /// <summary>
        /// Method to display a popup window when entering invalid Admin information
        /// </summary>
        private async void DisplayInvalidAdminEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Admin information is invalid.",
                CloseButtonText = "OK"
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync();
        }
        
        
        /// <summary>
        /// CompareTo Implementation of IComparable Interface that compares Admins by First Name, then 
        /// Last Name, then unique ID.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Admin obj)
        {
            if (obj == null)
            {
                DisplayInvalidAdminEntry();
                return -1;
            }
            else
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
        }
    }
}
