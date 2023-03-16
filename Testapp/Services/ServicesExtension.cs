using Microsoft.EntityFrameworkCore;
using Testapp.Interfaces;
using Testapp.Repository;

namespace Testapp.Services
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyDbConnection"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWeatherRepository, WeatherRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            return services;
        }
    }
}
