using AM.ApplicationCore.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods:IService<Flight>
    {
        public IEnumerable<Flight> SortFlights();
        List<DateTime> GetFlightDates(String Destination);
        void ShowFlightDetails(Plane planne);
        int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destination);
        IEnumerable<Flight> OrderedDurationFlights();
        IEnumerable<Traveller> SeniorTravellers(Flight flight);
        IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();
        IEnumerable<Staff> GetStaffOfFlightByFlightId(int flightId);
    }
}
