using ApiApplication.Data.Entities;
using ApiApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsController : ControllerBase
{
    

    private readonly ILogger<CarsController> _logger;
    private readonly ICarService _carService;

    public CarsController(ILogger<CarsController> logger,ICarService carService)
    {
        _logger = logger;
        _carService = carService;
    }

    [HttpGet(Name = "GetCars")]
    public IEnumerable<Car> GetCars()
    {
        return _carService.GetCars();
    }

    [HttpGet("{id}", Name = "GetCarById")]
    public Car GetCarById(int id)
    {
        return _carService.GetCarById(id);
    }

    [HttpPost(Name = "AddCar")]
    public Car AddCar([FromBody] Car car)
    {
        return _carService.AddCar(car);
    }

    [HttpDelete(Name = "DeleteCar")]
    public Car DeleteCar(int id)
    {
        return _carService.DeleteCar(id);
    }

    [HttpPut("{id}", Name = "EditCar")]
    public Car EditCar(int id, Car car)
    {
        car.Id = id;
        return _carService.UpdateCar(id, car);
    }





}
