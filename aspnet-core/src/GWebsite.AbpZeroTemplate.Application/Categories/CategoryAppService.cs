using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Categories;
using GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Categories
{
    public class CategoryAppService : GWebsiteAppServiceBase, ICategoryAppService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryAppService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        #region public methods

        public void CreateOrEditCategory(CategoryDto input)
        {
            if (input.Id == 0)
            {
                Create(input);
            }
            else
            {
                Edit(input);
            }
        }

        public void DeleteCategory(int id)
        {
            Delete(id);
        }

        public CategoryDto GetCategoryForEdit(int id)
        {
            return Get(id);
        }

        public CategoryDto GetCategoryForView(int id)
        {
            return Get(id);
        }

        public PagedResultDto<CategoryDto> GetCategories(CategoryFilter filter)
        {
            return GetList(filter);
        }

        #endregion public methods

        #region private methods

        private void Create(CategoryDto input)
        {
            var CategoryEntity = ObjectMapper.Map<Category>(input);
            SetAuditInsert(CategoryEntity);
            categoryRepository.Insert(CategoryEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private void Edit(CategoryDto input)
        {
            var CategoryEntity = categoryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (CategoryEntity == null)
            {
            }
            ObjectMapper.Map(input, CategoryEntity);
            SetAuditEdit(CategoryEntity);
            categoryRepository.Update(CategoryEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private CategoryDto Get(int id)
        {
            var CategoryEntity = categoryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (CategoryEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<CategoryDto>(CategoryEntity);
        }

        private PagedResultDto<CategoryDto> GetList(CategoryFilter filter)
        {
            var query = categoryRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (filter.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Equals(filter.Name));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(filter.Sorting))
            {
                query = query.OrderBy(filter.Sorting);
            }

            // paging
            var items = query.PageBy(filter).ToList();

            // result
            return new PagedResultDto<CategoryDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<CategoryDto>(item)).ToList()
            );
        }

        private void Delete(int id)
        {
            var CategoryEntity = categoryRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (CategoryEntity != null)
            {
                CategoryEntity.IsDelete = true;
                categoryRepository.Update(CategoryEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        #endregion private methods
    }
}
