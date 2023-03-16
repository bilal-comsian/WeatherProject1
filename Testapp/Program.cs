using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Testapp;
using Testapp.Interfaces;
using Testapp.Model;
using Testapp.Repository;
using Testapp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDIServices(builder.Configuration);
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
