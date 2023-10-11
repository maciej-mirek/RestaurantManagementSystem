using AutoMapper;
using FluentAssertions;
using RestaurantManagementSystem.Application.Common.Mappings;
using RestaurantManagementSystem.Application.Orders;
using RestaurantManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Tests.Mappings
{

    
    public class MapingProfileTests
    {
        private IMapper _mapper;

        public MapingProfileTests()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile(new MappingProfile()));

             _mapper = configuration.CreateMapper();
        }

        [Fact]
        public void MappingProfile_Order_and_OrderDishes()
        {

            var address = new Address
            {
                FirstName = "Tester",
                LastName = "Testowy",
                PhoneNumber = "123456789",
                PostalCode = "00-000"
            };

            var orderDto = new OrderDto
            {
                UserId =1,
                IsPaid = true,
                TotalPrice = 40,
                DeliveryPrice = 0,
                DeliveryType = DeliveryTypeEnum.Local,
                PaymentType = PaymentTypeEnum.Online,
                TableNumber = 1,
                Address= address,
                Dishes = new List<OrderDishesDto>() { new OrderDishesDto { DishId = 1, Quantity = 1 },
                    new OrderDishesDto { DishId = 2, Quantity = 3 }}
            };

            var result = _mapper.Map<Order>(orderDto);

            result.Should().NotBeNull();
            result.Dishes.Should().HaveCountGreaterThanOrEqualTo(1);
            result.Address.Should().NotBeNull();
            result.TotalPrice.Should().BeGreaterThanOrEqualTo(0);
            result.DeliveryPrice.Should().BeGreaterThanOrEqualTo(0);
            result.DeliveryType.Should().BeOneOf(DeliveryTypeEnum.Local,DeliveryTypeEnum.ToAdress,DeliveryTypeEnum.TakeAway);
            result.PaymentType.Should().BeOneOf(PaymentTypeEnum.OnDelivery,PaymentTypeEnum.Online);
            result.Dishes.Select(d => d.Quantity.Should().BeGreaterThanOrEqualTo(1));
            result.Dishes.Select(d => d.DishId.Should().BeGreaterThanOrEqualTo(1));

        }

    }
}
