using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Reservation_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hotel_Reservation_MVC.Controllers
{
    [Authorize]
    public class HotelsController : Controller
    {
        private readonly Hotel_Reservation_MVCDataContext _context;

        public HotelsController(Hotel_Reservation_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Hotels
        //Gets All the hotels
        public IActionResult Index()
        {
            return View(_context.Hotel.ToList());
        }

        // GET: Hotels/Details/5
        //Gets the details of the hotel
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel =  _context.Hotel
                .FirstOrDefault(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        //Gets the create hotel form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates the hotel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,HotelName,PricePerRoom")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotel);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        //Gets the hotel for update.uses a linq query to get the hotel.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = (from hotels in _context.Hotel
                         where hotels.Id == id
                         select hotels).FirstOrDefault();
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the hotel.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,HotelName,PricePerRoom")] Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        //Gets the hotel for delete uses a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel =  _context.Hotel
                .FirstOrDefault(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        //Deletes the hotel
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var hotel =  _context.Hotel.Find(id);
            _context.Hotel.Remove(hotel);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the existance using  lamda .
        private bool HotelExists(int id)
        {
            return _context.Hotel.Any(e => e.Id == id);
        }
    }
}
