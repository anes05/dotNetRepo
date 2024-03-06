using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    //[Owned]
    public class FullName
    {
      /*  [MinLength(3, ErrorMessage = "la longuer doit etre superier a 3")]
        [MaxLength(25, ErrorMessage = "la longuer doit etre inferieure a 25")]*/
        public String FirstName { get; set; }
        public String LastName { get; set; }
        
    }
}
