﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Windows.UI.Xaml.Controls;

namespace DataAccessLibrary
{
    /// <summary>
    /// An admin can add and remove users, assign professors to courses, and add and remove courses.
    /// </summary>
    public class Admin : People, IComparable<Admin>
    {
        

        /// <summary>
        /// Constructor for Admin class.
        /// </summary>
        public Admin(string firstname, string lastname, int id, string pw)
            : base(firstname, lastname, id, pw)  {}
      
        /// <summary>
        /// Insert into Course Table if Course ID does not exist yet, if already exists ignore the command
        /// </summary>
        public void AddCourse(string courseID, string courseName, string profid)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT OR IGNORE INTO Course (Course_ID, Course_Name, Professor_ID) " +
                                                        $"VALUES ('{courseID}', '{courseName}', '{profid}')";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        /// <summary>
        /// Remove a course from the Table Course
        /// </summary>
        public void RemoveCourse(string courseID)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"DELETE FROM Course WHERE Course_ID = '{courseID}';";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        
        /// <summary>
        /// Insert a student row in Student table in databse
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="id"></param>
        /// <param name="pw"></param>
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


        /// <summary>
        /// Insert a Professor row to Professor Table in database
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="id"></param>
        /// <param name="pw"></param>
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


        /// <summary>
        /// Uses professor ID to remove that row from databse
        /// </summary>
        /// <param name="profID"></param>
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


        /// <summary>
        /// Uses student ID to remove that row from database
        /// </summary>
        /// <param name="studentID"></param>
        public void RemoveStudent(int studentID)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"DELETE FROM Student WHERE Student_ID = {studentID};";

                insertCommand.ExecuteReader();

                db.Close();
            }
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

                SqliteCommand selectCommand = new SqliteCommand("SELECT Course_Name FROM Course ORDER BY Course_ID;", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    CourseNames.Add(query.GetString(0));
                }

                db.Close();
            }

            return CourseNames;
        }

        /// <summary>
        /// Helper function to get values of Course_ID from Course Table
        /// </summary>
        /// <returns></returns>
        private List<string> GetListOfCourseIDs()
        {
            List<string> CourseIDs = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Course_ID FROM Course ORDER BY Course_ID;", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    CourseIDs.Add(query.GetString(0));
                }

                db.Close();
            }
            return CourseIDs;
        }

        private List<string> GetListOfProfIDs()
        {
            List<string> ProfIDs = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Professor_ID FROM Course ORDER BY Course_ID;", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    ProfIDs.Add(query.GetString(0));
                }

                db.Close();
            }
            return ProfIDs;
        }


        /// <summary>
        /// Get a List of Courses from database
        /// Calls helper functions GetListOfCourseIDs and GetListOfCourseNames
        /// </summary>
        /// <returns></returns>
        public List<Course> GetListOfCourses()
        {
            List<Course> courseList = new List<Course>();

            List<string> courseIDs = GetListOfCourseIDs();
            List<string> courseNames = GetListOfCourseNames();
            List<string> profIDs = GetListOfProfIDs();

            for (int i = 0; i < courseIDs.Count; i++)
            {
                courseList.Add(new Course(courseNames[i], courseIDs[i], Int32.Parse(profIDs[i])));
            }

            return courseList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<int> GetListOfStudentIDs()
        {
            List<int> StudentIDs = new List<int>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Student_ID FROM Student", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    StudentIDs.Add(Int32.Parse(query.GetString(0)));
                }

                db.Close();
            }
            return StudentIDs;
        }

        private List<string> GetListOfStudentFirstNames()
        {
            List<string> firstNames = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT First_Name FROM Student", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    firstNames.Add(query.GetString(0));
                }

                db.Close();
            }

            return firstNames;
        }

        private List<string> GetListOfStudentLastNames()
        {
            List<string> lastNames = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Last_Name FROM Student", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    lastNames.Add(query.GetString(0));
                }

                db.Close();
            }

            return lastNames;
        }

        private List<string> GetListOfStudentPasswords()
        {
            List<string> passwords = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Password FROM Student", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    passwords.Add(query.GetString(0));
                }

                db.Close();
            }

            return passwords;
        }

        public List<People> GetListOfStudents()
        {
            List<People> studentList = new List<People>();

            List<int> studentIDs = GetListOfStudentIDs();
            List<string> studentPasswords = GetListOfStudentPasswords();
            List<string> studentFirstNames = GetListOfStudentFirstNames();
            List<string> studentLastNames = GetListOfStudentLastNames();

           
            for (int i = 0; i < studentIDs.Count; i++)
            {
                studentList.Add(new People(studentFirstNames[i], studentLastNames[i], studentIDs[i], studentPasswords[i]));
            }

            return studentList;
        }

        private List<int> GetListOfProfessorIDs()
        {
            List<int> ProfessorIDs = new List<int>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Professor_ID from Professor", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    ProfessorIDs.Add(Int32.Parse(query.GetString(0)));
                }

                db.Close();
            }
            return ProfessorIDs;
        }

        private List<string> GetListOfProfessorFirstNames()
        {
            List<string> firstNames = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT First_Name from Professor", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    firstNames.Add(query.GetString(0));
                }

                db.Close();
            }

            return firstNames;
        }

        private List<string> GetListOfProfessorLastNames()
        {
            List<string> lastNames = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Last_Name from Professor", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    lastNames.Add(query.GetString(0));
                }

                db.Close();
            }

            return lastNames;
        }

        private List<string> GetListOfProfessorPasswords()
        {
            List<string> passwords = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Password from Professor", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    passwords.Add(query.GetString(0));
                }

                db.Close();
            }

            return passwords;
        }

        public List<People> GetListOfProfessors()
        {
            List<People> profList = new List<People>();

            List<int> profIDs = GetListOfProfessorIDs();
            List<string> profPasswords = GetListOfProfessorPasswords();
            List<string> profFirstNames = GetListOfProfessorFirstNames();
            List<string> profLastNames = GetListOfProfessorLastNames();

       
            for(int i = 0; i < profIDs.Count; i++)
            {
                profList.Add(new People(profFirstNames[i], profLastNames[i], profIDs[i], profPasswords[i]));
            }

            return profList;
        }

        public void EditStudentMajor(string firstname, string lastname, string newMajor)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Displays a pop-up window when invalid admin information is being used.
        /// </summary>
        private async void DisplayInvalidAdminEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Invalid admin information.", //Message prompt
                CloseButtonText = "OK" //OK button
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync(); //Give result from Invalid Entry
        }

        /// <summary>
        /// Returns true if both objets are equal, and false otherwise.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Admin && obj != null)
            {
                Admin that = (Admin)obj;
                return FirstName.Equals(that.FirstName) &&
                       LastName.Equals(that.LastName) &&
                       Id.Equals(that.Id) &&
                       Password.Equals(that.Password);
            }
            return false;
        }

        /// <summary>
        /// Returns object's hash code.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void PromoteUser(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns admin's first name, last name, and ID in a string.
        /// </summary>
        public override string ToString()
        {
            if ((FirstName != null) && (LastName != null) && (Id != 0))
                return $"Name: {FirstName} {LastName} ID: {Id}";
            else
            { 
                DisplayInvalidAdminEntry();
                return $"Null character entered";
            }
        }

        /// <summary>
        /// Compares last names, first names, then user IDs.
        /// </summary>
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
