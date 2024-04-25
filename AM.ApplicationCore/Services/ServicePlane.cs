using AM.ApplicationCore.domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeleteByFabricationDate()
        {
            Delete(f => f.ManufactureDate.Year - DateTime.Now.Year>10);
        }

        public IEnumerable<Flight> GetFlights(int n)
        {
            return GetAll().SelectMany(f=>f.Flights).OrderByDescending(t=>t.FlightDate).Take(n);
        }

        public IEnumerable<Traveller> GetPassengers(Plane plane)
        {
            //return plane.Flights.SelectMany(p => p.Passengers);
            return plane.Flights.SelectMany(p => p.Passengers).OfType<Traveller>();
            
        }

        public bool ReserverVols(Flight flight, int n)
        {
            return flight.Plane.Capacity>= flight.Passengers.Count()+n;
        }

        /* en cas ou on utilise ILIst instead of IEnumerable: 
*         public IList<Traveller> GetPassengers(Plane plane)
{
   //return plane.Flights.SelectMany(p => p.Passengers);
   return plane.Flights.SelectMany(p => p.Passengers).OfType<Traveller>().ToList();;

}

*/


    }
}
