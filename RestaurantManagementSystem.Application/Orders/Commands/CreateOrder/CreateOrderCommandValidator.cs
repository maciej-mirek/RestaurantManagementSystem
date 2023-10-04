using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(c => c.Dishes)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.TotalPrice)
                .NotNull()
                .GreaterThanOrEqualTo(0);

            RuleFor(c => c.DeliveryPrice)
                .NotNull()
                .GreaterThanOrEqualTo(0);

            RuleFor(c => c.DeliveryType)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.PaymentType)
                .NotEmpty()
                .NotNull();
        }
    }
}
