using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public String Departure { get; set; }
        public String Destination { get; set; }
        public int PlaneFK { get; set; }
        public string Pilot { get; set; }
        [ForeignKey("PlaneFK")]
        public virtual Plane Plane { get; set; }
        public virtual IList<Passenger> Passengers { get; set; }

    }
}
