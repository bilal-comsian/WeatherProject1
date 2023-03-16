using Testapp.Model;
using Testapp.Repository;
using Microsoft.EntityFrameworkCore;
using Testapp.Interfaces;

namespace Testapp.Services
{
    public class WeatherService : IWeatherService
    {
        public IUnitOfWork _unitOfWork;

        public WeatherService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddWeather(WeatherForecast weather)
        {
            if (weather != null)
            {
                await _unitOfWork.Weathers.Add(weather);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteWeather(int weatherId)
        {
            if (weatherId > 0)
            {
                var weather = await _unitOfWork.Weathers.GetById(weatherId);
                if (weather != null)
                {
                    _unitOfWork.Weathers.Delete(weather);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<WeatherForecast>> GetAllWeathers()
        {
            var weathers = await _unitOfWork.Weathers.GetAll();
            return weathers;
        }

        public async Task<WeatherForecast> GetWeatherById(int weatherId)
        {
            if (weatherId > 0)
            {
                var weathers = await _unitOfWork.Weathers.GetById(weatherId);
                if (weathers != null)
                {
                    return weathers;
                }
            }
            return null;
        }

        public async Task<bool> UpdateWeather(WeatherForecast weather)
        {
            if (weather != null)
            {
                var _weather = await _unitOfWork.Weathers.GetById(weather.Id);
                if (_weather != null)
                {
                    _weather.Date = weather.Date;
                    _weather.TemperatureC= weather.TemperatureC;
                    _weather.Summary = weather.Summary;

                    _unitOfWork.Weathers.Update(_weather);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }

}
