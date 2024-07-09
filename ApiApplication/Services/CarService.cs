using ApiApplication.Data.Entities;
using ApiApplication.Data.Repositories;
using ApiApplication.Services.Dtos;
using ApiApplication.Validators;
using FluentValidation;

namespace ApiApplication.Services;

public class CarService:ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly CarIdValidator _carIdValidator;
    private readonly CreateCarValidator _createCarValidator;
    private readonly UpdateCarValidator _updateCarValidator;
    private readonly DeleteCarValidator _deleteCarValidator;
    public CarService(ICarRepository carRepository, CarIdValidator carIdValidator, CreateCarValidator createCarValidator, UpdateCarValidator updateCarValidator, DeleteCarValidator deleteCarValidator)
    {
        _carRepository = carRepository;
        _carIdValidator = carIdValidator;
        _createCarValidator = createCarValidator;
        _updateCarValidator = updateCarValidator;
        _deleteCarValidator = deleteCarValidator;
    }

    public List<CarDto> GetCars()
    {
        var cars = _carRepository.GetCars();
        var carsDto = cars.Select(car => MapCarToCarDto(car)).ToList();
        return carsDto;
    }

    public CarDto GetCarById(int carId)
    {
        var validationResult = _carIdValidator.Validate(carId);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var car = _carRepository.GetCarById(carId);
        return MapCarToCarDto(car);
    }

    public CarDto AddCar(CarDto carDto)
    {
        var validationResult = _createCarValidator.Validate(carDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var car = MapCarDtoToCar(carDto);
        var addedCar = _carRepository.AddCar(car);
        return MapCarToCarDto(addedCar);

    }

    public CarDto UpdateCar(int carId, CarDto carDto)
    {
        var validationResult = _updateCarValidator.Validate((carId, carDto));
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var car = MapCarDtoToCar(carDto);
        car.Id = carId;
        var updatedCar = _carRepository.UpdateCar(carId, car);
        return MapCarToCarDto(updatedCar);
    }

    public CarDto DeleteCar(int carId)
    {
         var validationResult = _carIdValidator.Validate(carId);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var car = _carRepository.DeleteCar(carId);
        return MapCarToCarDto(car);
    }
    private Car MapCarDtoToCar(CarDto carDto)
    {
        return new Car
        {
            An = carDto.An,
            Model = carDto.Model,
            Motor = carDto.Motor,
            Marca = carDto.Marca
        };
    }
    private CarDto MapCarToCarDto(Car car)
    {
        return new CarDto
        {
            An = car.An,
            Model = car.Model,
            Motor = car.Motor,
            Marca = car.Marca
        };
    }


}
