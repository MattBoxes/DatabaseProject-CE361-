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
        /// Constructor for Course class.
        /// </summary>
        public Course(string inName, string inID, int profid)
        {
            this.Name = inName;
            this.Id = inID;
            this.ProfessorId = profid;
        }

        /// <summary>
        /// Returns true if both objets are equal, and false otherwise.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Course && obj != null)
            {
                Course that = (Course)obj;
                return Name.Equals(that.Name) &&
                       Id.Equals(that.Id) &&
                       ProfessorId.Equals(that.ProfessorId);
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

        /// <summary>
        /// Displays a pop-up window when invalid course information is being used.
        /// </summary>
        private async void DisplayInvalidCourseEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Invalid course information.",
                CloseButtonText = "OK"
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync();
        }

        /// <summary>
        /// Compares names, then IDs.
        /// </summary>
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
        /// Returns course's name, and ID in a string.
        /// </summary>
        public override string ToString()
        {
            if ((Name != null) && (Id != null))
                return $"Name: {Name} ID: {Id}";
            else
            {
                DisplayInvalidCourseEntry();
                return $"Null character entered";
            }
        }
    }
}
