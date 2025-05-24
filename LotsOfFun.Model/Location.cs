using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfFun.Model
{
    [Table(nameof(Location))]
    public class Location
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public Address Address { get; set; }
    }
}
