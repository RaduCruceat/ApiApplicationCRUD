using ApiApplication.Entities;

namespace ApiApplication.Services
{
    public interface ICarService
    {
        public List<Car> GetCars();
        public Car GetCarById(int carId);       
        public Car AddCar(Car car);  
        public Car UpdateCar(int carId);
        public Car DeleteCar(int carId);
    }
}
