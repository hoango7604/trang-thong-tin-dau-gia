using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Auction : FullAuditModel
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
