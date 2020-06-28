using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Clients;
using GWebsite.AbpZeroTemplate.Application.Share.Clients.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.Clients
{
    public class ClientAppService : GWebsiteAppServiceBase, IClientAppService
    {
        private readonly IRepository<Client> clientRepository;

        public ClientAppService(IRepository<Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        #region public methods

        public void CreateOrEditClient(ClientDto input)
        {
            if (input.Id == 0)
            {
                Create(input);
            }
            else
            {
                Edit(input);
            }
        }

        public void DeleteClient(int id)
        {
            Delete(id);
        }

        public ClientDto GetClientForEdit(int id)
        {
            return Get(id);
        }

        public ClientDto GetClientForView(int id)
        {
            return Get(id);
        }

        public PagedResultDto<ClientDto> GetClients(ClientFilter filter)
        {
            return GetList(filter);
        }

        public bool Login(ClientLogin login)
        {
            var client = clientRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Phone.Equals(login.Phone) && x.Password.Equals(login.Password));
            if (client != null)
            {
                return true;
            }

            return false;
        }

        #endregion public methods

        #region private methods

        private void Create(ClientDto input)
        {
            var clientEntity = ObjectMapper.Map<Client>(input);
            SetAuditInsert(clientEntity);
            clientRepository.Insert(clientEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private void Edit(ClientDto input)
        {
            var clientEntity = clientRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == input.Id);
            if (clientEntity == null)
            {
            }
            ObjectMapper.Map(input, clientEntity);
            SetAuditEdit(clientEntity);
            clientRepository.Update(clientEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private ClientDto Get(int id)
        {
            var clientEntity = clientRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (clientEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ClientDto>(clientEntity);
        }

        private PagedResultDto<ClientDto> GetList(ClientFilter filter)
        {
            var query = clientRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (filter.FullName != null)
            {
                query = query.Where(x => x.FullName.ToLower().Equals(filter.FullName));
            }
            if (filter.Phone != null)
            {
                query = query.Where(x => x.Phone.ToLower().Equals(filter.Phone));
            }
            if (filter.Role != null)
            {
                query = query.Where(x => x.Role.ToLower().Equals(filter.Role));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(filter.Sorting))
            {
                query = query.OrderBy(filter.Sorting);
            }

            // paging
            var items = query.PageBy(filter).ToList();

            // result
            return new PagedResultDto<ClientDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ClientDto>(item)).ToList()
            );
        }

        private void Delete(int id)
        {
            var clientEntity = clientRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (clientEntity != null)
            {
                clientEntity.IsDelete = true;
                clientRepository.Update(clientEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        #endregion private methods
    }
}
