using OnLineClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineClothing.ViewModels
{
    public class BaseViewModel
    {
        public List<Login> login { get; set; }
        public List<Users> users { get; set; }
        public List<Cart> cart { get; set; }
    }
}
