using ApiApplication.Services.Dtos;

namespace ApiApplication.Services;

public interface ICarService
{
    public List<CarDto> GetCars();
    public CarDto GetCarById(int carId);       
    public CarDto AddCar(CarDto car);  
    public CarDto UpdateCar(int carId, CarDto car);
    public CarDto DeleteCar(int carId);
}
