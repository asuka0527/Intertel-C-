using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Intertel.Service;
using Intertel.Models;
using Intertel.Entities;
using X.PagedList;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Intertel.Controllers
{
    [Route("Status")]
    public class StatusController : Controller
    {
        private readonly ILogger<StatusController> _logger;

        public StatusController(
            ILogger<StatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        // [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }

    [Route("Api/Status")]
    public class StatusApiController : Controller
    {
        private readonly ILogger<StatusApiController> _logger;
        private readonly IStatusService _statusService;

        public StatusApiController(
            ILogger<StatusApiController> logger,
            IStatusService statusService)
        {
            _logger = logger;
            _statusService = statusService;
        }

        [HttpGet("Find")]
        public async Task<ActionResult<Status>> Find(Guid id)
        {
            var status = await _statusService.FindAsync(id);

            if (status == null)
                return NotFound();

            return status;
        }


        [HttpGet("Search")]
        public async Task<Pagenate<Status>> Search([FromQuery] MasterSearchParam searchParam)
        {
            var statuses = await _statusService.GetStatusListAsync();

            if (!string.IsNullOrWhiteSpace(searchParam.name))
                statuses = statuses.Where(o => o.Name.IndexOf(searchParam.name) > -1);
            searchParam.limt = 5;

            var list = statuses.ToPagedList(searchParam.page, searchParam.limt >= 100 ? 100 : searchParam.limt);

            return new Pagenate<Status>()
            {
                Data = list,
                MetaData = list.GetMetaData()
            };
        }

        [HttpPost("Save")]
        // [Authorize]
        public async Task<ActionResult<Status>> Save([FromBody] Status postedStatus)
        {
            if (ModelState.IsValid)
            {
                postedStatus = await _statusService.SaveAsync(postedStatus);
            }
            else
            {
                return BadRequest();
            }

            return postedStatus;
        }

        [HttpDelete("")]
        // [Authorize]
        public async Task<ActionResult> Remove(Guid id)
        {
            var result = false;

            result = await _statusService.DeleteAsync(id);

            if (result == false)
                return NotFound();

            return Ok();
        }
    }
}