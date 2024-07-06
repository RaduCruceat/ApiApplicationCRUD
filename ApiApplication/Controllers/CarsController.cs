using ApiApplication.Services;
using ApiApplication.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsController : ControllerBase
{
   
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet(Name = "GetCars")]
    public IEnumerable<CarDto> GetCars()
    {
        return _carService.GetCars();
    }

    [HttpGet("{id}", Name = "GetCarById")]
    public CarDto GetCarById(int id)
    {
        return _carService.GetCarById(id);
    }

    [HttpPost(Name = "AddCar")]
    public CarDto AddCar([FromBody] CarDto car)
    {
        return _carService.AddCar(car);
    }

    [HttpDelete(Name = "DeleteCar")]
    public CarDto DeleteCar(int id)
    {

        return _carService.DeleteCar(id);
    }

    [HttpPut("{id}", Name = "EditCar")]
    public ActionResult <CarDto> EditCar(int id, CarDto car)
    { 
        
        if (id < 0)
            return BadRequest("id<0");
        if (car.Model.IsNullOrEmpty()|| car.Marca.IsNullOrEmpty()||car.An>DateTime.Now.Year||car.Motor==0)
        {
            return BadRequest("Car not found");
        }
        var updatedCar = _carService.UpdateCar(id, car);
        return Ok(updatedCar); 
            
    }

}
