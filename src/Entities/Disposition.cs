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
  public class Disposition
  {
    [Key]
    public int Id { get; set; }
    public int DispositionNo { get; set; }
    public DateTime? ShippedAt { get; set; } = null;
    public string ShippedFrom { get; set; }
    public string Note { get; set; }
    public IdentityUser User { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    public Item Item { get; set; }


  }
}