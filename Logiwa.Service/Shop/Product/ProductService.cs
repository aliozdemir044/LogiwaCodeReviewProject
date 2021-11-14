using Logiwa.Core.Interfaces;
using Logiwa.Core.Types;
using Logiwa.Model.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logiwa.Service.Shop.Product
{
    /// <summary>
    /// Ürün işlemleri yapılır
    /// Author : Ali Özdemir
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IRepository<Entity.Shop.Product> _productRepository;
        private readonly IRepository<Entity.Shop.Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogManager _logManager;
        public ProductService(IRepository<Entity.Shop.Product> productRepository,
            IUnitOfWork unitOfWork, ILogManager logManager, IRepository<Entity.Shop.Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _logManager = logManager;
        }

        /// <summary>
        /// Silinmemiş bütün ürünleri geririr.
        /// </summary>
        /// <returns></returns>
        public Result<List<ProductListModel>> GetProducts()
        {
            var result = new Result<List<ProductListModel>>();
            try
            {
                var query = _productRepository.GetQueryable().Where(p => !p.IsDeleted);
                var products = query.Select(product => new ProductListModel()
                {
                    Id = product.Id,
                    Category = new Model.Category.CategoryListModel
                    {
                        Id = product.Category.Id,
                        Name = product.Category.Name,
                        Description = product.Category.Description
                    },
                    Description = product.Description,
                    Title = product.Title,
                    StockQuantity = product.StockQuantity,
                    IsActive = product.IsActive
                }).ToList();

                result.Data = products;
                result.Message = "Ürünler başarıyla getirildi.";
                result.Success = true;
                _logManager.Info(result.Message);
            }
            catch (Exception exception)
            {
                result.Message = $"Ürünler getirilirken hata alındı. hata -> {exception.Message}";
                result.Success = false;
                _logManager.Error(exception.Message, exception);
            }
            return result;
        }

        /// <summary>
        /// Ürün ekleme işlemi. 
        /// </summary>
        /// <param name="model">ProductCreateModel</param>
        /// <returns>Result</returns>
        public Result Create(ProductCreateModel model)
        {
            var result = new Result();
            try
            {
                var isExistCategory = IsExistCategory(model.CategoryId);

                if (isExistCategory)
                {
                    var entity = new Entity.Shop.Product
                    {
                        Title = model.Title,
                        Description = model.Description,
                        StockQuantity = model.StockQuantity,
                        Category = _categoryRepository.Get(model.CategoryId),
                        IsActive = model.IsActive,
                        InsertedUser = "UnAuthorize",
                        InsertedUserId = 0,
                        InsertedDate = DateTime.Now
                    };

                    _productRepository.Insert(entity);
                    _unitOfWork.Commit();
                    result.Success = true;
                    result.Message = "Ürün  başarıyla eklendi";
                    _logManager.Info(result.Message);

                }
                else
                {
                    result.Success = false;
                    result.Message = "Ürünün geçerli bir kategorisi olmalıdır. ";
                    _logManager.Warning(result.Message);

                }
            }
            catch (Exception exception)
            {
                result.Success = false;
                result.Message = exception.Message;
                _logManager.Error("Ürün eklenirken bir hata alındı.", exception);
            }
            return result;
        }

        /// <summary>
        /// Ürün güncelleme işlemi. 
        /// </summary>
        /// <param name="model">ProductUpdateModel</param>
        /// <returns>Result</returns>
        public Result Update(ProductUpdateModel model)
        {
            var result = new Result();

            try
            {
                var query = _productRepository.GetQueryable()
                    .Where(p => p.IsDeleted.Equals(false) && p.Id == model.Id);

                var product = query.FirstOrDefault();

                if (product != null)
                {
                    var isExistCategory = IsExistCategory(model.CategoryId);

                    if (isExistCategory)
                    {
                        product.Title = model.Title;
                        product.IsActive = product.IsActive;
                        product.StockQuantity = model.StockQuantity;
                        product.Description = model.Description;
                        product.Category = _categoryRepository.Get(model.CategoryId);
                        product.UpdatedUser = "UnAuthorize";
                        product.UpdatedUserId = 0;
                        product.UpdatedDate = DateTime.Now;
                        _productRepository.Update(product);
                        _unitOfWork.Commit();
                        result.Success = true;
                        result.Message = "Ürün başarıyla güncellendi.";
                        _logManager.Info(result.Message);

                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Ürünün geçerli bir kategorisi olmalıdır. ";
                        _logManager.Warning(result.Message);

                    }
                }
                else
                {
                    result.Success = false;
                    result.Message = "Güncellenecek ürün bulunamadı.";
                    _logManager.Warning(result.Message);


                }
            }
            catch (Exception exception)
            {
                result.Success = false;
                result.Message = exception.Message;
                _logManager.Error("Ürün güncellenirken bir hata alındı.", exception);
            }
            return result;
        }

        /// <summary>
        /// Ürün silme işlemi. 
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Result</returns>
        public Result Delete(int id)
        {
            var result = new Result();
            try
            {
                var query = _productRepository.GetQueryable()
                    .Where(p => p.IsDeleted.Equals(false) && p.Id == id);


                var definition = query.FirstOrDefault();

                if (definition != null)
                {
                    definition.IsActive = false;
                    definition.IsDeleted = true;

                    _productRepository.Update(definition);
                    _unitOfWork.Commit();
                    result.Success = true;
                    result.Message = "Ürün başarıyla silindi.";
                    _logManager.Info(result.Message);

                }
                else
                {
                    result.Success = false;
                    result.Message = "Ürün silinemedi. ";
                    _logManager.Warning(result.Message);

                }
            }
            catch (Exception exception)
            {
                result.Success = false;
                result.Message = exception.Message;
                _logManager.Error("Ürün silinirken bir hata alındı.", exception);
            }
            return result;
        }

        /// <summary>
        /// Ürün getirme işlemi.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Result</returns>
        public Result<ProductUpdateModel> GetProductById(int id)
        {
            var result = new Result<ProductUpdateModel>();
            try
            {
                var productUpdateModel = new ProductUpdateModel();

                var query = _productRepository.GetQueryable().Include(p => p.Category)
                    .Where(p => p.IsDeleted.Equals(false) && p.Id == id);

                var product = query.FirstOrDefault();

                if (product != null)
                {
                    productUpdateModel.Id = product.Id;
                    productUpdateModel.Title = product.Title;
                    productUpdateModel.Description = product.Description;
                    productUpdateModel.StockQuantity = product.StockQuantity;
                    productUpdateModel.IsActive = product.IsActive;
                    productUpdateModel.CategoryId = product.Category.Id;

                    result.Data = productUpdateModel;
                    result.Success = true;
                    result.Message = "Ürün başarıyla getirildi.";
                    _logManager.Info(result.Message);

                }
                else
                {
                    result.Success = false;
                    result.Message = "Görüntülenecek ürün bulunamadı.";
                    _logManager.Warning(result.Message);

                }
            }
            catch (Exception exception)
            {
                result.Success = false;
                result.Message = exception.Message;

                _logManager.Error("ürün bulunurken bir hata alındı.", exception);
            }

            return result;
        }



        /// <summary>
        /// İsim ile Tanım getirme işlemi.
        /// </summary>
        /// <param name="name">string</param>
        /// <returns>Result</returns>
        public Result<ProductUpdateModel> GetProductByTitle(string title)
        {
            var result = new Result<ProductUpdateModel>();
            try
            {
                var productUpdateModel = new ProductUpdateModel();

                var query = _productRepository.GetQueryable()
                    .Where(p => p.IsDeleted.Equals(false) && p.Title == title);

                var product = query.FirstOrDefault();

                if (product != null)
                {
                    productUpdateModel.Id = product.Id;
                    productUpdateModel.Title = product.Title;
                    productUpdateModel.Description = product.Description;
                    productUpdateModel.StockQuantity = product.StockQuantity;
                    productUpdateModel.IsActive = product.IsActive;
                    productUpdateModel.CategoryId = product.Category.Id;

                    result.Data = productUpdateModel;
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.Message = "Görüntülenecek ürün bulunamadı.";
                }
            }
            catch (Exception exception)
            {
                result.Success = false;
                result.Message = exception.Message;

                _logManager.Error("ürün bulunurken bir hata alındı.", exception);
            }

            return result;
        }
        public Result<List<ProductListModel>> SearchProduct(string searchText)
        {
            var result = new Result<List<ProductListModel>>();
            try
            {

                if (string.IsNullOrEmpty(searchText))
                {
                    result.Success = false;
                    result.Message = "Arama yapmak için bir değer girilmeli.";
                    return result;
                }
                var productList = _productRepository.GetQueryable()
                    .Where(p => p.IsDeleted.Equals(false) && p.Title.Contains(searchText) || p.Description.Contains(searchText) || p.Category.Name.Contains(searchText))
                    .Select(p => new ProductListModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Description = p.Description,
                        StockQuantity = p.StockQuantity,
                        Category = new Model.Category.CategoryListModel
                        {
                            Id = p.Category.Id,
                            Name = p.Category.Name,
                            Description = p.Category.Description
                        },
                        IsActive = p.IsActive
                    }).ToList();

                result.Data = productList;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Success = false;
                result.Message = $"Ürün bulunurken hata alındı. Hata -> {exception.Message}";

                _logManager.Error("ürün bulunurken bir hata alındı.", exception);
            }
            return result;
        }

        public Result<List<ProductListModel>> SearchProductByStockQuantityRange(int minValue, int maxValue)
        {
            var result = new Result<List<ProductListModel>>();
            try
            {


                var productList = _productRepository.GetQueryable()
                    .Where(p => p.IsDeleted.Equals(false) && p.StockQuantity > minValue && p.StockQuantity < maxValue)
                    .Select(p => new ProductListModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Description = p.Description,
                        StockQuantity = p.StockQuantity,
                        Category = new Model.Category.CategoryListModel
                        {
                            Id = p.Category.Id,
                            Name = p.Category.Name,
                            Description = p.Category.Description
                        },
                        IsActive = p.IsActive
                    }).ToList();

                result.Data = productList;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Success = false;
                result.Message = $"Ürün bulunurken hata alındı. Hata -> {exception.Message}";

                _logManager.Error("ürün bulunurken bir hata alındı.", exception);
            }
            return result;
        }

        private bool IsExistCategory(int categoryId)
        {
            return _categoryRepository.Get(categoryId) != null ? true : false;
        }


    }


}
