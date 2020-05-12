using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.CustomUsers;
using GWebsite.AbpZeroTemplate.Application.Share.CustomUsers.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CustomUserController : GWebsiteControllerBase
    {
        private readonly ICustomUserAppService _customUserAppService;

        public CustomUserController(ICustomUserAppService customUserAppService)
        {
            _customUserAppService = customUserAppService;
        }

        [HttpGet]
        public PagedResultDto<CustomUserDto> GetCustomUsersByFilter(CustomUserFilter filter)
        {
            return _customUserAppService.GetCustomUsers(filter);
        }

        [HttpGet]
        public CustomUserInput GetCustomUserForEdit(int id)
        {
            return _customUserAppService.GetCustomUserForEdit(id);
        }

        [HttpPost]
        public void CreateOrEditCustomUser([FromBody] CustomUserInput input)
        {
            _customUserAppService.CreateOrEditCustomUser(input);
        }

        [HttpDelete("{id}")]
        public void DeleteCustomUser(int id)
        {
            _customUserAppService.DeleteCustomUser(id);
        }

        [HttpGet]
        public CustomUserForViewDto GetCustomUserForView(int id)
        {
            return _customUserAppService.GetCustomUserForView(id);
        }
    }
}
