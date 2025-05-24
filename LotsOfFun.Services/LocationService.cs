using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotsOfFun.Model;
using LotsOfFun.Repository;
using Microsoft.EntityFrameworkCore;

namespace LotsOfFun.Services
{
    public class LocationService
    {
        private readonly LotsOfFunDbContext _dbContext;

        public LocationService(LotsOfFunDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IList<Location>> GetAll()
        {
            return await _dbContext.Locations.ToListAsync();
        }

        public async Task<Location?> Get(int id)
        {
            return await _dbContext.Locations.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        }


        public async Task<Location?> Create(Location location)
        {

            await _dbContext.Locations.AddAsync(location);
            await _dbContext.SaveChangesAsync();
            return location;
        }
    }
}
