using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Payments.Dto
{
    public class PaymentFilter : PagedAndSortedInputDto
    {
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
    }
}
