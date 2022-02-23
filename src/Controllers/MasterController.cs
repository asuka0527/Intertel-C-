
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Intertel.Entities;
using Intertel.Service;
// using Intertel.Extention;

namespace Intertel.Controllers
{
    [Route("Api/Master")]
    public class MasterController : ControllerBase
    {
        private readonly ILogger<MasterController> _logger;
        private readonly MasterService _masterService;

        public MasterController(ILogger<MasterController> logger,
                                MasterService masterService)
        {
            _logger = logger;
            _masterService = masterService;

        }

        //     public IEnumerable<SelectListItem> GetConstructionStatusList()
        // {
        //     var statusList = new List<SelectListItem>() {
        //         new SelectListItem(){ Value = "order", Text = "受注" },
        //         new SelectListItem(){ Value = "incomplete", Text = "未完" },
        //         new SelectListItem(){ Value = "completion", Text = "完工" },
        //         new SelectListItem(){ Value = "fixed", Text = "確定" },
        //         new SelectListItem(){ Value = "postponement", Text = "延期" },
        //     };

        //     return statusList;
        // }


        [HttpGet("Locations")]
        // [Authorize]
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Location> Locations()
        {
            var locations = _masterService.GetLocations();
            return locations.ToList();
        }

        [HttpGet("Vendors")]
        // [Authorize]
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vendor> Vendors()
        {
            var vendors = _masterService.GetVendors();
            return vendors.ToList();
        }

        [HttpGet("Units")]
        // [Authorize]
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Unit> Units()
        {
            var units = _masterService.GetUnits();
            return units.ToList();
        }

        [HttpGet("Status")]
        // [Authorize]
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Status> Status()
        {
            var status = _masterService.GetStatus();
            return status.ToList();
        }
    }
}