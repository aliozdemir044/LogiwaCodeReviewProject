using Logiwa.Model.Product;
using Logiwa.Service.Shop.Product;
using Logiwa.Web.Extentions.Controller;
using Microsoft.AspNetCore.Mvc;

namespace Logiwa.API.Controllers
{
   
    [Route("api/product")]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Tüm ürünler, gösteren action.
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpGet]
        [Route("get_all_products")]
        public IActionResult GetAllProducts()
        {
            var result = _productService.GetProducts();
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Ürün oluşturma  post action.
        /// </summary>
        /// <param name="model">DefinitionCreateModel</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [Route("create_product")]
        public IActionResult Create(ProductCreateModel model)
        {

            var result = _productService.Create(model);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Ürün güncelleme get action.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>ActionResult</returns>
        /// 
        [HttpGet]
        [Route("get_product_by_id")]
        public IActionResult GetProductById(int id)
        {

            var result = _productService.GetProductById(id);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Ürün güncelleme ekranı post action.
        /// </summary>
        /// <param name="model">DefinitionUpdateModel</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [Route("update_product")]
        public IActionResult Update(ProductUpdateModel model)
        {
            var result = _productService.Update(model);

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Ürün arama post action.
        /// </summary>
        /// <param name="model">DefinitionUpdateModel</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [Route("search_product")]
        public IActionResult SearchProduct(string searchText)
        {
            var result = _productService.SearchProduct(searchText);

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Stok sayısına göre arama post action.
        /// </summary>
        /// <param name="model">DefinitionUpdateModel</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [Route("search_product_by_stock_quantity_range")]
        public IActionResult SearchProductByStockQuantityRange(int minValue, int maxValue)
        {
            var result = _productService.SearchProductByStockQuantityRange(minValue, maxValue);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Ürün silme action.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>ActionResult</returns>
        /// 
        [HttpPost]
        [Route("delete_product")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);
            return new OkObjectResult(result);
        }

    }
}
