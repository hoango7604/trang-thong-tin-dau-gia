using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Products.Dto
{
    public class ProductDto : Entity<int>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int PrimaryPrice { get; set; }
        public int StartPrice { get; set; }
        public int CurrentPrice { get; set; }
        public int StepPrice { get; set; }
        public int WinnerClientId { get; set; }
        public string ProductId { get; set; }
        public string Brand { get; set; }
        public int Warranty { get; set; }
        public float Diameter { get; set; }
        public string EnergySource { get; set; }
        public string Detail { get; set; }
        public int AuctionId { get; set; }
        public bool IsPaid { get; set; }
    }
}
