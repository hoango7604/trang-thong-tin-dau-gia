﻿using Abp.Domain.Entities;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Clients.Dto
{
    public class ClientDto : Entity<int>
    {
        public string Phone { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}
