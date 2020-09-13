using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineClothing.Models
{
    public class OrderHistory
    {
        public int ID { get; set; }
        public int LoginID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
    }
}
