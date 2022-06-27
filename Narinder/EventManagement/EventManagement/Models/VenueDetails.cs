using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    public class VenueDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int Id { get; set; }
        public string Event_Place { get; set; }
        [Required]
        public int DJ_Cost { get; set; }
        [Required]
        public int Stage_Cost { get; set; }

        [Required]
        public int Mike_Speaker_Cost { get; set; }

        [ForeignKey("Event_Place")]
        public virtual Venue venue { get; set; }
    }
}
