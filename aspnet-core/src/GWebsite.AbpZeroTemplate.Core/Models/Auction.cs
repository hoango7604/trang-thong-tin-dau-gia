using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Auction : FullAuditModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
