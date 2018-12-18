using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls; // For warning messages (ContentDialog)

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

        // Variables in scope
        public string Student_Major;

        /// <summary>
        /// Constructor for Student Class. Creates the Student's First Name,
        /// Last Name, Password, Major, and ID.
        /// </summary>
        public Student(string firstname, string lastname, int id, string pw, string major)
            : base(firstname, lastname, id, pw)
        {
            this.Student_Major = major;
        }

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
        /// Object requirment #3 - ToString()
        /// Show contents for the student
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {       
            if ((this.FirstName != null) && (this.LastName != null))   
                return $"{FirstName} {LastName}\nID: {Id}\nMajor: {Student_Major}";
            else
                return $"Null character entered";
        }

    }
}
