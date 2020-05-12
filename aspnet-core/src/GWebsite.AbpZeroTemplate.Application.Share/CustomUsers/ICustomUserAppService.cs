using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.CustomUsers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.CustomUsers
{
    public interface ICustomUserAppService
    {
        void CreateOrEditCustomUser(CustomUserInput input);
        CustomUserInput GetCustomUserForEdit(int id);
        void DeleteCustomUser(int id);
        PagedResultDto<CustomUserDto> GetCustomUsers(CustomUserFilter filter);
        CustomUserForViewDto GetCustomUserForView(int id);
    }
}
