using FluentValidation;
using OceanRestaurant.Dtos.Orders;

namespace OceanRestaurant.Api.FluentValidation.AspNetCore
{
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator()
        {

            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.GuestId).NotNull().WithMessage("You have to choose the guest");
            RuleFor(x => x.DishIds).NotNull().WithMessage("You have to choose something");

        }
    }
}
