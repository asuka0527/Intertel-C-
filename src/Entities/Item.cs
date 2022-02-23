using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Intertel.Entities
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string AgentId { get; set; }
        public string Model { get; set; }
        public string SerialNo { get; set; }
        public string MacNo1 { get; set; }
        public string MacNo2 { get; set; }
        public string BoxNo { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string Symptom { get; set; }
        public string Purpose { get; set; }
        public string Note { get; set; }
        public DateTime? InvoiceAt { get; set; } = null;
        public DateTime? SoldAt { get; set; } = null;
        public DateTime? ShippedAt { get; set; } = null;
        public DateTime? ReturnedAt { get; set; } = null;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public Status Status { get; set; }
        public virtual ICollection<Disposition> Dispositions { get; set; }
        public Customer Customer { get; set; }

    }
}