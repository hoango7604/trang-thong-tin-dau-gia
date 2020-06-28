using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Products;
using GWebsite.AbpZeroTemplate.Application.Share.Products.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Auctions;
using GWebsite.AbpZeroTemplate.Application.Share.Auctions.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Products
{
    public class ProductAppService : GWebsiteAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<Auction> auctionRepository;

        public ProductAppService(
            IRepository<Product> productRepository,
            IRepository<Auction> auctionRepository
        )
        {
            this.productRepository = productRepository;
            this.auctionRepository = auctionRepository;
        }

        #region public methods

        public void CreateOrEditProduct(ProductDto input)
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

        public void DeleteProduct(int id)
        {
            Delete(id);
        }

        public ProductDto GetProductForEdit(int id)
        {
            return Get(id);
        }

        public ProductDto GetProductForView(int id)
        {
            return Get(id);
        }

        public PagedResultDto<ProductDto> GetProducts(ProductFilter filter)
        {
            return GetList(filter);
        }

        public PagedResultDto<ProductDto> GetLatestProducts()
        {
            var filter = new ProductFilter
            {
                MaxResultCount = 12,
            };
            var query = productRepository.GetAll().Where(x => !x.IsDelete);
            var totalCount = query.Count();

            // sorting
            query = query.OrderByDescending(x => x.Id);

            // paging
            var items = query.PageBy(filter).ToList();

            // result
            return new PagedResultDto<ProductDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ProductDto>(item)).ToList()
            );
        }

        #endregion public methods

        #region private methods

        private void Create(ProductDto input)
        {
            var ProductEntity = ObjectMapper.Map<Product>(input);
            SetAuditInsert(ProductEntity);
            productRepository.Insert(ProductEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private void Edit(ProductDto input)
        {
            var ProductEntity = productRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (ProductEntity == null)
            {
            }
            ObjectMapper.Map(input, ProductEntity);
            SetAuditEdit(ProductEntity);
            productRepository.Update(ProductEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private ProductDto Get(int id)
        {
            var ProductEntity = productRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProductEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ProductDto>(ProductEntity);
        }

        private PagedResultDto<ProductDto> GetList(ProductFilter filter)
        {
            var query = productRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (filter.Name != null)
            {
                query = query.Where(x => x.Name.ToLower().Equals(filter.Name));
            }
            if (filter.CategoryId > 0)
            {
                query = query.Where(x => x.CategoryId == filter.CategoryId);
            }
            if (filter.PrimaryPriceFrom > 0)
            {
                query = query.Where(x => x.PrimaryPrice >= filter.PrimaryPriceFrom);
            }
            if (filter.PrimaryPriceTo > 0)
            {
                query = query.Where(x => x.PrimaryPrice <= filter.PrimaryPriceTo);
            }
            if (filter.WinnerClientId > 0)
            {
                query = query.Where(x => x.WinnerClientId == filter.WinnerClientId);
            }
            if (filter.ProductId != null)
            {
                query = query.Where(x => x.ProductId.ToLower().Equals(filter.ProductId));
            }
            if (filter.Brand!= null)
            {
                query = query.Where(x => x.Brand.ToLower().Equals(filter.Brand));
            }
            if (filter.AuctionId > 0)
            {
                query = query.Where(x => x.AuctionId == filter.AuctionId);
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
            return new PagedResultDto<ProductDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ProductDto>(item)).ToList()
            );
        }

        private void Delete(int id)
        {
            var ProductEntity = productRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (ProductEntity != null)
            {
                ProductEntity.IsDelete = true;
                productRepository.Update(ProductEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        #endregion private methods
    }
}
