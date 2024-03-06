using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Staff:Passenger
    {
        public DateTime EmploymentDate { get; set; }
        [DataType(DataType.Currency)]
        public Double Salary { get; set; }
        public String  Function { get; set; }
        public override void PassengerType()
        {
            //cw+enter
            Console.WriteLine(" I am Passenger, I am staff member");
        }
    }


}
