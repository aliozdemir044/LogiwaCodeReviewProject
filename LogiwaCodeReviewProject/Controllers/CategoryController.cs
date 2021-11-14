using Logiwa.Model.Category;
using Logiwa.Service.Shop.Category;
using Logiwa.Web.Extentions.Controller;
using Microsoft.AspNetCore.Mvc;

namespace Logiwa.API.Controllers
{
    [Route("api/category")]
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Tüm kategorileri gösteren action.
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpGet]
        [Route("get_all_categories")]
        public IActionResult GetAllProducts()
        {
            var result = _categoryService.GetCategories();
            return new OkObjectResult(result);
        }

        /// <summary>
        /// kategori oluşturma  post action.
        /// </summary>
        /// <param name="model">DefinitionCreateModel</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [Route("create_category")]
        public IActionResult Create(CategoryCreateModel model)
        {

            var result = _categoryService.Create(model);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Kategori güncelleme get action.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>ActionResult</returns>
        /// 
        [HttpGet]
        [Route("get_pcategory_by_id")]
        public IActionResult GetCategoryById(int id)
        {

            var result = _categoryService.GetCategoryById(id);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// Kategori güncelleme ekranı post action.
        /// </summary>
        /// <param name="model">DefinitionUpdateModel</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [Route("update_category")]
        public IActionResult Update(CategoryUpdateModel model)
        {
            var result = _categoryService.Update(model);

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Kategori silme action.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>ActionResult</returns>
        /// 
        [HttpPost]
        [Route("delete_kategori")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            return new OkObjectResult(result);
        }

    }
}
