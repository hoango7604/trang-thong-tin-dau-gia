using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Clients.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Clients
{
    public interface IClientAppService
    {
        void CreateOrEditClient(ClientDto input);
        ClientDto GetClientForEdit(int id);
        void DeleteClient(int id);
        PagedResultDto<ClientDto> GetClients(ClientFilter filter);
        ClientDto GetClientForView(int id);
        bool Login(string username, string password);
    }
}