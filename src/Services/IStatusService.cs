using System.Collections.Generic;
using System.Threading.Tasks;
using Intertel.Entities;
using System.Linq;
using System;

namespace Intertel.Service
{
    public interface IStatusService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<Status>> All();

        Task<Status> SaveAsync(Status postedStatus);

        Task<Status> GetById(Guid id);

        Task<bool> DeleteAsync(Guid id);

    }
}