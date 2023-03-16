using Testapp.Interfaces;
using Testapp.Model;

namespace Testapp.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(MyDbContext context) : base(context)
        {
        }
    }
}
