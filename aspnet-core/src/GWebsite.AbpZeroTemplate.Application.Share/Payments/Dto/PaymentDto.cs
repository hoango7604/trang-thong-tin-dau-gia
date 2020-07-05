using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Payments.Dto
{
    public class PaymentDto : Entity<int>
    {
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
        public string Address { get; set; }
    }
}
