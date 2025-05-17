namespace LotsOfFun.Ui.Mvc.Models.People
{
    public class PersonDetailViewModel
    {
        public string FullName => $"{FirstName} {LastName}";
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool NewsLetter { get; set; }

        public string FullAddress { get; set; } = string.Empty;

        public bool  IsVolunteer { get; set; }
    }
}
