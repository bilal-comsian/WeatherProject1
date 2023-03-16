using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testapp.Interfaces;
using Testapp.Model;

namespace Testapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly ICityService _cityService;
        public CityController(ILogger<CityController> logger, ICityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }

        [HttpGet(Name = "GetCitiesByCountryId/{CountryId?}")]
        public async Task<IEnumerable<City>> Get(string CountryId)
        {
            return await _cityService.GetCityByCountryId(CountryId);
        }
    }
}
