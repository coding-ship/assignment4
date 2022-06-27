using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class UserDetails
    {
        [Key]
        [Required]
        public int User_Id { get; set; }
        [Required]
        public string User_Name { get; set; }

        [Required]
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone_no { get; set; }
    }
}
