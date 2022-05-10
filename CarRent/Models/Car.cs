using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Car : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Required]
        [MaxLength(10)]
        public string RegisterationNumber { get; set; }

        public ICollection<Rentals> Rentals { get; set; }

        
    }
}
