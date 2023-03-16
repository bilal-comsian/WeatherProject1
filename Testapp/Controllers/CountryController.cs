using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Testapp.Interfaces;
using Testapp.Model;

namespace Testapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryService _countryService;
        public CountryController(ILogger<CountryController> logger, ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        [HttpGet(Name = "GetAllCountry")]
        public async Task<IEnumerable<Country>> Get()
        {
            return await _countryService.GetAllCountries();
        }
    }
}
