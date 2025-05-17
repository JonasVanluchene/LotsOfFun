using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LotsOfFun.Model
{
    
   
    
    public class Address
    {
        public required string Street { get; set; }
        public required string Number { get; set; }

        public string? UnitNumber { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }
    }
}
