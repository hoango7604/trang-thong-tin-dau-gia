using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Products.Dto
{
    public class ProductFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int PrimaryPriceFrom { get; set; }
        public int PrimaryPriceTo { get; set; }
        public int WinnerClientId { get; set; }
        public string ProductId { get; set; }
        public string Brand { get; set; }
        public int AuctionId { get; set; }
        public bool IsPaid { get; set; }
    }
}
