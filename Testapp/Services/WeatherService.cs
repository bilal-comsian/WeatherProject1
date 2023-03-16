using Testapp.Model;
using Testapp.Repository;
using Microsoft.EntityFrameworkCore;
using Testapp.Interfaces;
using Testapp.Client;

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

        public async Task<IEnumerable<WeatherForecast>> GetAllWeathers(string cityId)
        {
            if (!string.IsNullOrEmpty(cityId))
            {
                var _city= (await _unitOfWork.Cities.GetListAsync(x => x.Name == cityId)).FirstOrDefault();
                if (_city != null)
                {
                    WeatherResponse weatherResponse = new WeatherResponse();
                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync($"http://api.weatherapi.com/v1/current.json?key=8677691c791b4b20ba362900231403&q={cityId}&aqi=yes");
                    if (response.IsSuccessStatusCode)
                    {
                        weatherResponse = await response.Content.ReadFromJsonAsync<WeatherResponse>();
                        WeatherForecast weatherForecast = new WeatherForecast();
                        weatherForecast.TemperatureC = weatherResponse.current.temp_c;
                        weatherForecast.WindSpeed = weatherResponse.current.wind_kph;
                        weatherForecast.Summary = weatherResponse.current.condition.text;
                        weatherForecast.RecordTime = DateTime.Now;
                        weatherForecast.CityId = _city.Id;
                        await AddWeather(weatherForecast);
                    }
                }
                return await _unitOfWork.Weathers.GetListAsync(x=>x.CityId==_city!.Id);
            }
             return await _unitOfWork.Weathers.GetAll();
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
                    _weather.RecordTime = weather.RecordTime;
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
