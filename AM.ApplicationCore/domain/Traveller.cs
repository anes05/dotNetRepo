using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Traveller:Passenger
    {
        public string HealthInformation { get; set; }
        public String Nationality { get; set; }
        public override void PassengerType()
        {
            //cw+enter
            Console.WriteLine(" I am Passenger, I am Traveller member");
        }
    }
}
