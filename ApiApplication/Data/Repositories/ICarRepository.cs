using ApiApplication.Data.Entities;

namespace ApiApplication.Data.Repositories;

public interface ICarRepository
{
    public List<Car> GetCars();
    public Car GetCarById(int carId);
    public Car AddCar(Car car);
    public Car UpdateCar(int carId,Car car);
    public Car DeleteCar(int carId);
}
