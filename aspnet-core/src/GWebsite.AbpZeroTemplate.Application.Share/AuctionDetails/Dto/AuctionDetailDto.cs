using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.AuctionDetails.Dto
{
    public class AuctionDetailDto : Entity<int>
    {
        public int AuctionId { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int Price { get; set; }
    }
}
