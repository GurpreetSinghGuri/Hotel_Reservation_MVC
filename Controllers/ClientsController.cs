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
    //Clients controller with security
    [Authorize]
    public class ClientsController : Controller
    {
        private readonly Hotel_Reservation_MVCDataContext _context;

        public ClientsController(Hotel_Reservation_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Clients
        //Gets all Clients using a linq query
        public IActionResult Index()
        {
            return View((from clients in _context.Client select clients).ToList());
        }

        // GET: Clients/Details/5
        //Gets details usig a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client =  _context.Client
                .FirstOrDefault(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        //Retirns the create form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds the client 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,ContactNumber")] Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        //Gets the client for editing
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _context.Client.Find(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Edits the cleint .
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,ContactNumber")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
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
            return View(client);
        }

        // GET: Clients/Delete/5
        //Gets the client for delete using a lamda 
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _context.Client
                .FirstOrDefault(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        //Deletes the client
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var client = _context.Client.Find(id);
            _context.Client.Remove(client);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the existance using a lamda
        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.Id == id);
        }
    }
}
