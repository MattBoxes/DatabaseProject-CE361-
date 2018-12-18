using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls; // For warning messages (ContentDialog)
using Microsoft.Data.Sqlite;

namespace DataAccessLibrary
{
    /// <summary>
    /// The Student class contains the definitions and methods that define 
    /// a student user. A student can add and drop courses.
    /// </summary>
    public class Student : People, IComparable<Student> // Implement Icomparable with class People
    {
        // List users for students
        List<People> ListOfUsers;

        /// <summary>
        /// Constructor for Student Class. Creates the Student's First Name,
        /// Last Name, Password, Major, and ID.
        /// </summary>
        public Student(string firstname, string lastname, int id, string pw)
            : base(firstname, lastname, id, pw) { }

        /// <summary>
        /// Method to display a popup window when entering invalid course information
        /// </summary>
        private async void DisplayInvalidStudentEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Enter a current Student information", // Message prompt
                CloseButtonText = "OK" // OK button
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync(); // Give result from Invalid Entry
        }

        /// <summary>
        /// Object requirement #1 - CompareTo()
        /// Compare: last names -> first names -> Id
        /// </summary>
        public int CompareTo(Student obj)
        {
            if (obj == null)
            {
                DisplayInvalidStudentEntry();
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

        /// <summary>
        /// Object requirment #3 - ToString()
        /// Show contents for the student
        /// </summary>
        public override string ToString()
        {       
            if ((this.FirstName != null) && (this.LastName != null))   
                return $"{FirstName} {LastName}\nID: {Id}";
            else
                return $"Null character entered";
        }

        /// <summary>
        /// Using relations in database, retrieve a list of Courses that this Student enrolls in
        /// </summary>
        /// <returns>A List of Course</returns>
        public List<Course> GetCourses()
        {
            List<string> Grades = new List<string>();
            List<string> StudentIDs = new List<string>();
            List<string> CourseIDsfromGrade = new List<string>();
            List<string> CourseIDsfromCourse = new List<string>();
            List<string> CourseNames = new List<string>();
            List<string> ProfIdsfromCourse = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Student_ID FROM Grade", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    StudentIDs.Add(query.GetString(0));
                }

                selectCommand = new SqliteCommand("SELECT GradePoint FROM Grade", db);

                query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    Grades.Add(query.GetString(0));
                }

                selectCommand = new SqliteCommand("SELECT Course_ID FROM Grade", db);

                query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    CourseIDsfromGrade.Add(query.GetString(0));
                }

                selectCommand = new SqliteCommand("SELECT Course_ID FROM Course", db);

                query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    CourseIDsfromCourse.Add(query.GetString(0));
                }

                selectCommand = new SqliteCommand("SELECT Course_Name FROM Course", db);

                query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    CourseNames.Add(query.GetString(0));
                }

                selectCommand = new SqliteCommand("SELECT Professor_ID FROM Course", db);

                query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    ProfIdsfromCourse.Add(query.GetString(0));
                }


                db.Close();
            }

            List<string> thisStudentGrades = new List<string>();
            for (int i = 0; i < StudentIDs.Count; i++)
            {
                if (StudentIDs[i] == this.Id.ToString())
                    thisStudentGrades.Add(Grades[i]);
            }


            List<string> thisStudentCoursesIDs = new List<string>();
            for (int i = 0; i < StudentIDs.Count; i++)
            {
                if (StudentIDs[i] == this.Id.ToString())
                    thisStudentCoursesIDs.Add(CourseIDsfromGrade[i]);
            }

            List<string> thisStudentCoursesNames = new List<string>();
            for (int i = 0; i < CourseIDsfromCourse.Count; i++)
            {
                if (thisStudentCoursesIDs[i] == CourseIDsfromCourse[i])
                    thisStudentCoursesNames.Add(CourseNames[i]);
            }

            List<string> thisStudentProfIds = new List<string>();
            for (int i = 0; i < CourseIDsfromCourse.Count; i++)
            {
                if (thisStudentCoursesIDs[i] == CourseIDsfromCourse[i])
                    thisStudentProfIds.Add(ProfIdsfromCourse[i]);
            }

            List<Course> courseList = new List<Course>();
            for (int i = 0; i < thisStudentCoursesIDs.Count; i++)
                courseList.Add(new Course(thisStudentCoursesNames[i], thisStudentCoursesIDs[i], Int32.Parse(thisStudentProfIds[i]), Int32.Parse(thisStudentGrades[i])));
            

            return courseList;
        }
    }
}
