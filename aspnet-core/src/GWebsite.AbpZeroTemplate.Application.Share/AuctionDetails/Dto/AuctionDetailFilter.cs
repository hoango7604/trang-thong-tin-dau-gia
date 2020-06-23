using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.AuctionDetails.Dto
{
    public class AuctionDetailFilter : PagedAndSortedInputDto
    {
        public int AuctionId { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
    }
}
