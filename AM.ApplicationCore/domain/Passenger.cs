using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Passenger

    {
        [Key]
        [StringLength(7)]
        public String PasseportNumber  { get; set; }
        public FullName FullName { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        //[RegularExpression(@"^\[0-9]{8}$")]
        //[DataType(dataType: DataType.PhoneNumber)]
        [RegularExpression(@"^\d{8}$")]
        public int TelNumber { get; set; }
        [EmailAddress]
        public String EmailAddress { get; set; }
        //public int Id { get; set; }// soit Id soit PassengerId, keyword Id to reference an Id of object
        //public int PassengerId { get; set; }
        public virtual List<ReservationTicket> reservationTickets { get; set; }

        public virtual IList<Flight> Flights { get; set; }
        public bool CheckProfile(String nom, String prenom)
        {
            return nom==this.FullName.FirstName && prenom==this.FullName.LastName;
        }

        public bool CheckProfile(String nom,String prenom, String email)
        {
            return nom==this.FullName.FirstName && prenom==this.FullName.LastName && email==this.EmailAddress;    
        }

        public bool login(String nom, String prenom, String email=null)
        {
          /*  if (email == null){
                return CheckProfile(nom, prenom);
            }else {
                return CheckProfile(nom, prenom, email);
            }*/

            return email==null ? CheckProfile(nom, prenom): CheckProfile(nom, prenom, email);
        }
        public virtual void PassengerType()
        {
            //cw+enter
            Console.WriteLine(" I am Passenger");
        }

    }
}
