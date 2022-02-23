using System;
using System.ComponentModel.DataAnnotations;

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