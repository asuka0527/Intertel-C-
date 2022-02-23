using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Intertel.Controllers
{
    [Route("MasterManage")]
    public class MasterManageController : Controller
    {
        private readonly ILogger<MasterManageController> _logger;
        public MasterManageController(ILogger<MasterManageController> logger)
        {
            _logger = logger;
        }

        // [Authorize(Roles = "Admin,SystemManager")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
