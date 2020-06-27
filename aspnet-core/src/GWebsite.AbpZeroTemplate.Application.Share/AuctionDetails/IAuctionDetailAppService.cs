using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.AuctionDetails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.AuctionDetails
{
    public interface IAuctionDetailAppService
    {
        void CreateOrEditAuctionDetail(AuctionDetailDto input);
        AuctionDetailDto GetAuctionDetailForEdit(int id);
        void DeleteAuctionDetail(int id);
        PagedResultDto<AuctionDetailDto> GetAuctionDetails(AuctionDetailFilter filter);
        AuctionDetailDto GetAuctionDetailForView(int id);
    }
}
