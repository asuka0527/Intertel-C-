using Microsoft.Extensions.Logging;
using Intertel.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Intertel.Entities;
using System;

namespace Intertel.Service
{

    public class StatusService : IStatusService
    {

        private AppDbContext _dbContext = null;
        private ILogger<StatusService> _logger = null;


        public StatusService(
            AppDbContext dbContext,
            ILogger<StatusService> logger)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));

            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));

        }

        public async Task<IQueryable<Status>> GetStatusListAsync()
        {
            var statusList = _dbContext.Status.AsNoTracking();

            return statusList;
        }

        public async Task<Status> FindAsync(Guid id)
        {
            var status = await _dbContext.Status.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);

            return status;
        }

        public async Task<Status> SaveAsync(Status postedStatus)
        {
            var status = await _dbContext.Status.AsNoTracking().Where(s => s.Id == postedStatus.Id).FirstOrDefaultAsync();

            if (status != null)
            {
                _dbContext.Entry<Status>(postedStatus).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Status.Add(postedStatus);
            }

            await _dbContext.SaveChangesAsync();

            return postedStatus;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var status = await _dbContext.Status.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();
            if (status == null)
                return false;

            _dbContext.Status.Remove(status);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}