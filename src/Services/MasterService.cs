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
    public class MasterService
    {
        private readonly AppDbContext _dbContext;
        public MasterService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Location> GetLocations()
        {
            return _dbContext.Location
                             .Where(p => !p.IsDeleted)
                             .AsNoTracking();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vendor> GetVendors()
        {
            return _dbContext.Vendor
                             .Where(p => !p.IsDeleted)
                             .AsNoTracking();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Unit> GetUnits()
        {
            return _dbContext.Unit
                             .Where(p => !p.IsDeleted)
                             .AsNoTracking();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Status> GetStatus()
        {
            return _dbContext.Status
                             .AsNoTracking();
        }
    }
}