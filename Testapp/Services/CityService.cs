using Testapp.Interfaces;
using Testapp.Model;

namespace Testapp.Services
{
    public class CityService : ICityService
    {
        public Task<IEnumerable<WeatherForecast>> GetAllCities()
        {
            throw new NotImplementedException();
        }

        public Task<WeatherForecast> GetCityByCountryId(int countryId)
        {
            throw new NotImplementedException();
        }
    }
}
