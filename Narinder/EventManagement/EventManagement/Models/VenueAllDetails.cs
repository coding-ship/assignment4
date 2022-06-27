using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    public class VenueAllDetails
    {
        [Key]
        [Required]
        public string Event_Place { get; set; }
        [Required]
        public string Event_Type { get; set; }

        [Required]
        public int Guest_Capability { get; set; }
        [Required]
        public int Per_Guest_Cost { get; set; }
        [Required]
        public int DJ_Cost { get; set; }
        [Required]
        public int Stage_Cost { get; set; }

        [Required]
        public int Mike_Speaker_Cost { get; set; }
    }
}
