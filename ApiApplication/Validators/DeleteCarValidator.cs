using ApiApplication.Data.Repositories;
using FluentValidation;

namespace ApiApplication.Validators
{
    public class DeleteCarValidator : AbstractValidator<int>
    {
        private readonly ICarRepository _carRepository;

        public DeleteCarValidator(ICarRepository carRepository)
        {
            _carRepository = carRepository;

            RuleFor(carId => carId)
                 .Must(carId => CarExists(carId))
                .WithMessage("Car with the given ID does not exist.");
        }

        private bool CarExists(int carId)
        {
            var car = _carRepository.GetCarById(carId); // Use .Result to wait synchronously
            return car != null;
        }
    }
}
