using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Products
{
    public interface IProductAppService
    {
        void CreateOrEditProduct(ProductDto input);
        ProductDto GetProductForEdit(int id);
        void DeleteProduct(int id);
        PagedResultDto<ProductDto> GetProducts(ProductFilter filter);
        ProductDto GetProductForView(int id);
    }
}
