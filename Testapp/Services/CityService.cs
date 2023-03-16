using Testapp.Interfaces;
using Testapp.Model;

namespace Testapp.Services
{
    public class CityService : ICityService
    {
        public IUnitOfWork _unitOfWork;
        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<City>> GetAllCities()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<City>> GetCityByCountryId(string countryId)
        {
            if (string.IsNullOrEmpty(countryId))
                return await GetAllCities();
            else
                return await _unitOfWork.Cities
                    .GetListAsync(x => x.CountryId == countryId);
        }
    }
}
