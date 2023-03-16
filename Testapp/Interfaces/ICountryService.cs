using Testapp.Model;

namespace Testapp.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetAllCountries();

        Task<Country> GetCountryById(int countryId);
    }
}
