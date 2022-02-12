using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using Newtonsoft.Json;

namespace Intertel.Entities
{
  public class Status
  {
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int SortNo { get; set; }
    public virtual ICollection<Item> Items { get; set; }
  }
}