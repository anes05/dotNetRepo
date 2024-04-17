using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public String Classe { get; set; }
        public String Destination { get; set; }
        public virtual List<ReservationTicket> reservationTickets { get; set; }

    }
}
