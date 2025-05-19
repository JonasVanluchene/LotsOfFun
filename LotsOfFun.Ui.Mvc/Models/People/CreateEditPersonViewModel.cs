using System.ComponentModel.DataAnnotations;

namespace LotsOfFun.Ui.Mvc.Models.People
{
    public class CreateEditPersonViewModel
    {
        [Display(Name = "Voornaam")]
        [Required(ErrorMessage = "Voornaam is verplicht")]
        public required string FirstName { get; set; }

        [Display(Name = "Achternaam")]
        [Required(ErrorMessage = "Achternaam is verplicht")]
        public required string LastName { get; set; }

        public string? Email { get; set; }

        [Display(Name = "Telefoon")]
        public string? Phone  { get; set; }

        [Display(Name = "Straat")]
        public string? Street { get; set; }

        [Display(Name = "Nummer")]
        public string? Number { get; set; }

        [Display(Name = "Bus")]
        public string? Unit { get; set; }

        [Display(Name = "Postcode")]
        public string? PostalCode { get; set; }

        [Display(Name = "Gemeente")]
        public string? City { get; set; }


        [Display(Name = "Ik wil de uitnodigingen ontvangen")]
        public bool NewsLetter { get; set; }
    }
}
