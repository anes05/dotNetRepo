// See https://aka.ms/new-console-template for more information


using AM.ApplicationCore.domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using System.Collections.Concurrent;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Hello, World!");
Plane plane = new Plane();
//set cpaacity
plane.Capacity = 20;

Plane p2 = new Plane
{
    Capacity = 20,
    PlaneType = PlaneType.Airbus
};

Passenger passenger = new() {
    FullName = new() { FirstName = "Test", LastName = "prenom" },
    EmailAddress = "Test@gmail.com",

};

Staff staff = new Staff()
{
    FullName = new() { FirstName = "aziz" },
};

Traveller traveller = new Traveller()
{
    FullName = new() { FirstName = "youssf" },
};
Console.WriteLine(" ************** POlY PAR SIGNATURE *************");
Console.WriteLine(passenger.CheckProfile("Test", "prenom"));
Console.WriteLine(passenger.CheckProfile("anes","msaddak", "anes@gmail.com"));

passenger.PassengerType();
staff.PassengerType();
traveller.PassengerType();

/*FlightMethods fM = new FlightMethods();
 fM.Flights = TestData.listFlights;
Console.WriteLine("show flight details: ");
fM.ShowFlightDetails(TestData.Airbusplane);
Console.WriteLine("get flight details: ");
foreach (var item in fM.GetFlightDates("Madrid"))
{
    Console.WriteLine(item);
}

Console.WriteLine("destinations grouped : ");
fM.DestinationGroupedFlights();*/