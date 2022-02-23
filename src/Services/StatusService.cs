using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Intertel.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Intertel.Models;
using Intertel.Entities;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Newtonsoft.Json;

namespace Intertel.Service
{

    public class StatusService : IStatusService
    {

        private AppDbContext _dbContext = null;
        private ILogger<StatusService> _logger = null;
        public IHttpContextAccessor _httpContextAccessor;
        private UserManager<IdentityUser> _userManager;

        public StatusService(AppDbContext dbContext, ILogger<StatusService> logger, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));

            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));

            _userManager = userManager ?? throw new System.ArgumentNullException(nameof(userManager));
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IQueryable<Status>> All()
        {
            var statuses = _dbContext.Status.AsNoTracking();
            return statuses;
        }

        public async Task<Status> GetById(Guid id)
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