using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Dishes.Commands.ChangeDishVisibility
{
    public class ChangeDishVisibilityCommandValidator : AbstractValidator<ChangeDishVisibilityCommand>
    {
        public ChangeDishVisibilityCommandValidator()
        {
            RuleFor(c => c.DishId)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Visibility)
                .NotEmpty()
                .NotNull();
        }
    }
}
