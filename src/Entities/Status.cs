using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intertel.Entities
{
    public class Status
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        [NotMapped]
        public bool IsEditable { get; set; } = false;
    }
}