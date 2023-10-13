using FluentValidation;
using OceanRestaurant.Dtos.Guests;
using OceanRestaurant.Entites;

namespace OceanRestaurant.Api.FluentValidation.AspNetCore
{
        public class GuestValidator : AbstractValidator<GuestDto>
        {
            public GuestValidator()
            {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().Length(3 , 20).WithMessage("Your name should write at least 3 letters to 20 letter"); 
            RuleFor(x => x.DOB).NotNull().Must(d => DateTime.Now.Year - d.Year >= 18).WithMessage("Your age must be 18 or more");

        }
        }
    
}
