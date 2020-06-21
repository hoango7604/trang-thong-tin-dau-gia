using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Auctions.Dto
{
    public class AuctionFilter : PagedAndSortedInputDto
    {
        public DateTime StartDateFrom { get; set; }
        public DateTime StartDateTo { get; set; }
        public DateTime EndDateFrom { get; set; }
        public DateTime EndDateTo { get; set; }
    }
}
