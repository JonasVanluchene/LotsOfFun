using LotsOfFun.Services;
using LotsOfFun.Ui.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace LotsOfFun.Ui.Mvc.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PersonService _personService;

        public PeopleController(PersonService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            var people = _personService.GetAll();
            var viewModel = new PeopleViewModel()
            {
                People = people.Select(p =>

                    new PersonViewModel
                    {
                        Name = $"{p.FirstName} {p.LastName}",
                        Email = p.Email ?? "No Email"
                    }
                ).ToList()

            };

            return View(viewModel);
        }
    }
}
