using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    class Admin
    {
        public string Name { get; set; }
        public short Id { get; set; }

        /// <summary>
        /// Admin Constructor. The default name of the admin is "Admin". The default Id is "0"
        /// </summary>
        public Admin()
        {
            this.Name = "Admin";
            this.Id = 0;
        }
        public Admin(string cName, short cId)
        {
            this.Name = cName;
            this.Id = cId;
        }

    }
}
