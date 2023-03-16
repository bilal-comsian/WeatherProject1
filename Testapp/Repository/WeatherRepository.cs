using Testapp.Interfaces;
using Testapp.Model;

namespace Testapp.Repository
{
    public class WeatherRepository : GenericRepository<WeatherForecast>, IWeatherRepository
    {
        public WeatherRepository(MyDbContext context) : base(context)
        {
        }
    }
}
