using LotsOfFun.Model;
using LotsOfFun.Services;
using LotsOfFun.Ui.Mvc.Helper.Validate;
using LotsOfFun.Ui.Mvc.Models.Activity;
using Microsoft.AspNetCore.Mvc;

namespace LotsOfFun.Ui.Mvc.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ActivityService _activityService;

        public ActivitiesController(ActivityService activityService)
        {
            _activityService = activityService;
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
        public IActionResult Create()
        {
            return View();
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

            if (viewModel.StartDate >= viewModel.EndDate)
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


            var activity = new Activity
            {
                Name = viewModel.Name,
                Description = viewModel.Description ?? "No description provided",
                Location = viewModel.Location,
                Address = address,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
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
        public IActionResult Delete([FromRoute] int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
