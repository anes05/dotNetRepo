using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class ReservationTicket
    {
        public DateTime DateReservation{ get; set; }
        public float prix { get; set;}
        //string car type id Passenger est string (passeport number)
        public string PassengerFK { get; set; }
        //int car type de id de ticket est int()
        public int TicketFK { get; set; }

        [ForeignKey("PassengerFK")]
        public virtual Passenger Passenger { get; set; }
        [ForeignKey("TicketFK")]
        public virtual Ticket Ticket { get; set; } 
    }
}
