using Logiwa.Core.Types;
using Logiwa.Model.Category;
using System.Collections.Generic;

namespace Logiwa.Service.Shop.Category
{
    /// <summary>
    /// Kategori işlemleri yapılır.
    /// Author : Ali Özdemir
    /// </summary>
    public interface ICategoryService
    {

        /// <summary>
        /// Silinmemiş bütün kategorileri geririr.
        /// </summary>
        /// <returns></returns>
        Result<List<CategoryListModel>> GetCategories();

        /// <summary>
        /// Kategori oluşturur.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Result Create(CategoryCreateModel model);

        /// <summary>
        /// Kategori güncelleme işlemi. 
        /// </summary>
        /// <param name="model">ProductUpdateModel</param>
        /// <returns>Result</returns>
        Result Update(CategoryUpdateModel model);

        /// <summary>
        /// Kategori silme işlemi. 
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Result</returns>
        Result Delete(int id);

        /// <summary>
        /// ID'ye göre kategori getirme işlemi.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Result</returns>
        Result<CategoryUpdateModel> GetCategoryById(int id);


    }
}
