using FluentValidation.TestHelper;
using RestaurantManagementSystem.Application.Orders;
using RestaurantManagementSystem.Application.Orders.Commands.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Tests.Orders.Commands
{
    public class CreateOrderCommandValidatorTests
    {
        [Fact]
        public void ValidateValidCreateOrderCommandTest()
        {
            var validator = new CreateOrderCommandValidator();
            var command = new CreateOrderCommand()
            {
                UserId= 1,
                IsPaid = true,
                TotalPrice = 40,
                DeliveryPrice = 0,
                DeliveryType = DeliveryTypeEnum.Local,
                PaymentType = PaymentTypeEnum.Online,
                TableNumber = 1,
                Dishes = new List<OrderDishesDto>() { new OrderDishesDto { DishId = 1, Quantity = 1 },
                    new OrderDishesDto { DishId = 2, Quantity = 3 }}
            };
            var result = validator.TestValidate(command);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void ValidateInvalidCreateOrderCommandTest()
        {
            var validator = new CreateOrderCommandValidator();
            var command = new CreateOrderCommand()
            {
                UserId = 1,
                IsPaid = true,
                TableNumber = 1
            };
            var result = validator.TestValidate(command);

            result.ShouldHaveAnyValidationError();
        }
    }
}
