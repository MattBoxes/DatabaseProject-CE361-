using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DataAccessLibrary
{
    /// <summary>
    /// The People class is the parent class for all users, including the Admin, Student,
    /// and Professor child classes.
    /// </summary>
    public class People: IComparable<People>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Id { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// Constructor for People class.
        /// </summary>
        public People(string firstname, string lastname, int id, string pw)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Id = id;
            this.Password = pw;
        }

        /// <summary>
        /// Displays a pop-up window when invalid people information is being used.
        /// </summary>
        private async void DisplayInvalidPeopleEntry()
        {
            ContentDialog InvalidEntry = new ContentDialog
            {
                Title = "Invalid people information.", //Message prompt
                CloseButtonText = "OK" //OK button
            };
            ContentDialogResult result = await InvalidEntry.ShowAsync(); //Give result from Invalid Entry
        }

        /// <summary>
        /// Returns true if both objets are equal, and false otherwise.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is People && obj != null)
            {
                People that = (People)obj;
                return FirstName.Equals(that.FirstName) &&
                       LastName.Equals(that.LastName) &&
                       Id.Equals(that.Id) &&
                       Password.Equals(that.Password);
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
        /// Returns people's first name, last name, and user ID in a string.
        /// </summary>
        public override string ToString()
        {
            if ((FirstName != null) && (LastName != null) && (Id != 0))
                return $"Name: {FirstName} {LastName} ID: {Id}";
            else
            {
                DisplayInvalidPeopleEntry();
                return $"Null character entered.";
            }
        }

        /// <summary>
        /// Compares last names, first names, then user IDs.
        /// </summary>
        public int CompareTo(People obj)
        {
            if (obj == null)
            {
                DisplayInvalidPeopleEntry();
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
    }
}
