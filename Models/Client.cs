using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Reservation_MVC.Models
{
    //Client information.
    public class Client
    {
        //Client Id 
        public int Id { get; set; }

        //Client name
        public string Name { get; set; }

        //Client contact number.
        public string ContactNumber { get; set; }
    }
}
