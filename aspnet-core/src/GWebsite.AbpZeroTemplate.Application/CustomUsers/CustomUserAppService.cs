using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.CustomUsers;
using GWebsite.AbpZeroTemplate.Application.Share.CustomUsers.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Web.Core.CustomUsers
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_CustomUser)]
    public class CustomUserAppService : GWebsiteAppServiceBase, ICustomUserAppService
    {
        private readonly IRepository<CustomUser> _customUserRepository;

        public CustomUserAppService(IRepository<CustomUser> customUserRepository)
        {
            _customUserRepository = customUserRepository;
        }

        #region Public Methods

        public void CreateOrEditCustomUser(CustomUserInput input)
        {
            if (input.Id == 0)
            {
                Create(input);
            }
            else
            {
                Update(input);
            }
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_CustomUser_Delete)]
        public void DeleteCustomUser(int id)
        {
            var customUserEntity = _customUserRepository.GetAll()
                .Where(c => !c.IsDelete)
                .SingleOrDefault(c => c.Id == id);

            if (customUserEntity != null)
            {
                customUserEntity.IsDelete = true;
                _customUserRepository.Update(customUserEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public CustomUserInput GetCustomUserForEdit(int id)
        {
            var customUserEntity = _customUserRepository.GetAll()
                .Where(c => !c.IsDelete)
                .SingleOrDefault(c => c.Id == id);

            if (customUserEntity == null)
            {
                return null;
            }

            return ObjectMapper.Map<CustomUserInput>(customUserEntity);
        }

        public CustomUserForViewDto GetCustomUserForView(int id)
        {
            var customUserEntity = _customUserRepository.GetAll()
                .Where(c => !c.IsDelete)
                .SingleOrDefault(c => c.Id == id);

            if (customUserEntity == null)
            {
                return null;
            }

            return ObjectMapper.Map<CustomUserForViewDto>(customUserEntity);
        }

        public PagedResultDto<CustomUserDto> GetCustomUsers(CustomUserFilter filter)
        {
            var query = _customUserRepository.GetAll()
                .Where(c => !c.IsDelete);

            if (filter.Name != null)
            {
                query = query.Where(c => c.Name.ToLower().Equals(filter.Name));
            }

            var totalCount = query.Count();

            if (!string.IsNullOrWhiteSpace(filter.Sorting))
            {
                query = query.OrderBy(filter.Sorting);
            }

            var items = query.PageBy(filter).ToList();

            return new PagedResultDto<CustomUserDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<CustomUserDto>(item)).ToList()
            );
        }

        #endregion

        #region Private Methods

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_CustomUser_Create)]
        private void Create(CustomUserInput input)
        {
            var customUserEntity = ObjectMapper.Map<CustomUser>(input);
            SetAuditInsert(customUserEntity);
            _customUserRepository.Insert(customUserEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_CustomUser_Edit)]
        private void Update(CustomUserInput input)
        {
            var customUserEntity = _customUserRepository.GetAll()
                .Where(c => !c.IsDelete)
                .SingleOrDefault(c => c.Id == input.Id);

            if (customUserEntity != null)
            {
                ObjectMapper.Map(input, customUserEntity);
                SetAuditEdit(customUserEntity);
                _customUserRepository.Update(customUserEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        #endregion
    }
}