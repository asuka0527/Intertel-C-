using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Intertel.Service;
using Intertel.Models;
using Intertel.Entities;
using X.PagedList;

namespace Intertel.Controllers
{
    [Route("Unit")]
    public class UnitController : Controller
    {
        private readonly ILogger<UnitController> _logger;

        public UnitController(
            ILogger<UnitController> logger)
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

    [Route("Api/Unit")]
    public class UnitApiController : Controller
    {
        private readonly ILogger<UnitApiController> _logger;
        private readonly IUnitService _unitService;

        public UnitApiController(
            ILogger<UnitApiController> logger,
            IUnitService unitService)
        {
            _logger = logger;
            _unitService = unitService;
        }

        [HttpGet("Find")]
        public async Task<ActionResult<Unit>> Find(int id)
        {
            var unit = await _unitService.FindAsync(id);

            if (unit == null)
                return NotFound();

            return unit;
        }


        [HttpGet("Search")]
        public async Task<Pagenate<Unit>> Search([FromQuery] MasterSearchParam searchParam)
        {
            var unitList = await _unitService.GetUnitListAsync(searchParam);

            var list = unitList.ToPagedList(searchParam.page, searchParam.limt >= 100 ? 100 : searchParam.limt);

            return new Pagenate<Unit>()
            {
                Data = list,
                MetaData = list.GetMetaData()
            };
        }

        [HttpPost("Save")]
        // [Authorize]
        public async Task<ActionResult<Unit>> Save([FromBody] Unit postedUnit)
        {
            if (ModelState.IsValid)
            {
                postedUnit = await _unitService.SaveAsync(postedUnit);
            }
            else
            {
                return BadRequest();
            }

            return postedUnit;
        }

        [HttpDelete("")]
        // [Authorize]
        public async Task<ActionResult> Remove(int id)
        {
            var result = false;

            result = await _unitService.DeleteAsync(id);

            if (result == false)
                return NotFound();

            return Ok();
        }
    }
}