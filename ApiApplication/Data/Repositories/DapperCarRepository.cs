using ApiApplication.Data.Entities;
using Dapper;
using System.Collections.Generic;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApiApplication.Data.Repositories
{
    public class DapperCarRepository : ICarRepository
    {
        private readonly IDbConnection _dbConnection;

        public DapperCarRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Car GetCarById(int id)
        {
            string query = "SELECT * FROM Cars WHERE Id = @Id";
            return _dbConnection.QueryFirstOrDefault<Car>(query, new { Id = id });
        }

        public List<Car> GetCars()
        {
            string query = "SELECT * FROM Cars";
            return _dbConnection.Query<Car>(query).AsList();
        }

        public Car AddCar(Car car)
        {
            string query = @"INSERT INTO Cars (Marca, Model, An,Motor) 
                             VALUES (@Marca, @Model, @An, @Motor);
                             SELECT CAST(SCOPE_IDENTITY() as int)";
            int id = _dbConnection.ExecuteScalar<int>(query, car);
            car.Id = id; // Assign the generated ID back to the Car object
            return car;
        }

        public Car UpdateCar(int carId, Car car)
        {
            string query = @"UPDATE Cars 
                             SET Marca = @Marca, Model = @Model, An = @An , Motor = @An 
                             WHERE Id = @Id";
            var parameters = new
            {
                car.Id,
                car.An,
                car.Model,
                car.Marca,
                car.Motor
            };
            _dbConnection.Execute(query, parameters);
            return car;
        }

        public Car DeleteCar(int carId)
        {
            string selectQuery = "SELECT * FROM Cars WHERE Id = @Id";
            var selectedCar= _dbConnection.QueryFirstOrDefault<Car>(selectQuery, new { Id = carId }); 
            string deleteQuery = "DELETE FROM Cars WHERE Id = @Id";
            var parameters = new { Id = carId };
            var car = _dbConnection.QueryFirstOrDefault<Car>(deleteQuery, parameters);
             return selectedCar;
        }
    }
}
