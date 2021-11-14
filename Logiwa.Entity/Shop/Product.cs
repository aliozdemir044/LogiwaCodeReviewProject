using Logiwa.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Logiwa.Entity.Shop
{
    public class Product : AuditableEntity
    {
        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public Category Category { get; set; }

        public int StockQuantity { get; set; }
    }
}
