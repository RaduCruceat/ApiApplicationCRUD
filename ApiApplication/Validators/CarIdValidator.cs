using FluentValidation;
using ApiApplication.Data.Repositories;

namespace ApiApplication.Validators
{
    public class CarIdValidator : AbstractValidator<int>
    {
        private readonly ICarRepository _carRepository;

        public CarIdValidator(ICarRepository carRepository)
        {
            _carRepository = carRepository;

            RuleFor(carId => carId)
                .Must(carId => CarExists(carId))
                .WithMessage("Car with the given ID does not exist.");
        }

        private bool CarExists(int carId)
        {
            var car = _carRepository.GetCarById(carId); 
            return car != null;
        }
    }
}
