using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Categories;
using GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoryController : GWebsiteControllerBase
    {
        private readonly ICategoryAppService CategoryAppService;

        public CategoryController(ICategoryAppService CategoryAppService)
        {
            this.CategoryAppService = CategoryAppService;
        }

        [HttpGet]
        public PagedResultDto<CategoryDto> GetCategorysByFilter(CategoryFilter filter)
        {
            return CategoryAppService.GetCategories(filter);
        }

        [HttpGet]
        public CategoryDto GetCategoryForEdit(int id)
        {
            return CategoryAppService.GetCategoryForEdit(id);
        }

        [HttpGet]
        public CategoryDto GetCategoryForView(int id)
        {
            return CategoryAppService.GetCategoryForView(id);
        }

        [HttpPost]
        public void CreateOrEditCategory([FromBody] CategoryDto input)
        {
            CategoryAppService.CreateOrEditCategory(input);
        }

        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            CategoryAppService.DeleteCategory(id);
        }
    }
}
