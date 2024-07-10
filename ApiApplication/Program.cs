using ApiApplication.Data.Context;
using ApiApplication.Data.Repositories;
using ApiApplication.Services;
using ApiApplication.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCarValidator>();

var repositoryType = builder.Configuration.GetValue<string>("RepositoryType");
if (repositoryType == "Dapper")
{
    string connectionString = builder.Configuration.GetConnectionString("SqlServer");
    builder.Services.AddScoped<IDbConnection>(c => new SqlConnection(connectionString));
    builder.Services.AddScoped<ICarRepository, DapperCarRepository>();
}
else
{
    builder.Services.AddScoped<ICarRepository, CarRepository>();
}
//builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<CarContext, CarContext>();
builder.Services.AddScoped<CarIdValidator>();
builder.Services.AddScoped<CreateCarValidator>();
builder.Services.AddScoped<DeleteCarValidator>();
builder.Services.AddScoped<UpdateCarValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
