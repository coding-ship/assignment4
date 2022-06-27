using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class IssueDetails
    {
        public int Id { get; set; }
        [Required]
        public int Book_Id { get; set; }
        [Required]
        public string Book_Name { get; set; }
        [Required]
        public string Book_Author { get; set; }
        [Required]
        public int User_Id { get; set; }
        [Required]
        public string User_Name { get; set; }
        [Required]
        public string Phone_Number { get; set; }
        [Required]
        public DateTime Issue_Date { get; set; }
    }
}
