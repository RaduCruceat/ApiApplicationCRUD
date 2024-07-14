using ApiApplication.Services;
using ApiApplication.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("GetCars", Name = "GetCars")]
    public ActionResult<IEnumerable<CarDto>> GetCars()
    {
        try
        {
            var cars = _carService.GetCars();
            return Ok(cars);
        }
        catch (FluentValidation.ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }

    [HttpGet("GetCar/{id}", Name = "GetCarById")]
    public ActionResult<CarDto> GetCarById(int id)
    {
        if (id < 0)
            return BadRequest("Id < 0 (GetCarById)");
        try
        {
            var retrievedCar = _carService.GetCarById(id);
            return Ok(retrievedCar);
        }
        catch (FluentValidation.ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }

    [HttpPost("CreateCar", Name = "AddCar")]
    public ActionResult<CarDto> AddCar([FromBody] CarDto car)
    {
        try
        {
            var addedCar = _carService.AddCar(car);
            return Ok(addedCar);
        }
        catch (FluentValidation.ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }

    [HttpDelete("DeleteCar/{id}", Name = "DeleteCar")]
    public ActionResult<CarDto> DeleteCar(int id)
    {
        if (id < 0)
            return BadRequest("Id<0 (DeleteCar)");
        try
        {
            var deletedCar = _carService.DeleteCar(id);
            return Ok(deletedCar);
        }
        catch (FluentValidation.ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }

    [HttpPut("EditCar/{id}", Name = "EditCar")]
    public ActionResult<CarDto> EditCar(int id, CarDto car)
    {
        if (id < 0)
            return BadRequest("Id<0 (EditCar)");
        try
        {
            var updatedCar = _carService.UpdateCar(id, car);
            return Ok(updatedCar);
        }
        catch (FluentValidation.ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }
}