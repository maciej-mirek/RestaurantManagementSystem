using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Application.Dishes.Commands.ArchiveDish
{
    public class ArchiveDishCommandValidator : AbstractValidator<ArchiveDishCommand>
    {
        public ArchiveDishCommandValidator()
        {
            RuleFor(a => a.DishId)
                .NotNull()
                .NotEmpty();
        }
    }
}
