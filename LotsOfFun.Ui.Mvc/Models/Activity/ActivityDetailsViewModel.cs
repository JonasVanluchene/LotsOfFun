namespace LotsOfFun.Ui.Mvc.Models.Activity
{
    public class ActivityDetailsViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; }
        public string FullAddress { get; set; }

        public string  ImageUrl { get; set; }
    }
}
