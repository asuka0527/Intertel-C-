using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Intertel.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Intertel.Models;
using Intertel.Entities;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Newtonsoft.Json;

namespace Intertel.Service
{

  public class ItemService : IItemService
  {

    private AppDbContext _dbContext = null;
    private ILogger<ItemService> _logger = null;
    public IHttpContextAccessor _httpContextAccessor;
    private UserManager<IdentityUser> _userManager;

    public ItemService(AppDbContext dbContext, ILogger<ItemService> logger, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
    {
      _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));

      _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));

      _userManager = userManager ?? throw new System.ArgumentNullException(nameof(userManager));
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IQueryable<Item>> All()
    {
      var items = _dbContext.Item.AsNoTracking().Where(i => i.Model != null);
      return items;
    }

    public async Task<Item> CreateAsync(Item item, string userId)
    {
      item.UserId = userId;
      item.Id = new Guid();

      await _dbContext.Item.AddAsync(item);
      await _dbContext.SaveChangesAsync();
      return item;
      //   var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

      //      _dbContext.Item.Add(new Item(){
      //  Id = new Guid(),
      //   UserId = userId,
      //    Model = "model2",
      //     });
      //       _dbContext.SaveChanges();
    }

    public async Task<Item> GetById(Guid id)
    {
      var item = await _dbContext.Item.Include(d => d.Dispositions).FirstOrDefaultAsync(i => i.Id == id);
      return item;
    }

    public async Task<Item> SaveAsync(Item item)
    {

      item.UpdatedAt = DateTime.Now;

      var postedDispositionsBackup = JsonConvert.SerializeObject(item.Dispositions);
      item.Dispositions.Clear();
      // --------------------------------------------------------------------

      _dbContext.Entry(item).State = EntityState.Modified;

      await _dbContext.SaveChangesAsync();

      var dbFindDispositions = _dbContext.Disposition.Where(id => id.Item.Id == item.Id).ToList();

      _dbContext.RemoveRange(dbFindDispositions);

      foreach (var pd in JsonConvert.DeserializeObject<IList<Disposition>>(postedDispositionsBackup))

      {
        _dbContext.Disposition.Add(new Disposition()
        {
          Item = item,
          DispositionNo = pd.DispositionNo,
          ShippedAt = pd.ShippedAt,
          ShippedFrom = pd.ShippedFrom,
          Note = pd.Note
        });
      }
      await _dbContext.SaveChangesAsync();

      return item;

    }
  }
}