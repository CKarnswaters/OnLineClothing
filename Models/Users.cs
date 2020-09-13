using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineClothing.Models
{
    public class Users
    {
        public int ID { get; set; }
        public int LoginID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
