using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineClothing.Models
{
    public class Users
    {

        [Required]
        public int ID { get; set; }

        [Required]
        public int LoginID { get; set; }

        [MaxLength(25)]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [MaxLength(25)]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        
        [MaxLength(50)]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        
        [MaxLength(25)]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        [MaxLength(5)]
        [MinLength(5, ErrorMessage = "Please enter a valid Zip Code")]
        public string ZipCode { get; set; }
    }
}
