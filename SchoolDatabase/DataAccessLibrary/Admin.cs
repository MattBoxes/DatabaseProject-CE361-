using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DataAccessLibrary
{
    public class Admin : People,IComparable<Admin>

    {
        List<Course> ListOfCourses;
        List<People> ListOfUsers;

        /// <summary>
        /// Admin Constructor. The default name of the admin is "Admin". The default Id is "0"
        /// </summary>
        public Admin(string firstname, string lastname, int id, string pw)
            : base(firstname, lastname, id, pw)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Id = id;
            this.Password = pw;
        }
        public void addCourse(string courseName)
        {

        }
        public void removeCourse(string courseName)
        {

        }
        public void editCourseName(string courseName, string newCourseName)
        {

        }
        public void addUser(string firstname, string lastname, string id, string pw)
        {

        }
        public void removeUser(string firstname, string lastname)
        {

        }
        public void editUserName(string nfirstName, string nlastname, string firstname, string lastname)
        {

        }
        public void editStudentGrade(string firstname, string lastname, string coursename, string newGrade)
        {

        }
        public void addStudentToCourse(string firstname, string lastname, string coursename)
        {

        }
        public void addProfToCourse(string firstname, string lastname, string coursename)
        {

        }
        public void removeStudentFromCourse(string firstname, string lastname, string coursename)
        {

        }
        public void removeProfFromCourse(string firstname, string lastname, string coursename)
        {

        }
        public void viewListOfCourses()
        {
            throw new NotImplementedException();
        }
        public void viewListOfUsers()
        {
            throw new NotImplementedException();
        }
        public void editStudentMajor(string firstname, string lastname, string newMajor)
        {
            throw new NotImplementedException();
        }
        public void promoteUser(string firstname, string lastname)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            throw new NotImplementedException();   
        }

        private async void DisplayInvalidEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Enter a current Admin's information",
                CloseButtonText = "OK"
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync();
        }

        public int CompareTo(Admin obj)
        {
            try
            {
                if (obj == null)
                {
                    throw new NullReferenceException("Attempting to Compare NULL reference");
                }
                else
                {
                    if (LastName.CompareTo(obj.LastName) == 0)
                    {
                        if(FirstName.CompareTo(obj.FirstName) == 0)
                        {
                            return Id - obj.Id;
                        }
                        return FirstName.CompareTo(obj.FirstName);
                    }
                    return LastName.CompareTo(obj.LastName);
                }

            }
            catch (NullReferenceException nEx)
            {
                DisplayInvalidEntry();
                return -1;
            }           
        }

    }
}
