using ApiApplication.Data;
using ApiApplication.Entities;
using System.Runtime.CompilerServices;

namespace ApiApplication.Services
{
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
            throw new NotImplementedException();
        }

        public Car AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public Car UpdateCar(int carId)
        {
            throw new NotImplementedException();
        }

        public Car DeleteCar(int carId)
        {
            throw new NotImplementedException();
        }

       
    }
}
