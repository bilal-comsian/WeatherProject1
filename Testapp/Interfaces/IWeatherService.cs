using Testapp.Model;

namespace Testapp.Interfaces
{
    public interface IWeatherService
    {
        Task<bool> AddWeather(WeatherForecast weather);

        Task<IEnumerable<WeatherForecast>> GetAllWeathers();

        Task<WeatherForecast> GetWeatherById(int weatherId);

        Task<bool> UpdateWeather(WeatherForecast weather);

        Task<bool> DeleteWeather(int weatherId);
    }
}
