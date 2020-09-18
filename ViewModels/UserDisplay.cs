using OnLineClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineClothing.ViewModels
{
    public class UserDisplay
    {
        public string password { get; set; }

        public Login login { get; set; }
        public Users users { get; set; }
    }
}
