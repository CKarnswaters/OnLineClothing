using OnLineClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OnLineClothing.ViewModels
{
    public class ItemViewModel : BaseViewModel
    {
        
        public Items item { get; set; }
        public Categories category { get; set; }

    }
}
