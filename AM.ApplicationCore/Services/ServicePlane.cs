using AM.ApplicationCore.domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    internal class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Passenger> GetPassengers(Plane plane)
        {
            return plane.Flights.SelectMany(p => p.Passengers);
            
        }
    }
}
