using Microsoft.Extensions.Logging;
using Intertel.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Intertel.Entities;
using System;
using Intertel.Models;

namespace Intertel.Service
{
    public class LocationService : ILocationService
    {
        private AppDbContext _dbContext = null;
        private ILogger<LocationService> _logger = null;

        public LocationService(
            AppDbContext dbContext,
            ILogger<LocationService> logger)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));

            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));

        }

        public async Task<IQueryable<Location>> GetLocationListAsync(MasterSearchParam? param = null)
        {
            var locationList = _dbContext.Location.AsNoTracking().Where(l => !l.IsDeleted);

            if (param != null)
            {
                if (!string.IsNullOrWhiteSpace(param.name))
                    locationList = locationList.Where(l => l.Name.IndexOf(param.name) > -1);
            }

            return locationList;
        }

        public async Task<Location> FindAsync(int id)
        {
            var location = await _dbContext.Location.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);

            return location;
        }

        public async Task<Location> SaveAsync(Location postedLocation)
        {
            var location = await _dbContext.Location.AsNoTracking().Where(s => s.Id == postedLocation.Id).FirstOrDefaultAsync();

            if (location != null)
            {
                _dbContext.Entry<Location>(postedLocation).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Location.Add(postedLocation);
            }

            await _dbContext.SaveChangesAsync();

            return postedLocation;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var location = await _dbContext.Location.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

            if (location == null)
                return false;

            location.IsDeleted = true;

            _dbContext.Entry<Location>(location).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}