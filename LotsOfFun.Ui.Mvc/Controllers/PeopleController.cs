using AutoMapper;
using LotsOfFun.Dto;
using LotsOfFun.Model;
using LotsOfFun.Services;
using LotsOfFun.Ui.Mvc.Models;
using LotsOfFun.Ui.Mvc.Models.People;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace LotsOfFun.Ui.Mvc.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PersonService _personService;
        private readonly IMapper _mapper;

        public PeopleController(PersonService personService,IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var people = await _personService.GetAll();


                var viewModel = new PeopleViewModel()
                {
                    //Manual mapping from dto to viewmodel (could implement automapper later)
                    People = people.Select(p =>
                        new PersonViewModel
                        {
                            Id = p.Id,
                            Name = p.FullName,
                            Email = p.Email
                        }
                    ).ToList()
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework in real apps)
                Console.WriteLine($"Error retrieving people: {ex.Message}");

                // Optionally show an error view or a message
                return View("Error");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var personDto = await _personService.GetDetails(id);
            if (personDto == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<PersonDetailViewModel>(personDto);
            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEditPersonViewModel viewModel)
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
        public async Task<IActionResult> Edit([FromRoute]int id)
        {
            var person = await _personService.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            var viewModel = new CreateEditPersonViewModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Phone = person.Phone,
                NewsLetter = person.NewsLetter,
                Street = person.Address.Street,
                Number = person.Address.Number,
                Unit = person.Address.UnitNumber,
                PostalCode = person.Address.PostalCode,
                City = person.Address.City
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id,[FromForm] CreateEditPersonViewModel viewModel)
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

            var dto = _mapper.Map<UpdatePersonDto>(viewModel);
            var updatedPerson = await _personService.Update(id, dto);

            if (updatedPerson == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");


        }


        [HttpGet]
        public IActionResult ExportNewsletterEmails()
        {
            var emails = _personService.GetNewsletterSubscriberEmails();

            if (!emails.Any())
            {
                TempData["Message"] = "Er zijn geen nieuwsbrief abonnees gevonden.";
                return RedirectToAction("Index");
            }

            // Create comma-separated list of emails
            var emailContent = string.Join(", ", emails);

            // Return as downloadable text file
            byte[] bytes = Encoding.UTF8.GetBytes(emailContent);
            return File(bytes, "text/plain", "newsletter_subscribers.txt");
        }
    }
}
