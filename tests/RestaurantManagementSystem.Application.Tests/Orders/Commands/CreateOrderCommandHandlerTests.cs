using AutoMapper;
using FluentAssertions;
using Moq;
using RestaurantManagementSystem.Application.Orders;
using RestaurantManagementSystem.Application.Orders.Commands.CreateOrder;
using RestaurantManagementSystem.Domain.Entities;
using RestaurantManagementSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Tests.Orders.Commands
{
    public class CreateOrderCommandHandlerTests
    {
        [Fact]
        public async Task Handle_CreateOrder()
        {

            var order = new Order
            {
                IsPaid = true,
                TotalPrice = 40,
                DeliveryPrice = 0,
                DeliveryType = DeliveryTypeEnum.Local,
                PaymentType = PaymentTypeEnum.Online,
                TableNumber = 1,
                Dishes = new List<Domain.Entities.OrderDishesDto>() { new Domain.Entities.OrderDishesDto { DishId = 1, Quantity = 1 },
                    new Domain.Entities.OrderDishesDto { DishId = 2, Quantity = 3 }}
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            var iMapper = new Mock<IMapper>();

            var command = new CreateOrderCommand();

            iMapper.Setup(m => m.Map<Order>(It.IsAny<CreateOrderCommand>()))
                .Returns(order);

            orderRepositoryMock.Setup(o => o.Create(order)).ReturnsAsync(order);

            var handler = new CreateOrderCommandHandler(orderRepositoryMock.Object,iMapper.Object);

            var result = await handler.Handle(command,default);

            result.Should().NotBeNull();
            orderRepositoryMock.Verify(o => o.Create(It.IsAny<Order>()), Times.Once);
        }


    }
}
