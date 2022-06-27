using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class Book
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Book_Id { get; set; }
        [Required]
        public string Book_Name { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public int No_of_pages { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int No_of_Books { get; set; }
    }
}
