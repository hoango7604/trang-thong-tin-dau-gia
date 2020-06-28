using System;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Application.Share.Clients.Dto
{
    public class ClientLogin : Entity<int>
    {
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
