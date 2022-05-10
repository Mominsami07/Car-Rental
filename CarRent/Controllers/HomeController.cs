using CarRent.DateBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Controllers
{
    public class HomeController : Controller
    {
        private readonly MainDbContext _context;


        public HomeController(MainDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var result = _context.Rentals.Include(m => m.Car).Include(m => m.Driver);

            return View(result);
        }
    }
}
