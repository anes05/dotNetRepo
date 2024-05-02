using AM.ApplicationCore.domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods :Service<Flight>, IFlightMethods
    {
        public List<Flight> Flights=new List<Flight> ();



        public FlightMethods(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        //List<Traveller>Travellers=new List<Traveller> ();

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            /*var query = from flight in Flights
                        group flight by flight.Destination;*/
            //LAMBDA: 
            var query = Flights.GroupBy(f => f.Destination);
            foreach (var item in query)
            {
                Console.WriteLine("destination: "+ item.Key);
                //item.key pour indiquez le key du IGrouping(string dans notre cas)
                foreach (var f in item)
                {
                    Console.WriteLine("flight date : "+ f.FlightDate);
                }
            }
            return query;
        }

        public double DurationAverage(string destination)
        {
            /*var query=from f in Flights
                      where f.Destination.Equals(destination)
                      select f.EstimatedDuration;
            return query.Average();*/

            //LAMBDA:
            return Flights.Where(f => f.Destination.Equals(destination))
                .Average(f=>f.EstimatedDuration);

        }

        public List<DateTime> GetFlightDates(string Destination)
        {
            // for structure
            List<DateTime> dates = new List<DateTime> ();
            //for (int i=0; i<Flights.Count; i++)
            //{
            //    if (Flights[i].Destination == Destination)
            //    {
            //        dates.Add(Flights[i].FlightDate);
            //    }
            //}
            //return dates;

            //foreach structure
            //foreach (Flight flight in Flights)
            //    {
            //        if (flight.Destination == Destination)
            //        {
            //            dates.Add(flight.FlightDate);
            //        }
            //    }
            //return dates;
            /*var query= from flight in Flights
                       where flight.Destination == Destination
                       select flight.FlightDate;
            return query.ToList();*/

            // la methode lambda: 
            return Flights.Where(f=> f.Destination == Destination)
                .Select(a=>a.FlightDate).ToList();
        }

        public IEnumerable<Staff> GetStaffOfFlightByFlightId(int flightId)
        {
            Flight flight= GetById(flightId);
            return flight.Passengers.OfType<Staff>();
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            /*var query=from flight in Flights
                      orderby flight.EstimatedDuration descending
                      select flight;
            return query;*/
            
            // LAMBDA :
            return Flights.OrderByDescending(f => f.EstimatedDuration);
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //LINQ
            /*var query = from flight in Flights
                        where  DateTime.Compare(flight.FlightDate, startDate) > 0
                        && (startDate - flight.FlightDate).TotalDays <= 7
                        select flight;
            return query.Count();*/
            //LAMBDA : 
            /*return Flights.Where(flight=> (startDate - flight.FlightDate).TotalDays<=7)
                          .Count();*/
            //2eme methode lambda: 
            return Flights.Count(flight => (startDate - flight.FlightDate).TotalDays <= 7);


        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {

            /*var query = from f in flight.Passengers.OfType<Traveller>()
                        orderby f.BirthDate descending
                        select f;
            return query.Take(3);  */
      
            //LAMBDA: 
            return flight.Passengers.OfType<Traveller>()
                .OrderByDescending(p => p.BirthDate)
                .Take(3);

        }

        public void ShowFlightDetails(Plane planne)
        {
            /*var query = from f in Flights
                        where planne == f.Plane
                        select new { f.Destination, f.FlightDate };
            */
            // methode avec l'expression lambda:
            var query = Flights.Where(p => planne == p.Plane)
                .Select(b => new { b.Destination, b.FlightDate });
            //p type : Flight
            //b: Flight respecte la condition précédente
            
            foreach (var item in query) { 

                Console.WriteLine(" Flight date : "+item.FlightDate);
                Console.WriteLine(" Destination : "+item.Destination);

            }
            
        }

        public IEnumerable<Flight> SortFlights()
        {
            return GetAll().OrderByDescending(f => f.FlightDate);
        }
    }
}
