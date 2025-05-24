using AutoMapper;
using LotsOfFun.Dto.Activity;
using LotsOfFun.Model;
using LotsOfFun.Repository;
using LotsOfFun.Services.Helper;
using Microsoft.EntityFrameworkCore;

namespace LotsOfFun.Services
{
    public class ActivityService
    {

        private readonly LotsOfFunDbContext _dbContext;
        private readonly IMapper _mapper;

        public ActivityService(LotsOfFunDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<IList<ActivityDto>> GetAll()
        {
            // Retrieve all activities from the database, including their associated Location
            var activities = await _dbContext.Activities.Include(a => a.Location).ToListAsync();


            // Map the list of Activity domain models to a list of ActivityDto objects using AutoMapper
            var mappedActivities = _mapper.Map<List<ActivityDto>>(activities);

            // Return the list of ActivityDto objects to the controller
            return mappedActivities;
        }


        public async Task<ActivityDto?> Get(int id)
        {
            // Retrieve a single Activity from the database (including related Location)
            var activity = await _dbContext.Activities
                .Include(a => a.Location)
                .FirstOrDefaultAsync(b => b.Id == id);

            // If not found, return null
            if (activity == null)
            {
                return null;
            }

            // Map the Activity to an ActivityDto and return it (to the controller)
            return _mapper.Map<ActivityDto>(activity);
        }


        public async Task<Activity?> Create(Activity activity)
        {
            await _dbContext.Activities.AddAsync(activity);
            await _dbContext.SaveChangesAsync();
            return activity;
        }

        public async Task<Activity?> Update(int id, Activity activity)
        {
            var dbActivity = await _dbContext.Activities.FirstOrDefaultAsync(a => a.Id == id);
            if (dbActivity is null)
            {
                return null;
            }

            dbActivity.Name = activity.Name;
            dbActivity.Description = activity.Description;
            dbActivity.Location = activity.Location;

            dbActivity.StartDate = activity.StartDate;
            dbActivity.EndDate = activity.EndDate;

            dbActivity.MinimumParticipants = activity.MinimumParticipants;
            dbActivity.MaximumParticipants = activity.MaximumParticipants;

            dbActivity.Price = activity.Price;

            dbActivity.ImageUrl = activity.ImageUrl;

            await _dbContext.SaveChangesAsync();
            return dbActivity;
        }

        public async Task Delete(int id)
        {
            var activity = await _dbContext.Activities.FirstOrDefaultAsync(a => a.Id == id);
            if (activity is null)
            {
                return;
            }
            _dbContext.Activities.Remove(activity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
