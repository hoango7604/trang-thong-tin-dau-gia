using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Auctions.Dto
{
    public class AuctionDto : Entity<int>
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
