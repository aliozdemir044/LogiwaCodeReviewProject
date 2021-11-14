using Logiwa.Model.Category;

namespace Logiwa.Model.Product
{
    public class ProductListModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public CategoryListModel Category { get; set; }

        public int StockQuantity { get; set; }

        public bool IsActive { get; set; }

    }
}
