using CarRent.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRent.DateBase
{
    public class MainDbContext : DbContext
    {

        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Rentals> Rentals { get; set; }


        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

    }
}
