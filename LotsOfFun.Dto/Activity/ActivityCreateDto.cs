using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfFun.Dto.Activity
{
    public class ActivityCreateDto
    {
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
    }
}
