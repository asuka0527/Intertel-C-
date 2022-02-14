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
        /// <summary>
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<Status> CreateAsync(Status status);

        Task<Status> SaveAsync(Status status);

        Task<Status> GetById(Guid id);

        Task<bool> DeleteAsync(Guid id);

    }
}