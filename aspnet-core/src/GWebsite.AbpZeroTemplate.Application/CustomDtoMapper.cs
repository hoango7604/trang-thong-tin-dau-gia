using AutoMapper;
using GWebsite.AbpZeroTemplate.Application.Share.AuctionDetails.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Auctions.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Categories.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Clients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Customers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.CustomUsers.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.MenuClients.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Payments.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Products.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Applications
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<MenuClient, MenuClientDto>();
            configuration.CreateMap<MenuClient, MenuClientListDto>();
            configuration.CreateMap<CreateMenuClientInput, MenuClient>();
            configuration.CreateMap<UpdateMenuClientInput, MenuClient>();

            // DemoModel
            configuration.CreateMap<DemoModel, DemoModelDto>();
            configuration.CreateMap<DemoModelInput, DemoModel>();
            configuration.CreateMap<DemoModel, DemoModelInput>();
            configuration.CreateMap<DemoModel, DemoModelForViewDto>();

            // Customer
            configuration.CreateMap<Customer, CustomerDto>();
            configuration.CreateMap<CustomerInput, Customer>();
            configuration.CreateMap<Customer, CustomerInput>();
            configuration.CreateMap<Customer, CustomerForViewDto>();

            // CustomUser
            configuration.CreateMap<CustomUser, CustomUserDto>();
            configuration.CreateMap<CustomUserInput, CustomUser>();
            configuration.CreateMap<CustomUser, CustomUserInput>();
            configuration.CreateMap<CustomUser, CustomUserForViewDto>();

            configuration.CreateMap<Client, ClientDto>();
            configuration.CreateMap<ClientDto, Client>();
            configuration.CreateMap<Auction, AuctionDto>();
            configuration.CreateMap<AuctionDto, Auction>();
            configuration.CreateMap<Category, CategoryDto>();
            configuration.CreateMap<CategoryDto, Category>();
            configuration.CreateMap<Product, ProductDto>();
            configuration.CreateMap<ProductDto, Product>();
            configuration.CreateMap<AuctionDetail, AuctionDetailDto>();
            configuration.CreateMap<AuctionDetailDto, AuctionDetail>();
            configuration.CreateMap<Payment, PaymentDto>();
            configuration.CreateMap<PaymentDto, Payment>();
        }
    }
}