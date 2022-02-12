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


namespace Intertel.Controllers
{
  [Route("shops")]
  public class ShopController : Controller
  {
    private readonly ILogger<ShopController> _logger;

    public ShopController(ILogger<ShopController> logger)
    {
      _logger = logger;
    }


    [HttpGet()]
    [Authorize]
    public IActionResult Index()
    {
      return View();
    }

    [HttpGet("{shop_code}")]
    [Authorize]
    public IActionResult Shop(string shop_code)
    {
      ViewData["shop_code"] = shop_code;
      return View();
    }
  }
}
