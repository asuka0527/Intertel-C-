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
    public class ItemStatus
    {
        [Key]
        public Guid StatusId { get; set; }
        public Status Status { get; set; }
        [Key]
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
    }
}