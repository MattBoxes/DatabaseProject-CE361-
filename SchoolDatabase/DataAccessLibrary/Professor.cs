using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DataAccessLibrary
{
    /// <summary>
    /// The Professor class contains the definition and methods that define
    /// the Professor user. The professor has a degree, in addition to the 
    /// parent constructor parameters, and has permission to add and drop 
    /// students from courses, as well as change their grades.
    /// </summary>
    public class Professor : People, IComparable<Professor>
    {
        public string Prof_Degree;
        public List<Course> ListOfCourses;
        /// <summary>
        /// Constructor for Professor Class. Creates the Professor's First Name,
        /// Last Name, Password, Degree, and ID.
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="id"></param>
        /// <param name="pw"></param>
        /// <param name="degree"></param>
        public Professor(string firstname, string lastname, int id, string pw, string degree)
            : base(firstname, lastname, id, pw)
        {
            this.Prof_Degree = degree;
        }

        public void DropStudentFromCourse (Student std, Course course)
        {

        }

        public void ChangeGrade (Student std, char newGrade)
        {

        }

        public void AddStudentToCourse (Student std, Course course)
        {

        }
        /// <summary>
        /// Method to display a popup window when entering invalid Professor information
        /// </summary>
        private async void DisplayInvalidProfEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Enter a current Professor's information", // Message prompt
                CloseButtonText = "OK" // OK button
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync(); // Give result from Invalid Entry
        }
        /// <summary>
        /// CompareTo Implementation of IComparable Interface that compares Professors by Last Name, then
        /// First Name, then unique ID.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Professor obj)
        {
            if (obj == null)
            {
                DisplayInvalidProfEntry();
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
        /// Returns the string of the Professor's First Name, Last Name,
        /// Degree, and ID.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if ((this.FirstName != null) && (this.LastName != null))
                return $"{this.FirstName} {this.LastName}\nID: {Id}\nDegree: {Prof_Degree}\n";
            else
                return $"Null character entered\n";
        }
    }
}
