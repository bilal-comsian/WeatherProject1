using Microsoft.AspNetCore.Mvc;
using System.IO;
using Testapp.Interfaces;
using Testapp.Model;
using Testapp.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Testapp.Client;

namespace Testapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _customerService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            //WeatherResponse weatherResponse = new WeatherResponse();
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync("http://api.weatherapi.com/v1/current.json?key=8677691c791b4b20ba362900231403&q=Islamabad&aqi=yes");
            //if (response.IsSuccessStatusCode)
            //{
            //    weatherResponse = await response.Content.ReadFromJsonAsync<WeatherResponse>();
            //    WeatherForecast weatherForecast = new WeatherForecast();
            //    weatherForecast.TemperatureC = weatherResponse.current.temp_c;
            //    weatherForecast.WindSpeed = weatherResponse.current.wind_kph;
            //    weatherForecast.Summary = weatherResponse.current.condition.text;
            //    weatherForecast.Date=DateTime.Now;
            //    var test=await _customerService.AddWeather(weatherForecast);
            //}
            var customers = await _customerService.GetAllWeathers();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}