using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfFun.Model
{
    [Table(nameof(ActivityRegistration))]
    public class ActivityRegistration
    {
        public int Id { get; set; }

        public string PersonId { get; set; }
        public required Person Person { get; set; }

        public int ActivityId { get; set; }
        public required Activity Activity { get; set; } 

        public DateTime RegisteredAt { get; set; }
        public bool HasPayed { get; set; }




        //public ActivityRegistration(Person person, Activity activity)
        //{
        //    Person = person;
        //    PersonId = person.Id;

        //    Activity = activity;
        //    ActivityId = activity.Id;

        //    RegisteredAt = DateTime.UtcNow;
        //}

        //private ActivityRegistration() { } // For EF
    }
}
