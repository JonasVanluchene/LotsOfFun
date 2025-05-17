using LotsOfFun.Model;
using LotsOfFun.Services;
using LotsOfFun.Ui.Mvc.Models;
using LotsOfFun.Ui.Mvc.Models.People;
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

        public async Task<IActionResult> Index()
        {
            var people = await _personService.GetAll();
            var viewModel = new PeopleViewModel()
            {
                People = people.Select(p =>

                    new PersonViewModel
                    {
                        Id = p.Id,
                        Name = $"{p.FirstName} {p.LastName}",
                        Email = p.Email ?? "No Email"
                    }
                ).ToList()

            };

            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Details()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePersonViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            Person person = new Person()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                NewsLetter = viewModel.NewsLetter,
                Address = new Address
                {
                    Street = viewModel.Street,
                    Number = viewModel.Number,
                    UnitNumber = viewModel.Unit,
                    PostalCode = viewModel.PostalCode,
                    City = viewModel.City
                }

            };

            await _personService.Create(person);

            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("{controller}/Edit/{id:int}")]
        public async Task<IActionResult> Edit([FromRoute]int id)
        {
            var person = await _personService.Get(id);
            var viewModel = new CreatePersonViewModel()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                City = person.Address.City,
                Street = person.Address.Street,
                Number = person.Address.Number,
                Unit = person.Address.UnitNumber,
                PostalCode = person.Address.PostalCode,
                Email = person.Email,
                NewsLetter = person.NewsLetter,
                Phone = person.Phone

            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id,[FromForm] CreatePersonViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var person = await _personService.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            // Map updated fields from ViewModel to entity(or dto?)
            person.FirstName = viewModel.FirstName;
            person.LastName = viewModel.LastName;
            person.Email = viewModel.Email;
            person.Phone = viewModel.Phone;
            person.NewsLetter = viewModel.NewsLetter;
            person.Address.Street = viewModel.Street;
            person.Address.Number = viewModel.Number;
            person.Address.UnitNumber = viewModel.Unit;
            person.Address.PostalCode = viewModel.PostalCode;
            person.Address.City = viewModel.City;

            var updatedPerson = await _personService.Update(id, person);
            if (updatedPerson == null)
            {
                return NotFound(); // Or handle update failure differently
            }

            return RedirectToAction("Index");

            
        }
    }
}
