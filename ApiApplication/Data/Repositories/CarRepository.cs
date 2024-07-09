using ApiApplication.Data.Context;
using ApiApplication.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApiApplication.Data.Repositories;

public class CarRepository : ICarRepository
{
    private readonly CarContext _context;

    public CarRepository(CarContext context)
    {
        _context = context;
    }

    public Car AddCar(Car car)
    {
        _context.Cars.Add(car);
        _context.SaveChanges();
        return car;
    }

    public Car DeleteCar(int carId)
    {
        var car = _context.Cars.Find(carId);
        if (car != null)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
        return car;
    }

    public Car GetCarById(int carId)
    {
        return _context.Cars.Find(carId);
    }
    public async Task<Car> GetCarByIdAsync(int carId)
    {
        return await _context.Cars.FindAsync(carId);
    }

    public List<Car> GetCars()
    {
        return _context.Cars.ToList();
    }

    public Car UpdateCar(int carId, Car car)
    {
        var toUpdate = GetCarById(carId);
        _context.Entry(toUpdate).CurrentValues.SetValues(car);
        _context.SaveChanges();
        return car;
    }

    private bool CarExists(int id)
    {
        return _context.Cars.Any(e => e.Id == id);
    }
}