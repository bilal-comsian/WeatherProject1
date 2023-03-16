using Testapp.Model;

namespace Testapp.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<WeatherForecast>> GetAllCities();

        Task<WeatherForecast> GetCityByCountryId(int countryId);
    }
}
