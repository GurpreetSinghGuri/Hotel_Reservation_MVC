using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Reservation_MVC.Models
{
    //Hotel reservation.
    public class Reservation
    {
        //id of the reservation.
        public int Id { get; set; }

        //Client Id

        public int ClientId { get; set; }


        //Hotel Id 
        public int HotelId { get; set; }

        //Client link
        public Client Client { get; set; }

        //Hotel link.
        public Hotel Hotel { get; set; }


    }
}
