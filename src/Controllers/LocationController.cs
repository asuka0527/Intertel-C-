using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Intertel.Service;
using Intertel.Models;
using Intertel.Entities;
using X.PagedList;

namespace Intertel.Controllers
{
    [Route("Location")]
    public class LocationController : Controller
    {
        private readonly ILogger<LocationController> _logger;

        public LocationController(
            ILogger<LocationController> logger)
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

    [Route("Api/Location")]
    public class LocationApiController : Controller
    {
        private readonly ILogger<LocationApiController> _logger;
        private readonly ILocationService _locationService;

        public LocationApiController(
            ILogger<LocationApiController> logger,
            ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        [HttpGet("Find")]
        public async Task<ActionResult<Location>> Find(int id)
        {
            var location = await _locationService.FindAsync(id);

            if (location == null)
                return NotFound();

            return location;
        }


        [HttpGet("Search")]
        public async Task<Pagenate<Location>> Search([FromQuery] MasterSearchParam searchParam)
        {
            var locationList = await _locationService.GetLocationListAsync(searchParam);

            // if (!string.IsNullOrWhiteSpace(searchParam.name))
            //     locationList = locationList.Where(o => o.Name.IndexOf(searchParam.name) > -1);
            // searchParam.limt = 5;

            var list = locationList.ToPagedList(searchParam.page, searchParam.limt >= 100 ? 100 : searchParam.limt);

            return new Pagenate<Location>()
            {
                Data = list,
                MetaData = list.GetMetaData()
            };
        }

        [HttpPost("Save")]
        // [Authorize]
        public async Task<ActionResult<Location>> Save([FromBody] Location postedLocation)
        {
            if (ModelState.IsValid)
            {
                postedLocation = await _locationService.SaveAsync(postedLocation);
            }
            else
            {
                return BadRequest();
            }

            return postedLocation;
        }

        [HttpDelete("")]
        // [Authorize]
        public async Task<ActionResult> Remove(int id)
        {
            var result = false;

            result = await _locationService.DeleteAsync(id);

            if (result == false)
                return NotFound();

            return Ok();
        }
    }
}