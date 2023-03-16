using Testapp.Model;

namespace Testapp.Interfaces
{
    public interface IWeatherService
    {
        Task<bool> AddWeather(WeatherForecast weather);

        Task<IEnumerable<WeatherForecast>> GetAllWeathers(string City);

        Task<WeatherForecast> GetWeatherById(int weatherId);

        Task<bool> UpdateWeather(WeatherForecast weather);

        Task<bool> DeleteWeather(int weatherId);
    }
}
