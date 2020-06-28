using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Clients;
using GWebsite.AbpZeroTemplate.Application.Share.Clients.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ClientController : GWebsiteControllerBase
    {
        private readonly IClientAppService clientAppService;

        public ClientController(IClientAppService clientAppService)
        {
            this.clientAppService = clientAppService;
        }

        [HttpGet]
        public PagedResultDto<ClientDto> GetClientsByFilter(ClientFilter filter)
        {
            return clientAppService.GetClients(filter);
        }

        [HttpGet]
        public ClientDto GetClientForEdit(int id)
        {
            return clientAppService.GetClientForEdit(id);
        }

        [HttpGet]
        public ClientDto GetClientForView(int id)
        {
            return clientAppService.GetClientForView(id);
        }

        [HttpPost]
        public void CreateOrEditClient([FromBody] ClientDto input)
        {
            clientAppService.CreateOrEditClient(input);
        }

        [HttpPost]
        public ClientDto Login([FromBody] ClientLogin login)
        {
            return clientAppService.Login(login);
        }

        [HttpDelete("{id}")]
        public void DeleteClient(int id)
        {
            clientAppService.DeleteClient(id);
        }
    }
}
