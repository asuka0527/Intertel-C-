using System;
using System.ComponentModel.DataAnnotations;

namespace Intertel.Entities
{
    public class Agent
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public int? ContactNo { get; set; }
        public string? Address { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;
    }
}