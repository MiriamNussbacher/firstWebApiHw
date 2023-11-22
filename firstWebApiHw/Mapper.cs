
using AutoMapper;
using DTO;
using Entities;

namespace webApiShopSite.wwwroot
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserIdNameDto>();
        }

    }
}
