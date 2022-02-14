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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }

    [Route("StatusApi")]
    public class StatusApiController : Controller
    {
        private readonly ILogger<StatusApiController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IItemService _itemService;
        private readonly IStatusService _statusService;

        public IHttpContextAccessor _httpContextAccessor;

        public StatusApiController(
            ILogger<StatusApiController> logger,
            UserManager<IdentityUser> userManager,
            IItemService itemService,
            IStatusService statusService,
            IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _userManager = userManager;
            _itemService = itemService;
            _statusService = statusService;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet("Search")]
        public async Task<Pagenate<Status>> Search([FromQuery] ItemSearchParam searchParam)
        {
            var statuses = await _statusService.All();
            if (!string.IsNullOrWhiteSpace(searchParam.model))
                statuses = statuses.Where(o => o.Name.IndexOf(searchParam.model) > -1);
            searchParam.limt = 5;
            var list = statuses.ToPagedList(searchParam.page, searchParam.limt >= 100 ? 100 : searchParam.limt);

            return new Pagenate<Status>()
            {
                Data = list,
                MetaData = list.GetMetaData()
            };
        }
        [HttpPost("Create")]
        [Authorize]
        public async Task<ActionResult> Create([FromBody] Status postedStatus, [FromQuery] ItemSearchParam searchParams)
        {

            if (ModelState.IsValid)
            {
                postedStatus = await _statusService.CreateAsync(postedStatus);
            }
            else
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Search", searchParams);
        }

        [HttpPost("Save")]
        [Authorize]
        public async Task<ActionResult> Save([FromBody] Status postedStatus)
        {
            if (ModelState.IsValid)
            {
                postedStatus = await _statusService.SaveAsync(postedStatus);
            }
            else
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpDelete("")]
        [Authorize]
        public async Task<ActionResult> Remove(Guid statusId)
        {
            var result = false;

            result = await _statusService.DeleteAsync(statusId);

            if (result == false)
                return NotFound();

            return Ok();
        }
    }
}