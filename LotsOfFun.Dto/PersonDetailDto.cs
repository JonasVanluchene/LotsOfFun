using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfFun.Dto
{
    public class PersonDetailDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool NewsLetter { get; set; }
        public bool IsVolunteer { get; set; }
        public string FullAddress { get; set; } = string.Empty;
    }
}
