using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls; // For warning messages (ContentDialog)

namespace DataAccessLibrary
{
    public class Student : People, IComparable<Student> // Implement Icomparable with class People
    {
        // List users for students
        List<People> ListOfUsers;

        // Variables in scope
        public string Student_Major; 

        /// <summary>
        /// Create default value constructor 
        /// This is creating the base slate for the student's information
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="id"></param>
        /// <param name="pw"></param>
        /// <param name="major"></param>
        public Student(string firstname, string lastname, int id, string pw, string major)
            : base(firstname, lastname, id, pw)
        {
            this.Student_Major = major;
        }

        /// <summary>
        /// Shows a warning message prompt to user 
        /// </summary>
        public async void DisplayInvalidStudentEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Enter a current Student information", // Message prompt
                CloseButtonText = "OK" // OK button
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync(); // Give result from Invalid Entry
        }

        public override bool Equals(object obj)
        {
            if (obj is Student && obj != null)
            {
                Student that = (Student)obj;
                return FirstName.Equals(that.FirstName) &&
                    LastName.Equals(that.LastName) &&
                    Id.Equals(that.Id);
            }
            return false;
        }

        /// <summary>
        /// Object requirement #1 - CompareTo()
        /// Implement try and catch blocks
        /// Compare: last names -> first names -> Id
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
        /// Object requirment #2 - GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Object requirment #3 - ToString()
        /// Show contents for the student
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {       
            if ((this.FirstName != null) && (this.LastName != null))   
                return $"{FirstName} {LastName}\n ID: {Id}\n Major: {Student_Major}";
            else
                return $"Null character entered";
        }

    }
}
