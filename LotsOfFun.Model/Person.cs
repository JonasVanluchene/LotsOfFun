using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfFun.Model
{
    [Table(nameof(Person))]
    public class Person
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string? Email  { get; set; }
        public string? Phone { get; set; }

        public Address? Address { get; set; }
        

        public bool NewsLetter { get; set; }
        public bool IsActive { get; set; }
        public bool IsVolunteer { get; set; }

        public List<ActivityRegistration> ActivityRegistrations { get; set; } = new();
    }
}
