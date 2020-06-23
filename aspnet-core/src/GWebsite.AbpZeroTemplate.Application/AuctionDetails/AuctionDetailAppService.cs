using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.AuctionDetails;
using GWebsite.AbpZeroTemplate.Application.Share.AuctionDetails.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.AuctionDetails
{
    public class AuctionDetailAppService : GWebsiteAppServiceBase, IAuctionDetailAppService
    {
        private readonly IRepository<AuctionDetail> auctionDetailRepository;

        public AuctionDetailAppService(IRepository<AuctionDetail> auctionDetailRepository)
        {
            this.auctionDetailRepository = auctionDetailRepository;
        }

        #region public methods

        public void CreateOrEditAuctionDetail(AuctionDetailDto input)
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

        public void DeleteAuctionDetail(int id)
        {
            Delete(id);
        }

        public AuctionDetailDto GetAuctionDetailForEdit(int id)
        {
            return Get(id);
        }

        public AuctionDetailDto GetAuctionDetailForView(int id)
        {
            return Get(id);
        }

        public PagedResultDto<AuctionDetailDto> GetAuctionDetails(AuctionDetailFilter filter)
        {
            return GetList(filter);
        }

        #endregion public methods

        #region private methods

        private void Create(AuctionDetailDto input)
        {
            var AuctionDetailEntity = ObjectMapper.Map<AuctionDetail>(input);
            SetAuditInsert(AuctionDetailEntity);
            auctionDetailRepository.Insert(AuctionDetailEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private void Edit(AuctionDetailDto input)
        {
            var AuctionDetailEntity = auctionDetailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (AuctionDetailEntity == null)
            {
            }
            ObjectMapper.Map(input, AuctionDetailEntity);
            SetAuditEdit(AuctionDetailEntity);
            auctionDetailRepository.Update(AuctionDetailEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private AuctionDetailDto Get(int id)
        {
            var AuctionDetailEntity = auctionDetailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (AuctionDetailEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AuctionDetailDto>(AuctionDetailEntity);
        }

        private PagedResultDto<AuctionDetailDto> GetList(AuctionDetailFilter filter)
        {
            var query = auctionDetailRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (filter.AuctionId > 0)
            {
                query = query.Where(x => x.AuctionId == filter.AuctionId);
            }
            if (filter.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == filter.ProductId);
            }
            if (filter.ClientId > 0)
            {
                query = query.Where(x => x.ClientId == filter.ClientId);
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
            return new PagedResultDto<AuctionDetailDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AuctionDetailDto>(item)).ToList()
            );
        }

        private void Delete(int id)
        {
            var AuctionDetailEntity = auctionDetailRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (AuctionDetailEntity != null)
            {
                AuctionDetailEntity.IsDelete = true;
                auctionDetailRepository.Update(AuctionDetailEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        #endregion private methods
    }
}
