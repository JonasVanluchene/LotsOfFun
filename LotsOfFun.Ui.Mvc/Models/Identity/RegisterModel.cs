using System.ComponentModel.DataAnnotations;

namespace LotsOfFun.Ui.Mvc.Models.Identity
{
    public class RegisterModel
    {
        [Display(Name = "Voornaam")]
        [Required(ErrorMessage = "Voornaam is verplicht")]
        [StringLength(50, ErrorMessage = "Voornaam mag maximaal 50 karakters bevatten")]
        public required string FirstName { get; set; }

        [Display(Name = "Achternaam")]
        [Required(ErrorMessage = "Achternaam is verplicht")]
        [StringLength(75, ErrorMessage = "Achternaam mag maximaal 75 karakters bevatten")]
        public required string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public required string ConfirmPassword { get; set; }

        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email mag maximaal 100 karakters bevatten")]
        public string? Email { get; set; }

        [Phone]
        [StringLength(20, ErrorMessage = "Telefoonnummer mag maximaal 20 karakters bevatten")]
        [Display(Name = "Telefoon")]
        public string? Phone { get; set; }

        [Display(Name = "Straat")]
        [StringLength(100, ErrorMessage = "Straat mag maximaal 100 karakters bevatten")]
        public string? Street { get; set; }

        [Display(Name = "Nummer")]
        [StringLength(10, ErrorMessage = "Nummer mag maximaal 10 karakters bevatten")]
        public string? Number { get; set; }

        [Display(Name = "Bus")]
        [StringLength(10, ErrorMessage = "Bus mag maximaal 10 karakters bevatten")]
        public string? Unit { get; set; }

        [Display(Name = "Postcode")]

        [StringLength(10, ErrorMessage = "Postcode mag maximaal 10 karakters bevatten")]
        public string? PostalCode { get; set; }

        [Display(Name = "Gemeente")]
        [StringLength(50, ErrorMessage = "Gemeente mag maximaal 50 karakters bevatten")]
        public string? City { get; set; }


        [Display(Name = "Ik wil de uitnodigingen ontvangen")]
        public bool NewsLetter { get; set; }

    }
}
