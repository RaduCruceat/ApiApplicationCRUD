using ApiApplication.Entities;
using ApiApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private static readonly List<Car> Cars = new List<Car>
        {
           new Car{ 
               Id=1,
               Marca="a",
               Model="a",
               Motor=3000,
               An=1000,
           },           
            new Car{
               Id=2,
               Marca="b",
               Model="b",
               Motor=4000,
               An=15000,
            },
             new Car{
               Id=3,
               Marca="c",
               Model="c",
               Motor=5000,
               An=17000,
             },
              new Car{
               Id=4,
               Marca="as",
               Model="bss",
               Motor=5000,
               An=15000}
        };

        private readonly ILogger<CarsController> _logger;
        private readonly ICarService _carService;

        public CarsController(ILogger<CarsController> logger,ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        [HttpGet(Name = "GetCars")]
        public IEnumerable<Car> Get()
        {
            return _carService.GetCars();

        }
    }
}
