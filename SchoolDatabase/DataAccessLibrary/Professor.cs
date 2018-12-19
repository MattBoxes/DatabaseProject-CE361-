using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Microsoft.Data.Sqlite;

namespace DataAccessLibrary
{
    /// <summary>
    /// A professor can add and drop students from courses, as well as change their grades.
    /// </summary>
    public class Professor : People, IComparable<Professor>
    {
        

        /// <summary>
        /// Constructor for Professor class.
        /// </summary>
        public Professor(string firstname, string lastname, int id, string pw)
            : base(firstname, lastname, id, pw) { }


        public void DropStudentFromCourse (Student std, Course course)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = $"DELETE FROM Grade WHERE ( Course_ID = '{course.Id}' AND Student_ID = '{std.Id.ToString()}') ";

                insertCommand.ExecuteReader();

                db.Close();
            }
        }


        public void ChangeGrade (Course course, Student std, int newGrade)
        {
            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand updateCommand = new SqliteCommand();
                updateCommand.Connection = db;

                updateCommand.CommandText = "UPDATE Grade " +
                                            $"SET GradePoint = {newGrade} " +
                                            $"WHERE ( Course_ID = '{course.Id}' AND Student_ID = '{std.Id.ToString()}');";

                updateCommand.ExecuteReader();

                db.Close();
            }
        }


        public List<Student> GetStudentsinCourse(string courseid)
        {
            List<string> courseids = new List<string>();
            List<string> studentids = new List<string>();
            List<string> studentidsincourse = new List<string>();
            List<Student> listofStudents = new List<Student>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Course_ID FROM Grade ORDER BY Course_ID", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    courseids.Add(query.GetString(0));
                }


                selectCommand = new SqliteCommand("SELECT Student_ID FROM Grade ORDER BY Course_ID", db);

                query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    studentids.Add(query.GetString(0));
                }


                db.Close();
            }

            for(int i = 0; i < courseids.Count; i++)
            {
                if (courseid == courseids[i])
                {
                    studentidsincourse.Add(studentids[i]);
                }
            }

            List<string> ids = new List<string>();
            List<string> firsts = new List<string>();
            List<string> lasts = new List<string>();
            List<string> pws = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Student_ID FROM Student ORDER BY Student_ID", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    ids.Add(query.GetString(0));
                }


                selectCommand = new SqliteCommand("SELECT Last_Name FROM Student ORDER BY Student_ID", db);

                query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    lasts.Add(query.GetString(0));
                }

                selectCommand = new SqliteCommand("SELECT First_Name FROM Student ORDER BY Student_ID", db);

                query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    firsts.Add(query.GetString(0));
                }

                selectCommand = new SqliteCommand("SELECT Password FROM Student ORDER BY Student_ID", db);

                query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    pws.Add(query.GetString(0));
                }


                db.Close();
            }

            for(int i = 0; i < ids.Count; i++)
            {
                for(int j = 0; j < studentidsincourse.Count; j++)
                {
                    if (studentidsincourse[j] == ids[i])
                    {
                        listofStudents.Add(new Student(firsts[i], lasts[i], Int32.Parse(ids[i]), pws[i]));
                    }
                }
            }
            return listofStudents;
        }

        public List<Course> GetCourses()
        {
            List<string> courseids = new List<string>();
            List<string> coursenames = new List<string>();
            List<string> profids = new List<string>();
            List<Course> litsofcourse = new List<Course>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Course_ID FROM Course ORDER BY Course_ID", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    courseids.Add(query.GetString(0));
                }

                selectCommand = new SqliteCommand("SELECT Course_Name FROM Course ORDER BY Course_ID", db);

                query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    coursenames.Add(query.GetString(0));
                }

                selectCommand = new SqliteCommand("SELECT Professor_ID FROM Course ORDER BY Course_ID", db);

                query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    profids.Add(query.GetString(0));
                }


                db.Close();
            }

            for (int i = 0; i < courseids.Count; i++)
            {
                if (profids[i] == this.Id.ToString())
                    litsofcourse.Add(new Course(coursenames[i], courseids[i], this.Id));
            }

            return litsofcourse;
        }



        /// <summary>
        /// Displays a pop-up window when invalid professor information is being used.
        /// </summary>
        private async void DisplayInvalidProfessorEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Invalid professor information.", //Message prompt
                CloseButtonText = "OK" //OK button
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync(); //Give result from Invalid Entry
        }

        /// <summary>
        /// Compares last names, first names, then user IDs.
        /// </summary>
        public int CompareTo(Professor obj)
        {
            if (obj == null)
            {
                DisplayInvalidProfessorEntry();
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
        /// Returns professor's first name, last name, and user ID in a string.
        /// </summary>
        public override string ToString()
        {
            if ((FirstName != null) && (LastName != null) && (Id != 0))
                return $"Name: {FirstName} {LastName} ID: {Id}";
            else
            {
                DisplayInvalidProfessorEntry();
                return $"Null character entered.";
            }
        }

        /// <summary>
        /// Returns object's hash code.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns true if both objets are equal, and false otherwise.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Professor && obj != null)
            {
                Professor that = (Professor)obj;
                return FirstName.Equals(that.FirstName) &&
                       LastName.Equals(that.LastName) &&
                       Id.Equals(that.Id) &&
                       Password.Equals(that.Password);
            }
            return false;
        }

        public void ChangePassword(string oldPw, string newPw)
        {

            List<string> ProfIDs = new List<string>();
            List<string> ProfPWs = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Professor_ID FROM Professor", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    ProfIDs.Add(query.GetString(0));
                }

                selectCommand = new SqliteCommand("SELECT Password FROM Professor", db);

                query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    ProfPWs.Add(query.GetString(0));
                }
                db.Close();
            }

            for (int i = 0; i < ProfIDs.Count; i++)
            {
                if (ProfIDs[i] == this.Id.ToString())
                {
                    if (oldPw == this.Password)
                    {
                        using (SqliteConnection db = new SqliteConnection("Filename=schoolDB.db"))
                        {
                            db.Open();

                            SqliteCommand updateCommand = new SqliteCommand();
                            updateCommand.Connection = db;

                            updateCommand.CommandText = "UPDATE Professor " +
                                                        $"SET Password = '{newPw}' " +
                                                        $"WHERE Professor_ID = {this.Id};";

                            updateCommand.ExecuteReader();

                            db.Close();
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Wrong Password");
                    }
                }

            }

        }
    }
}
