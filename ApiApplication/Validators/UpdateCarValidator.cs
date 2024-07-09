using FluentValidation;
using ApiApplication.Services.Dtos;

namespace ApiApplication.Validators
{
    public class UpdateCarValidator : AbstractValidator<(int, CarDto)>
    {
        public UpdateCarValidator()
        {
            RuleFor(tuple => tuple.Item1).GreaterThan(0);
            RuleFor(tuple => tuple.Item2.An).GreaterThan(1900);
            RuleFor(tuple => tuple.Item2.Model).NotEmpty();
            RuleFor(tuple => tuple.Item2.Motor).NotEmpty();
            RuleFor(tuple => tuple.Item2.Marca).NotEmpty();
        }

    }
}
