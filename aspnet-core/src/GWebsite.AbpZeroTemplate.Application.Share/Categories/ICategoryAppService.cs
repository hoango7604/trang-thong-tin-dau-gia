﻿using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Categories
{
    public interface ICategoryAppService
    {
        void CreateOrEditCategory(CategoryDto input);
        CategoryDto GetCategoryForEdit(int id);
        void DeleteCategory(int id);
        PagedResultDto<CategoryDto> GetCategories(CategoryFilter filter);
        CategoryDto GetCategoryForView(int id);
    }
}
