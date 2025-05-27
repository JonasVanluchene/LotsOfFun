namespace LotsOfFun.Dto.Activity
{

    //I use this Dto to transfer data between ActivityService and Mvc controller to list activities and activity details

    public class ActivityDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public int LocationId { get; set; }
        public string FullAddress { get; set; } 

        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int MinimumParticipants { get; set; }
        public int MaximumParticipants { get; set; }
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}
