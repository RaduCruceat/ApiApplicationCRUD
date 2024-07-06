using ApiApplication.Entities;

namespace ApiApplication.Data
{
    public interface ICarRepository
    {
        public List<Car> GetCars();
        public Car GetCarById(int carId);
        public Car AddCar(Car car);
        public Car UpdateCar(int carId);
        public Car DeleteCar(int carId);
    }
}
