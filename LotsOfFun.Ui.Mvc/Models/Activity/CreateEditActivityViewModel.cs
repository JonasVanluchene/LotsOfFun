using LotsOfFun.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LotsOfFun.Ui.Mvc.Models.Activity
{
    public class CreateEditActivityViewModel //: IValidatableObject
    {
        [Display(Name="Naam")]
        [Required(ErrorMessage="Naam is verplicht")]
        public required string Name { get; set; }

        [Display(Name="Omschrijving")]
        [StringLength(1000, ErrorMessage = "Omschrijving mag maximaal 1000 karakters bevatten")]
        public  string? Description { get; set; }
        

        [Display(Name = "Locatie")]
        [Required(ErrorMessage = "Locatie is verplicht")]
        public int SelectedLocationId { get; set; }
        public List<SelectListItem> Locations { get; set; }
       public  string Location { get; set; }

        public string LocationDataJson { get; set; }

        [Display(Name="Locatie opslaan")]
        public bool SaveLocation { get; set; }


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

        [Display(Name="Datum")]
        [Required(ErrorMessage = "Datum is verplicht")]
        public DateOnly StartDate { get; set; }

        [Display(Name = "Start tijd")]
        [Required(ErrorMessage = "Start tijd is verplicht")]
        public TimeOnly StartTime { get; set; }

        [Display(Name = "Eind tijd")]
        [Required(ErrorMessage = "Eind tijd is verplicht")]
        public TimeOnly EndTime { get; set; }

        [Display(Name="Minimum aantal deelnemers")]
        [Required(ErrorMessage = "Minimum aantal deelnemers is verplicht")]
        [Range(1, 100, ErrorMessage = "Aantal moet tussen 1 en 100 zijn")]
        public int MinimumParticipants { get; set; }

        [Display(Name = "Maximum aantal deelnemers")]
        [Required(ErrorMessage = "Maximum aantal deelnemers is verplicht")]
        [Range(1,100,ErrorMessage = "Aantal moet tussen 1 en 100 zijn")]
        public int MaximumParticipants { get; set; }

        [Display(Name="Prijs")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Prijs is verplicht")]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }




        //CUSTOM MODELSTATE VALIDATION WITH IVALIDATABLEOBJECT INTERFACE
        
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
            
        //        if (MaximumParticipants < MinimumParticipants)
        //        {
        //            yield return new ValidationResult(
        //                "Maximum aantal deelnemers moet groter of gelijk zijn aan minimum aantal deelnemers.",
        //                new[] { nameof(MaximumParticipants), nameof(MinimumParticipants) });
        //        }
            

            
        //        if (StartDate >= EndDate)
        //        {
        //            yield return new ValidationResult(
        //                "Start tijd moet vóór de eind tijd zijn.",
        //                new[] { nameof(StartDate), nameof(EndDate) });
        //        }
            
        //}
    }
}
