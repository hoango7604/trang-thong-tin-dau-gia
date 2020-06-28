using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Auctions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Auctions
{
    public interface IAuctionAppService
    {
        void CreateOrEditAuction(AuctionDto input);
        AuctionDto GetAuctionForEdit(int id);
        void DeleteAuction(int id);
        PagedResultDto<AuctionDto> GetAuctions(AuctionFilter filter);
        AuctionDto GetAuctionForView(int id);
        AuctionDto GetCurrentAuction();
    }
}
