using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        

        public ActivityService(LotsOfFunDbContext dbContext)
        {
            _dbContext = dbContext;
             
        }


        public async Task<IList<ActivityDto>> GetAll()
        {
            var activities = await _dbContext.Activities.Include(a => a.Location).ToListAsync();

            return activities.Select(a => new ActivityDto
            {
                Id =a.Id,
                Name = a.Name,
                Description = a.Description,
                Location = a.Location.Name,
                FullAddress = StringFormatter.FormatAddress(a.Location.Address),
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                MinimumParticipants = a.MinimumParticipants,
                MaximumParticipants = a.MaximumParticipants,
                Price = a.Price,
                ImageUrl = a.ImageUrl
            }).ToList();
        }


        public async Task<ActivityDetailDto?> Get(int id)
        {
            var activity = await _dbContext.Activities.FirstOrDefaultAsync(b => b.Id == id);
            if (activity == null)
            {
                return null;
            }
                

            return new ActivityDetailDto();


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
