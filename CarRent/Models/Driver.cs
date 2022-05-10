using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Driver : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<Rentals> Rentals { get; set; }
    }
}
