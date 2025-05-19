using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotsOfFun.Dto.Activity
{
    public class ActivityDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public string FullAddress { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int MinimumParticipants { get; set; }
        public int MaximumParticipants { get; set; }
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}
