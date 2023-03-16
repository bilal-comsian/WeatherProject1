using Testapp.Interfaces;
using Testapp.Model;

namespace Testapp.Services
{
    public class CountryService : ICountryService
    {
        public IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            var countries = await _unitOfWork.Countries.GetAll();
            //var cities= await _unitOfWork.Cities.GetAll();
            //var result= cities.GroupBy(x =>x.ISO).Select(g => new Country() { 
            //    Name=countries.Where(w=>w.ISO==g.Key).First().Name,
            //    ISO=g.Key,
            //    Cities = g.Select(x=>new City { Name=x.Name,ISO=x.ISO}).ToList()
            //}).ToList();
            return countries;
        }

        public Task<Country> GetCountryById(int countryId)
        {
            throw new NotImplementedException();
        }
    }
}
