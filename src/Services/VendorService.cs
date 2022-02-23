using Microsoft.Extensions.Logging;
using Intertel.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Intertel.Entities;
using Intertel.Models;

namespace Intertel.Service
{
    public class VendorService : IVendorService
    {
        private AppDbContext _dbContext = null;
        private ILogger<VendorService> _logger = null;

        public VendorService(
            AppDbContext dbContext,
            ILogger<VendorService> logger)
        {
            _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));

            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));

        }

        public async Task<IQueryable<Vendor>> GetVendorListAsync(MasterSearchParam? param = null)
        {
            var vendorList = _dbContext.Vendor.AsNoTracking().Where(l => !l.IsDeleted);

            if (param != null)
            {
                if (!string.IsNullOrWhiteSpace(param.name))
                    vendorList = vendorList.Where(l => l.Name.IndexOf(param.name) > -1);
            }

            return vendorList;
        }

        public async Task<Vendor> FindAsync(int id)
        {
            var vendor = await _dbContext.Vendor.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);

            return vendor;
        }

        public async Task<Vendor> SaveAsync(Vendor postedVendor)
        {
            var vendor = await _dbContext.Vendor.AsNoTracking().Where(s => s.Id == postedVendor.Id).FirstOrDefaultAsync();

            if (vendor != null)
            {
                _dbContext.Entry<Vendor>(postedVendor).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Vendor.Add(postedVendor);
            }

            await _dbContext.SaveChangesAsync();

            return postedVendor;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vendor = await _dbContext.Vendor.AsNoTracking().Where(s => s.Id == id).FirstOrDefaultAsync();

            if (vendor == null)
                return false;

            vendor.IsDeleted = true;

            _dbContext.Entry<Vendor>(vendor).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}