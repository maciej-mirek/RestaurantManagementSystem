using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RestaurantManagementSystem.Application.Dishes;
using RestaurantManagementSystem.Application.Orders;
using RestaurantManagementSystem.Application.Orders.Commands.CreateOrder;
using RestaurantManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DishDto, Dish>();

            CreateMap<CreateOrderCommand, OrderDto>();

            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserId.HasValue ? new IdentityUser<int> { Id = (int)src.UserId } : null))
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.Dishes));

            CreateMap<OrderDishesDto, OrderDishes>()
                .ForMember(dest => dest.OrderDishesId, opt => opt.Ignore())
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ForMember(dest => dest.Dish, opt => opt.Ignore());
        }
        
    }
}
