using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DataAccessLibrary
{
    public class Professor : People
    {
        public string Prof_Degree;
        public List<Course> ListOfCourses;

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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public async void DisplayInvalidProfEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Enter a current Professor's information", // Message prompt
                CloseButtonText = "OK" // OK button
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync(); // Give result from Invalid Entry
        }

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
        public override string ToString()
        {
            if ((this.FirstName != null) && (this.LastName != null))
                return $"{this.FirstName} {this.LastName}\nID: {Id}\nDegree: {Prof_Degree}\n";
            else
                return $"Null character entered\n";
        }
    }
}
