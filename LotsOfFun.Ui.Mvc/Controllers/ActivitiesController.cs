using LotsOfFun.Model;
using LotsOfFun.Services;
using LotsOfFun.Ui.Mvc.Helper.Validate;
using LotsOfFun.Ui.Mvc.Models.Activity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace LotsOfFun.Ui.Mvc.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ActivityService _activityService;
        private readonly LocationService _locationService;


        public ActivitiesController(ActivityService activityService, LocationService locationService)
        {
            _activityService = activityService;
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var activities = await _activityService.GetAll();
            var viewModel = new ActivitiesViewModel
            {
                Activities = activities.Select(a => new ActivityViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Location = a.Location
                }).ToList(),
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var locations = await _locationService.GetAll();

            var locationDataJson = JsonSerializer.Serialize(locations.Select(l => new {
                id = l.Id,
                street = l.Address.Street,
                number = l.Address.Number,
                unit = l.Address.UnitNumber,
                postalCode = l.Address.PostalCode,
                city = l.Address.City
            }));

            CreateEditActivityViewModel viewModel = new CreateEditActivityViewModel
            {
                MaximumParticipants = 25,
                MinimumParticipants = 1,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                StartTime = new TimeOnly(13, 30),
                EndTime = new TimeOnly(16, 30),
                Name = String.Empty,
                SelectedLocationId = 0,
                Locations = new List<SelectListItem>
                    {
                        new SelectListItem { Value = "", Text = "-- Select a location --" }
                    }
                    .Concat(locations.Select(l => new SelectListItem
                    {
                        Value = l.Id.ToString(),
                        Text = l.Name
                    }))
                    .ToList(),
                LocationDataJson = locationDataJson,
                Price = 5.0M

            };

            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateEditActivityViewModel viewModel)
        {
            

            //Custom validation for some properties can also be done in the viewmodel with IValidatableObject
            if (viewModel.MaximumParticipants < viewModel.MinimumParticipants)
            {
                ModelState.AddModelError(nameof(viewModel.MaximumParticipants),
                    "Maximum aantal deelnemers moet groter of gelijk zijn aan minimum aantal deelnemers.");
                
            }

            if (viewModel.StartTime >= viewModel.EndTime)
            {
                ModelState.AddModelError(nameof(viewModel.StartDate),
                    "Start tijd moet vóór de eind tijd zijn.");
                return View(viewModel);
            }

            if (!Validator.TryCreateAddress(
                    viewModel.Street,
                    viewModel.Number,
                    viewModel.Unit,
                    viewModel.PostalCode,
                    viewModel.City,
                    out var address))
            {
                ModelState.AddModelError("", "Vul alle verplichte adresvelden in of laat ze volledig leeg.");
                
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            if (viewModel.SaveLocation == true)
            {
                _locationService.Create(new Location
                {
                    Name= viewModel.Location,
                    Address = new Address
                    {
                        Street = viewModel.Street,
                        Number = viewModel.Number,
                        UnitNumber = viewModel.Unit,
                        PostalCode = viewModel.PostalCode,
                        City = viewModel.City
                    }
                });
            }

            var startDate = viewModel.StartDate.ToDateTime(viewModel.StartTime);
            var endDate = viewModel.StartDate.ToDateTime(viewModel.EndTime);
            var location = await _locationService.Get(viewModel.SelectedLocationId);
            var activity = new Activity
            {
                Name = viewModel.Name,
                Description = viewModel.Description ?? "No description provided",
                Location = location,
                StartDate = startDate,
                EndDate = endDate,
                MinimumParticipants = viewModel.MinimumParticipants,
                MaximumParticipants = viewModel.MaximumParticipants,
                Price = viewModel.Price,
                CreatedAt = DateTime.Now
            };
            await _activityService.Create(activity);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, [FromForm] CreateEditActivityViewModel viewModel)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _activityService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
