using FluentValidation;
using OceanRestaurant.Dtos.Dishes;

namespace OceanRestaurant.Api.FluentValidation.AspNetCore
{
    public class DishValidator : AbstractValidator<DishDto>
    {

        public DishValidator() {

            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().Length(4, 25).WithMessage("Your name should write at least 3 letters to 25 letter");

        }
    }
}
