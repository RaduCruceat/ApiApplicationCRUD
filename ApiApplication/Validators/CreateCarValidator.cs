using FluentValidation;
using ApiApplication.Services.Dtos;

namespace ApiApplication.Validators
{
    public class CreateCarValidator : AbstractValidator<CarDto>
    {
        public CreateCarValidator()
        {
            RuleFor(car => car.An).GreaterThan(1900);
            RuleFor(car => car.Model).NotEmpty();
            RuleFor(car => car.Motor).NotEmpty();
            RuleFor(car => car.Marca).NotEmpty();
        }
    }
}
