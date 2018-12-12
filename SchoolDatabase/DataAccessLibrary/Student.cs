using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls; // For warning messages (ContentDialog)

namespace DataAccessLibrary
{
    public class Student : People, IComparable <Student> // Implement Icomparable with class People
    {
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
        public async void DisplayInvalidEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Enter a current Student information", // Message prompt
                CloseButtonText = "OK" // OK button
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync(); // Give result from Invalid Entry
        }

        /// <summary>
        /// Object requirement #1 - CompareTo
        /// Implement try and catch blocks
        /// Compare: last names -> first names -> Id
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Student obj)
        {
            try 
            {
                if (obj == null) // obj == 0
                {
                    throw new NullReferenceException("Attemping to Compare NULL reference");
                }
                else
                {
                    if (LastName.CompareTo(obj.LastName) == 0) // Same last name
                    {
                        if (FirstName.CompareTo(obj.FirstName) == 0) // Same first name
                        {
                            return Id - obj.Id; // Tie breaker: Difference of Id 
                        }
                        return FirstName.CompareTo(obj.FirstName); // Compare first names
                    }
                    return LastName.CompareTo(obj.LastName); // Compare last names
                }
            }
            catch (NullReferenceException nEx)
            {
                DisplayInvalidEntry(); // Call warning message object
                return -1;
            }
        }
        
    }
}
