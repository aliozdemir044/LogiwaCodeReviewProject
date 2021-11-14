using Logiwa.Core.Interfaces;
using Logiwa.Core.Types;
using Logiwa.Model.Category;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logiwa.Service.Shop.Category
{
    /// <summary>
    /// Kategori işlemleri yapılır.
    /// Author : Ali Özdemir
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Entity.Shop.Category> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogManager _logManager;
        public CategoryService(IUnitOfWork unitOfWork,
            ILogManager logManager, IRepository<Entity.Shop.Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _logManager = logManager;
        }

        public Result Create(CategoryCreateModel model)
        {
            var result = new Result();
            try
            {
                var entity = new Entity.Shop.Category
                {
                    Name = model.Name,
                    Description = model.Description,
                    InsertedUser = "UnAuthorize",
                    InsertedUserId = 0,
                    InsertedDate = DateTime.Now
                };

                _categoryRepository.Insert(entity);
                _unitOfWork.Commit();
                result.Success = true;
                result.Message = "Kategori başarıyla eklendi";
                _logManager.Info(result.Message);


            }
            catch (Exception exception)
            {
                result.Success = false;
                result.Message = exception.Message;
                _logManager.Error("Kategori eklenirken bir hata alındı.", exception);
            }
            return result;
        }

        public Result Delete(int id)
        {
            var result = new Result();
            try
            {
                var query = _categoryRepository.GetQueryable()
                    .Where(p => p.IsDeleted.Equals(false) && p.Id == id);
                var category = query.FirstOrDefault();

                if (category != null)
                {
                    category.IsActive = false;
                    category.IsDeleted = true;
                    _categoryRepository.Update(category);
                    _unitOfWork.Commit();
                    result.Success = true;
                    result.Message = "Kategori başarıyla silindi.";
                    _logManager.Info(result.Message);


                }
                else
                {
                    result.Success = false;
                    result.Message = "Kategori silinemedi.";
                    _logManager.Warning(result.Message);


                }
            }
            catch (Exception exception)
            {
                result.Success = false;
                result.Message = exception.Message;
                _logManager.Error("Kategori silinirken bir hata alındı.", exception);
            }
            return result;
        }

        public Result<List<CategoryListModel>> GetCategories()
        {
            var result = new Result<List<CategoryListModel>>();
            try
            {
                var query = _categoryRepository.GetQueryable().Where(p => !p.IsDeleted);
                var products = query.Select(category => new CategoryListModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    IsActive = category.IsActive
                }).ToList();

                result.Data = products;
                result.Message = "Kategoriler başarıyla getirildi.";
                result.Success = true;
                _logManager.Info(result.Message);
            }
            catch (Exception exception)
            {
                result.Message = $"Kategoriler getirilirken hata alındı. hata -> {exception.Message}";
                result.Success = false;
                _logManager.Error(exception.Message, exception);
            }
            return result;
        }

        public Result<CategoryUpdateModel> GetCategoryById(int id)
        {
            var result = new Result<CategoryUpdateModel>();
            try
            {
                var categoryUpdateModel = new CategoryUpdateModel();

                var query = _categoryRepository.GetQueryable()
                    .Where(p => p.IsDeleted.Equals(false) && p.Id == id);

                var category = query.FirstOrDefault();

                if (category != null)
                {
                    categoryUpdateModel.Id = category.Id;
                    categoryUpdateModel.Name = category.Name;
                    categoryUpdateModel.Description = category.Description;
                    categoryUpdateModel.IsActive = category.IsActive;
                    result.Data = categoryUpdateModel;
                    result.Success = true;
                    result.Message = "Kategori getirildi.";
                    _logManager.Info(result.Message);

                }
                else
                {
                    result.Success = false;
                    result.Message = "Görüntülenecek kategori bulunamadı.";
                    _logManager.Warning(result.Message);

                }
            }
            catch (Exception exception)
            {
                result.Success = false;
                result.Message = exception.Message;

                _logManager.Error("kategori bulunurken bir hata alındı.", exception);
            }

            return result;
        }

        public Result Update(CategoryUpdateModel model)
        {
            var result = new Result();

            try
            {
                var query = _categoryRepository.GetQueryable()
                    .Where(p => p.IsDeleted.Equals(false) && p.Id == model.Id);

                var category = query.FirstOrDefault();

                if (category != null)
                {
                    category.Name = model.Name;
                    category.IsActive = model.IsActive;
                    category.Description = model.Description;
                    category.UpdatedUser = "UnAuthorize";
                    category.UpdatedUserId = 0;
                    category.UpdatedDate = DateTime.Now;
                    _categoryRepository.Update(category);
                    _unitOfWork.Commit();
                    result.Success = true;
                    result.Message = "Kategori başarıyla güncellendi.";
                    _logManager.Info(result.Message);

                }
                else
                {
                    result.Success = false;
                    result.Message = "Kategori bulunamadı.";

                }
            }
            catch (Exception exception)
            {
                result.Success = false;
                result.Message = exception.Message;
                _logManager.Error("Kategori güncellenirken bir hata alındı.", exception);
            }
            return result;
        }
    }
}
