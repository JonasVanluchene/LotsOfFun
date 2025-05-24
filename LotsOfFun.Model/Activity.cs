using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfFun.Model
{
    [Table(nameof(Activity))]
    public class Activity
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int MinimumParticipants { get; set; }
        public int MaximumParticipants { get; set; }
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }



        public int? LocationId { get; set; }
        public  Location Location { get; set; }

        public List<ActivityRegistration> ActivityRegistrations { get; set; } = new();
    }
}
