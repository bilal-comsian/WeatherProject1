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
       

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet(Name = "GetWeatherForecast/{CityName?}")]
        public async Task<IEnumerable<WeatherForecast>> Get(string CityName)
        {

            
            return await _weatherService.GetAllWeathers(CityName);
        }
    }
}