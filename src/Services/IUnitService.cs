using System.Threading.Tasks;
using Intertel.Entities;
using System.Linq;
using Intertel.Models;

namespace Intertel.Service
{
    public interface IUnitService
    {
        Task<IQueryable<Unit>> GetUnitListAsync(MasterSearchParam? param = null);

        Task<Unit> SaveAsync(Unit postedUnit);

        Task<Unit> FindAsync(int id);

        Task<bool> DeleteAsync(int id);

    }
}