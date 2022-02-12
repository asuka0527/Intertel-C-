using System.Collections.Generic;
using System.Threading.Tasks;
using Intertel.Entities;
using System.Linq;
using System;

namespace Intertel.Service
{
  public interface IItemService
  {
    /// <summary>
    /// DBから全部のItemを取得する
    /// </summary>
    /// <returns>Item[] </returns>
    Task<IQueryable<Item>> All();
    /// <summary>
    /// 新規Itemを追加する
    /// </summary>
    /// <param name="shop">Shop Entity<</param>
    /// <param name="userId">Itemを追加したユーザーのId</param>
    /// <returns>新規Item</returns>
    Task<Item> CreateAsync(Item item, string userId);

    Task<Item> SaveAsync(Item item);

    Task<Item> GetById(Guid id);
  }
}