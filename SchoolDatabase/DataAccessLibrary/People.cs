using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DataAccessLibrary
{
    /// <summary>
    /// The People class is the parent class for all users, which are the Admin, Student,
    /// and Professor child classes. It constructs the First name, Last Name, ID, and 
    /// Passwords for each user, as well as implements some universal methods, including
    /// for the IComparable interfaces unique to the child classes.
    /// </summary>
    public class People: IComparable<People>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Id { get; set; }

        public string Password { get; set; }

        public People(string firstname, string lastname, int id, string pw)
        {
            this.FirstName = firstname;
            this.LastName = LastName;
            this.Id = id;
            this.Password = pw;
        }

        /// <summary>
        /// Implemention of the Equals operator for all Users, 
        /// checking for the users First and Last Name and ID
        /// equality.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is People && obj != null)
            {
                People that = (People)obj;
                return FirstName.Equals(that.FirstName) &&
                    LastName.Equals(that.LastName) &&
                    Id.Equals(that.Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns the string of the User's First Name,
        /// Last Name, and ID.
        /// </summary>
        public override string ToString()
        {
            if ((this.FirstName != null) && (this.LastName != null))
                return $"{this.FirstName} {this.LastName}\nID: {Id}\n";
            else
                return $"Null character entered";
        }

        public int CompareTo(People other)
        {
            throw new NotImplementedException();
        }
    }
}
