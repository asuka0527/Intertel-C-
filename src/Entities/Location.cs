using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intertel.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public bool IsEditable { get; set; } = false;
    }
}