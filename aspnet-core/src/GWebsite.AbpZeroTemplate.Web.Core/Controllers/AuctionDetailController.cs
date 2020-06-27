using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AuctionDetails;
using GWebsite.AbpZeroTemplate.Application.Share.AuctionDetails.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuctionDetailController : GWebsiteControllerBase
    {
        private readonly IAuctionDetailAppService auctionDetailAppService;

        public AuctionDetailController(IAuctionDetailAppService auctionDetailAppService)
        {
            this.auctionDetailAppService = auctionDetailAppService;
        }

        [HttpGet]
        public PagedResultDto<AuctionDetailDto> GetAuctionDetailsByFilter(AuctionDetailFilter filter)
        {
            return auctionDetailAppService.GetAuctionDetails(filter);
        }

        [HttpGet]
        public AuctionDetailDto GetAuctionDetailForEdit(int id)
        {
            return auctionDetailAppService.GetAuctionDetailForEdit(id);
        }

        [HttpGet]
        public AuctionDetailDto GetAuctionDetailForView(int id)
        {
            return auctionDetailAppService.GetAuctionDetailForView(id);
        }

        [HttpPost]
        public void CreateOrEditAuctionDetail([FromBody] AuctionDetailDto input)
        {
            auctionDetailAppService.CreateOrEditAuctionDetail(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAuctionDetail(int id)
        {
            auctionDetailAppService.DeleteAuctionDetail(id);
        }
    }
}
