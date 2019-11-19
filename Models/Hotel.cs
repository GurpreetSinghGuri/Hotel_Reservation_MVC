using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Reservation_MVC.Models
{
    //Hotel details
    public class Hotel
    {
        //hotel id 
        public int Id { get; set; }

        //hotel name 
        public string HotelName { get; set; }

        //The hotel Price per room
        public decimal PricePerRoom {get; set;}

    }
}
