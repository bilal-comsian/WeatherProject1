using Microsoft.EntityFrameworkCore;
using Testapp.Model;

namespace Testapp.Repository
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherForecast> CityWeather { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        //public DbSet<Order> Orders { get; set; }
    }

}
