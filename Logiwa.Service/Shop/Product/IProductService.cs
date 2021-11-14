using Logiwa.Core.Types;
using Logiwa.Model.Product;
using System.Collections.Generic;

namespace Logiwa.Service.Shop.Product
{

    /// <summary>
    /// Ürün işlemleri yapılır
    /// Author : Ali Özdemir
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Silinmemiş bütün ürünleri geririr.
        /// </summary>
        /// <returns></returns>
        Result<List<ProductListModel>> GetProducts();
        /// <summary>
        /// Ürün ekleme işlemi. 
        /// </summary>
        /// <param name="model">ProductCreateModel</param>
        /// <returns>Result</returns>
        Result Create(ProductCreateModel model);

        /// <summary>
        /// Ürün güncelleme işlemi. 
        /// </summary>
        /// <param name="model">ProductUpdateModel</param>
        /// <returns>Result</returns>
        Result Update(ProductUpdateModel model);

        /// <summary>
        /// Ürün silme işlemi. 
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Result</returns>
        Result Delete(int id);

        /// <summary>
        /// Ürün getirme işlemi.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Result</returns>
        Result<ProductUpdateModel> GetProductById(int id);

        /// <summary>
        /// Başlık ile ürün getirme işlemi.
        /// </summary>
        /// <param name="name">string</param>
        /// <returns>Result</returns>
        Result<ProductUpdateModel> GetProductByTitle(string title);

        /// <summary>
        /// Ürün arama işlemi.
        /// </summary>
        /// <param name="name">string</param>
        /// <returns>Result</returns>
        Result<List<ProductListModel>> SearchProduct(string searchText);

        /// <summary>
        /// Stok sayısı aralığında arama işlemi.
        /// </summary>
        /// <param name="name">string</param>
        /// <returns>Result</returns>
        Result<List<ProductListModel>> SearchProductByStockQuantityRange(int minValue, int maxValue);
    }
}
