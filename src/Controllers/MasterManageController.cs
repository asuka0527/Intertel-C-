using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Intertel.Data;
using Intertel.Entities;
using Intertel.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

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
