using ApiApplication.Data.Entities;
using ApiApplication.Data.Repositories;
using System.Runtime.CompilerServices;

namespace ApiApplication.Services;

public class CarService:ICarService
{
    private readonly ICarRepository _carRepository;
    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public List<Car> GetCars() 
    {
        return _carRepository.GetCars();
    }

    public Car GetCarById(int carId)
    {
        return _carRepository.GetCarById(carId);    
    }

    public Car AddCar(Car car)
    {
        return _carRepository.AddCar(car);
    }

    public Car UpdateCar(int carId,Car car)
    {
        return _carRepository.UpdateCar(carId,car); 
    }

    public Car DeleteCar(int carId)
    {
        return _carRepository.DeleteCar (carId);
    }

   
}
