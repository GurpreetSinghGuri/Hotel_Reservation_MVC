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
    // reservations controller with permision .
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly Hotel_Reservation_MVCDataContext _context;

        public ReservationsController(Hotel_Reservation_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Reservations
        //Gets all reservations using a lamda 
        public IActionResult Index()
        {
            var hotel_Reservation_MVCDataContext = _context.Reservation.Include(r => r.Client).Include(r => r.Hotel);
            return View( hotel_Reservation_MVCDataContext.ToList());
        }

        // GET: Reservations/Details/5
        //Gets  details using a lamda 
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation =_context.Reservation
                .Include(r => r.Client)
                .Include(r => r.Hotel)
                .FirstOrDefault(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        //Gets the form for create.
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name");
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "HotelName");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates the reservation.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ClientId,HotelId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", reservation.ClientId);
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Id", reservation.HotelId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        //Gets the reservation for edit.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = (from resev in _context.Reservation
                               where resev.Id == id
                               select resev).FirstOrDefault();
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Name", reservation.ClientId);
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "HotelName", reservation.HotelId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Update the resevation.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,ClientId,HotelId")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", reservation.ClientId);
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Id", reservation.HotelId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        //Returns the reservation for delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Client)
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        //Deletes the resevation.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var reservation = _context.Reservation.Find(id);
            _context.Reservation.Remove(reservation);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Uses a ladam to check existance.
        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.Id == id);
        }
    }
}
