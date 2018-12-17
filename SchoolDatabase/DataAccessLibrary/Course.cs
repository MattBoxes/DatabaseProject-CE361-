using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DataAccessLibrary
{
    public class Course : IComparable<Course>
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public int ProfessorId { get; set; }

        public Course(string inName, string inID)
        {
            this.Name = inName;
            this.Id = inID;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private async void DisplayInvalidCourseEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Course information is invalid.",
                CloseButtonText = "OK"
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync();
        }

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

        public override string ToString()
        {
            if ((this.Name != null) && (this.Id != null))
                return $"{this.Name}\n{this.Id}\n";
            else
                return $"Null character entered";
        }
    }
}
