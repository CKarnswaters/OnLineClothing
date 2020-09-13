using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineClothing.Models
{
    public class Items
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ItemDescription { get; set; }
        public string Image { get; set; }
    }
}
