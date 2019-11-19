using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel_Reservation_MVC.Models;

namespace Hotel_Reservation_MVC.Models
{
    public class Hotel_Reservation_MVCDataContext : DbContext
    {
        public Hotel_Reservation_MVCDataContext (DbContextOptions<Hotel_Reservation_MVCDataContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel_Reservation_MVC.Models.Client> Client { get; set; }

        public DbSet<Hotel_Reservation_MVC.Models.Hotel> Hotel { get; set; }

        public DbSet<Hotel_Reservation_MVC.Models.Reservation> Reservation { get; set; }
    }
}
