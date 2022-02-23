using System.Threading.Tasks;
using Intertel.Entities;
using System.Linq;
using Intertel.Models;

namespace Intertel.Service
{
    public interface ILocationService
    {
        Task<IQueryable<Location>> GetLocationListAsync(MasterSearchParam? param = null);

        Task<Location> SaveAsync(Location postedLocation);

        Task<Location> FindAsync(int id);

        Task<bool> DeleteAsync(int id);

    }
}