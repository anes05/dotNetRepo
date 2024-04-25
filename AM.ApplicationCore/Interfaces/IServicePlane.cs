using AM.ApplicationCore.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane : IService<Plane>
    {
        public IEnumerable<Traveller> GetPassengers(Plane p);
        public IEnumerable<Flight> GetFlights(int n);
        public bool ReserverVols(Flight flight,int n);
        public void DeleteByFabricationDate();

    }
}
