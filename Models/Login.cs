using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnLineClothing.Models
{
    public class Login
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Rights { get; set; }

        [MaxLength(15)]
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required]       
        public string PasswordSalt { get; set; }

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password requires 8 characters, a capital and lowercase letter, a number and a special character")]
        public string PasswordHash { get; set; }
    }
}
