using Testapp.Model;

namespace Testapp.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCities();
        Task<IEnumerable<City>> GetCityByCountryId(string countryId);
    }
}
