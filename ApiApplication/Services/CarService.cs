using ApiApplication.Data.Entities;
using ApiApplication.Data.Repositories;
using ApiApplication.Services.Dtos;

namespace ApiApplication.Services;

public class CarService:ICarService
{
    private readonly ICarRepository _carRepository;
    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public List<CarDto> GetCars()
    {
        var cars = _carRepository.GetCars();
        var carsDto = cars.Select(car => MapCarToCarDto(car)).ToList();
        return carsDto;
    }

    public CarDto GetCarById(int carId)
    {
        var car= _carRepository.GetCarById(carId);
        var carDto = MapCarToCarDto(car);
        return carDto;
    }

    public CarDto AddCar(CarDto carDto)
    {
        var car=MapCarDtoToCar(carDto);
        var addedCar=_carRepository.AddCar(car);
        return MapCarToCarDto(addedCar);

    }

    public CarDto UpdateCar(int carId, CarDto carDto)
    {
        var car = MapCarDtoToCar(carDto);
        car.Id=carId; 
        var updatedCar = _carRepository.UpdateCar(carId, car);
        return MapCarToCarDto(updatedCar);
    }

    public CarDto DeleteCar(int carId)
    {
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
