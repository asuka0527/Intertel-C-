using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Intertel.Service;
using Intertel.Models;
using Intertel.Entities;
using X.PagedList;

namespace Intertel.Controllers
{
    [Route("Vendor")]
    public class VendorController : Controller
    {
        private readonly ILogger<VendorController> _logger;

        public VendorController(
            ILogger<VendorController> logger)
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

    [Route("Api/Vendor")]
    public class VendorApiController : Controller
    {
        private readonly ILogger<VendorApiController> _logger;
        private readonly IVendorService _vendorService;

        public VendorApiController(
            ILogger<VendorApiController> logger,
            IVendorService vendorService)
        {
            _logger = logger;
            _vendorService = vendorService;
        }

        [HttpGet("Find")]
        public async Task<ActionResult<Vendor>> Find(int id)
        {
            var vendor = await _vendorService.FindAsync(id);

            if (vendor == null)
                return NotFound();

            return vendor;
        }


        [HttpGet("Search")]
        public async Task<Pagenate<Vendor>> Search([FromQuery] MasterSearchParam searchParam)
        {
            var vendorList = await _vendorService.GetVendorListAsync(searchParam);

            var list = vendorList.ToPagedList(searchParam.page, searchParam.limt >= 100 ? 100 : searchParam.limt);

            return new Pagenate<Vendor>()
            {
                Data = list,
                MetaData = list.GetMetaData()
            };
        }

        [HttpPost("Save")]
        // [Authorize]
        public async Task<ActionResult<Vendor>> Save([FromBody] Vendor postedVendor)
        {
            if (ModelState.IsValid)
            {
                postedVendor = await _vendorService.SaveAsync(postedVendor);
            }
            else
            {
                return BadRequest();
            }

            return postedVendor;
        }

        [HttpDelete("")]
        // [Authorize]
        public async Task<ActionResult> Remove(int id)
        {
            var result = false;

            result = await _vendorService.DeleteAsync(id);

            if (result == false)
                return NotFound();

            return Ok();
        }
    }
}