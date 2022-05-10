using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarRent.DateBase;
using CarRent.Models;

namespace CarRent.Controllers
{
    public class RentalsController : Controller
    {
        private readonly MainDbContext _context;

        public RentalsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: Rentals
        public async Task<IActionResult> Index()
        {
            var mainDbContext = _context.Rentals.Include(r => r.Car).Include(r => r.Driver);
            var ss = await mainDbContext.ToListAsync();
            
            
            return View(ss);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            var carRental = _context.Rentals.Include(m => m.Car);

            var availableCars = _context.Cars.Where(m => !carRental.Any(x => x.CarId == m.Id && x.ReturnDate == null));

            ViewData["CarId"] = new SelectList(availableCars, "Id", "Make");
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Name");
            return View();
        }

        // POST: Rentals/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ReturnDate,Comment,DriverId,CarId,Id,RentData")] Rentals rentals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentals);
                var result = await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Make", rentals.CarId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Email", rentals.DriverId);
            return View(rentals);
        }

    

        public async Task<IActionResult> ReturnDate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentals = await _context.Rentals.Include(r => r.Car).FirstOrDefaultAsync(m => m.Id == id);

            if (rentals == null)
            {
                return NotFound();
            }

            rentals.ReturnDate = DateTime.Now;

            _context.Update(rentals);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));



        }

        // POST: Rentals/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete( int id)
        {
            var rentals = await _context.Rentals.FindAsync(id);
            _context.Rentals.Remove(rentals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalsExists(int id)
        {
            return _context.Rentals.Any(e => e.Id == id);
        }
    }
}