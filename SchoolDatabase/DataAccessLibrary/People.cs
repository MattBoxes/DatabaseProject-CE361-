using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class People
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

        public override string ToString()
        {
            throw new NotImplementedException();
        }
        
    }
}
