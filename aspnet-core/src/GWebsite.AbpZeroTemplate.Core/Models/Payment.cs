using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Payment : FullAuditModel
    {
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
        public string Address { get; set; }
    }
}
