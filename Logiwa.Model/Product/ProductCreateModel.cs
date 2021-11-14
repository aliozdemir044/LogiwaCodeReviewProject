using System;
using System.ComponentModel.DataAnnotations;

namespace Logiwa.Model.Product
{
    /// <summary>
    /// Ürün oluşturmak için kullanılır.
    /// Author : Ali Özdemir
    /// </summary>
    public class ProductCreateModel
    {
        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        [Range(5, 1000)]
        public int StockQuantity { get; set; }

        public bool IsActive { get; set; }
    }
}
