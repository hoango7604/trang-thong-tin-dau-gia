using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Products;
using GWebsite.AbpZeroTemplate.Application.Share.Products.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductController
    {
        private readonly IProductAppService productAppService;

        public ProductController(IProductAppService productAppService)
        {
            this.productAppService = productAppService;
        }

        [HttpGet]
        public PagedResultDto<ProductDto> GetProductsByFilter(ProductFilter filter)
        {
            return productAppService.GetProducts(filter);
        }

        [HttpGet]
        public ProductDto GetProductForEdit(int id)
        {
            return productAppService.GetProductForEdit(id);
        }

        [HttpGet]
        public ProductDto GetProductForView(int id)
        {
            return productAppService.GetProductForView(id);
        }

        [HttpPost]
        public void CreateOrEditProduct([FromBody] ProductDto input)
        {
            productAppService.CreateOrEditProduct(input);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            productAppService.DeleteProduct(id);
        }
    }
}
