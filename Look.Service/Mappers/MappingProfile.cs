using AutoMapper;
using Look.Domain.Entities.Categories;
using Look.Domain.Entities.Customers;
using Look.Domain.Entities.Orders;
using Look.Domain.Entities.Payments;
using Look.Domain.Entities.Products;
using Look.Service.DTOs.CategoryForCreationDto;
using Look.Service.DTOs.CustomerForCreationDto;
using Look.Service.DTOs.OrderForCreationDto;
using Look.Service.DTOs.PaymentForCreationDto;
using Look.Service.DTOs.ProductForCreationDto;

namespace Look.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductForCreation>().ReverseMap();
            CreateMap<Customer, CustomerForCreation>().ReverseMap();
            CreateMap<Payment, PaymentForCreation>().ReverseMap();
            CreateMap<Category, CategoryForCreation>().ReverseMap();
            CreateMap<Order, OrderForCreation>().ReverseMap();
        }
    }
}
