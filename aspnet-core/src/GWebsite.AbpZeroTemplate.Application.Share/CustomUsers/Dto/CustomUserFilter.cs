using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.CustomUsers.Dto
{
    /// <summary>
    /// <model> cref="CustomUser"</model>
    /// </summary>
    public class CustomUserFilter : PagedAndSortedInputDto
    {
        public string Name { get; set; }
    }
}
