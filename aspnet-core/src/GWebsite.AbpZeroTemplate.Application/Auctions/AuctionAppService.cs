using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Auctions;
using GWebsite.AbpZeroTemplate.Application.Share.Auctions.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Auctions
{
    public class AuctionAppService : GWebsiteAppServiceBase, IAuctionAppService
    {
        private readonly IRepository<Auction> auctionRepository;

        public AuctionAppService(IRepository<Auction> auctionRepository)
        {
            this.auctionRepository = auctionRepository;
        }

        #region public methods

        public void CreateOrEditAuction(AuctionDto input)
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

        public void DeleteAuction(int id)
        {
            Delete(id);
        }

        public AuctionDto GetAuctionForEdit(int id)
        {
            return Get(id);
        }

        public AuctionDto GetAuctionForView(int id)
        {
            return Get(id);
        }

        public PagedResultDto<AuctionDto> GetAuctions(AuctionFilter filter)
        {
            return GetList(filter);
        }

        public AuctionDto GetCurrentAuction()
        {
            var AuctionEntity = auctionRepository.GetAll().Where(x => !x.IsDelete).Last();
            return ObjectMapper.Map<AuctionDto>(AuctionEntity);
        }

        #endregion public method

        #region private methods

        private void Create(AuctionDto input)
        {
            var auctionEntity = ObjectMapper.Map<Auction>(input);
            SetAuditInsert(auctionEntity);
            auctionRepository.Insert(auctionEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private void Edit(AuctionDto input)
        {
            var auctionEntity = auctionRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (auctionEntity == null)
            {
            }
            ObjectMapper.Map(input, auctionEntity);
            SetAuditEdit(auctionEntity);
            auctionRepository.Update(auctionEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private AuctionDto Get(int id)
        {
            var AuctionEntity = auctionRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (AuctionEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<AuctionDto>(AuctionEntity);
        }

        private PagedResultDto<AuctionDto> GetList(AuctionFilter filter)
        {
            var query = auctionRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (filter.StartDateFrom != null)
            {
                query = query.Where(x => x.StartDate.CompareTo(filter.StartDateFrom) != -1);
            }
            if (filter.StartDateTo != null)
            {
                query = query.Where(x => x.StartDate.CompareTo(filter.StartDateTo) != 1);
            }
            if (filter.EndDateFrom != null)
            {
                query = query.Where(x => x.EndDate.CompareTo(filter.EndDateFrom) != -1);
            }
            if (filter.EndDateTo != null)
            {
                query = query.Where(x => x.EndDate.CompareTo(filter.EndDateTo) != 1);
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
            return new PagedResultDto<AuctionDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<AuctionDto>(item)).ToList()
            );
        }

        private void Delete(int id)
        {
            var AuctionEntity = auctionRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (AuctionEntity != null)
            {
                AuctionEntity.IsDelete = true;
                auctionRepository.Update(AuctionEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        #endregion private methods
    }
}
