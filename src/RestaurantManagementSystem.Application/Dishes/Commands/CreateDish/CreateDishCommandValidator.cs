using FluentValidation;
using RestaurantManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Dishes.Commands.CreateDish
{
    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(25);

            RuleFor(d => d.Description)
                .MaximumLength(50);

            RuleFor(d => d.IsVisible)
                .NotEmpty();

            RuleFor(d => d.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);


        }
    }
}
