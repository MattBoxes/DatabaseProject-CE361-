using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DataAccessLibrary
{
    /// <summary>
    /// The Course class holds the method definitons used by the database to set up
    /// and organize the Course Name and ID.
    /// </summary>
    public class Course : IComparable<Course>
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public int ProfessorId { get; set; }
        /// <summary>
        /// Constructor for Course Class. Creates the Course Name and ID.
        /// </summary>
        /// <param name="inName"></param>
        /// <param name="inID"></param>
        public Course(string inName, string inID)
        {
            this.Name = inName;
            this.Id = inID;
        }
        /// <summary>
        /// Implemention of the Equals operator, checking for Course Name and ID
        /// equality.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Course && obj != null)
            {
                Course that = (Course)obj;
                return Name.Equals(that.Name) &&
                    Id.Equals(that.Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Method to display a popup window when entering invalid course information
        /// </summary>
        private async void DisplayInvalidCourseEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Course information is invalid.",
                CloseButtonText = "OK"
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync();
        }
        /// <summary>
        /// CompareTo Implementation of IComparable Interface that compares by Course Name First, then the
        /// unique Course ID, if the parent name is of the same major/degree.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Course obj)
        {
            if (obj == null)
            {
                DisplayInvalidCourseEntry();
                return -1;
            }
            else
            {
                if (Name.CompareTo(obj.Name) == 0)
                {
                    return Id.CompareTo(obj.Id);
                }
                return Name.CompareTo(obj.Name);
            }
        }
        /// <summary>
        /// Returns the string of the Course Name and ID
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if ((this.Name != null) && (this.Id != null))
                return $"{this.Name}\n{this.Id}\n";
            else
                return $"Null character entered";
        }
    }
}
