using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Auctions;
using GWebsite.AbpZeroTemplate.Application.Share.Auctions.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuctionController : GWebsiteControllerBase
    {
        private readonly IAuctionAppService auctionAppService;

        public AuctionController(IAuctionAppService auctionAppService)
        {
            this.auctionAppService = auctionAppService;
        }

        [HttpGet]
        public PagedResultDto<AuctionDto> GetAuctionsByFilter(AuctionFilter filter)
        {
            return auctionAppService.GetAuctions(filter);
        }

        [HttpGet]
        public AuctionDto GetAuctionForEdit(int id)
        {
            return auctionAppService.GetAuctionForEdit(id);
        }

        [HttpGet]
        public AuctionDto GetAuctionForView(int id)
        {
            return auctionAppService.GetAuctionForView(id);
        }

        [HttpGet]
        public AuctionDto GetCurrentAuction()
        {
            return auctionAppService.GetCurrentAuction();
        }

        [HttpPost]
        public void CreateOrEditAuction([FromBody] AuctionDto input)
        {
            auctionAppService.CreateOrEditAuction(input);
        }

        [HttpDelete("{id}")]
        public void DeleteAuction(int id)
        {
            auctionAppService.DeleteAuction(id);
        }
    }
}
