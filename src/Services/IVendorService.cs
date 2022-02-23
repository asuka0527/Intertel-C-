using System.Threading.Tasks;
using Intertel.Entities;
using System.Linq;
using Intertel.Models;

namespace Intertel.Service
{
    public interface IVendorService
    {
        Task<IQueryable<Vendor>> GetVendorListAsync(MasterSearchParam? param = null);

        Task<Vendor> SaveAsync(Vendor postedVendor);

        Task<Vendor> FindAsync(int id);

        Task<bool> DeleteAsync(int id);

    }
}