using Microsoft.Extensions.Logging;
using Intertel.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Intertel.Entities;
using Intertel.Models;

namespace Intertel.Service
{
    public class UnitService : IUnitService
    {
        private AppDbContext _dbContext = null;
        private ILogger<UnitService> _logger = null;

        public UnitService(
            AppDbContext dbContext,
            ILogger<UnitService> logger)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));

            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));

        }

        public async Task<IQueryable<Unit>> GetUnitListAsync(MasterSearchParam? param = null)
        {
            var unitList = _dbContext.Unit.AsNoTracking().Where(l => !l.IsDeleted);

            if (param != null)
            {
                if (!string.IsNullOrWhiteSpace(param.name))
                    unitList = unitList.Where(l => l.Name.IndexOf(param.name) > -1);
            }

            return unitList;
        }

        public async Task<Unit> FindAsync(int id)
        {
            var unit = await _dbContext.Unit.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);

            return unit;
        }

        public async Task<Unit> SaveAsync(Unit postedUnit)
        {
            var unit = await _dbContext.Unit.AsNoTracking().Where(s => s.Id == postedUnit.Id).FirstOrDefaultAsync();

            if (unit != null)
            {
                _dbContext.Entry<Unit>(postedUnit).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Unit.Add(postedUnit);
            }

            await _dbContext.SaveChangesAsync();

            return postedUnit;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var unit = await _dbContext.Unit.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

            if (unit == null)
                return false;

            unit.IsDeleted = true;

            _dbContext.Entry<Unit>(unit).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}