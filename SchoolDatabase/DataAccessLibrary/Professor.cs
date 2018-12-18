using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DataAccessLibrary
{
    /// <summary>
    /// A professor can add and drop students from courses, as well as change their grades.
    /// </summary>
    public class Professor : People, IComparable<Professor>
    {
        public List<Course> ListOfCourses;

        /// <summary>
        /// Constructor for Professor class.
        /// </summary>
        public Professor(string firstname, string lastname, int id, string pw)
            : base(firstname, lastname, id, pw) { }

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
    }
}
