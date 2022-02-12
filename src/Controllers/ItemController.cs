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
  [Route("Item")]
  public class ItemController : Controller
  {
    private readonly ILogger<ItemController> _logger;

    private readonly IItemService _itemService;

    public ItemController(ILogger<ItemController> logger, IItemService itemService)
    {
      _logger = logger;
      _itemService = itemService;
    }


    [HttpGet("")]
    [Authorize]
    public async Task<IActionResult> Index()
    {
      return View();
    }



    [HttpGet("{item_code}")]
    [Authorize]
    public IActionResult Item(string item_code)
    {
      ViewData["Item_code"] = item_code;
      return View();
    }

    [HttpGet("Detail")]
    [Authorize]
    public async Task<IActionResult> Detail(Guid id)
    {

      // var item = await _itemService.GetById(id);

      return View("Detail");
      // return RedirectToAction("Index", item);
      // return Ok(JsonConvert.SerializeObject(item));
    }
  }



  [ApiController]
  [Route("ItemApi")]
  public class ItemApiController : Controller
  {
    private readonly ILogger<ItemApiController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IItemService _itemService;
    public IHttpContextAccessor _httpContextAccessor;

    public ItemApiController(ILogger<ItemApiController> logger,
                               UserManager<IdentityUser> userManager,
                               IItemService itemService, IHttpContextAccessor httpContextAccessor)
    {
      _logger = logger;
      _userManager = userManager;
      _itemService = itemService;
      _httpContextAccessor = httpContextAccessor;
    }


    [HttpGet("Search")]
    public async Task<Pagenate<Item>> Search([FromQuery] ItemSearchParam searchParam)
    {
      var items = await _itemService.All();
      if (!string.IsNullOrWhiteSpace(searchParam.model))
        items = items.Where(o => o.Model.IndexOf(searchParam.model) > -1);
      searchParam.limt = 5;
      var list = items.ToPagedList(searchParam.page, searchParam.limt >= 100 ? 100 : searchParam.limt);

      return new Pagenate<Item>()
      {
        Data = list,
        MetaData = list.GetMetaData()
      };
    }
    [HttpPost("Create")]
    [Authorize]
    public async Task<ActionResult> Create([FromBody] Item postedItem, [FromQuery] ItemSearchParam searchParams)
    {
      //  var json = JsonConvert.SerializeObject(item);
      // var item = new Item();
      var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

      if (ModelState.IsValid)
      {
        postedItem = await _itemService.CreateAsync(postedItem, userId);
      }
      else
      {
        return RedirectToAction("Index");
      }

      return RedirectToAction("Search", searchParams);
    }




    // [HttpGet("Detail")]
    // [Authorize]
    // public async Task<IActionResult> Detail(Guid id)
    // {

    //   var item = await _itemService.GetById(id);

    //   return View(item);
    //   // return RedirectToAction("Index", item);
    //   // return Ok(JsonConvert.SerializeObject(item));
    // }
    public class ItemDetailViewModel
    {
      public Item Item { get; set; }
    }
    [HttpGet("Find")]
    [Authorize]
    public async Task<ActionResult<ItemDetailViewModel>> Find(Guid id)
    {
      var item = await _itemService.GetById(id);

      return new ItemDetailViewModel()
      {
        // User = appUser,
        Item = item,
      };
    }

    [HttpPost("Save")]
    [Authorize]
    public async Task<ActionResult> Save([FromBody] Item postedItem)
    {
      //  var json = JsonConvert.SerializeObject(item);
      // var item = new Item();
      var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

      if (ModelState.IsValid)
      {
        postedItem = await _itemService.SaveAsync(postedItem);
      }
      else
      {
        return RedirectToAction("Index");
      }

      return RedirectToAction("Index");
    }
  }
}