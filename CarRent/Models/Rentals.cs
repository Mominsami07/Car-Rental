using CarRent.Attribuites;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class Rentals : BaseEntity
    {
        public DateTime? RentData { get; set; } = DateTime.Now;

        public DateTime? ReturnDate { get; set; }

        [MaxLength(int.MaxValue)]
        public string Comment { get; set; }

        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }


    }
}
