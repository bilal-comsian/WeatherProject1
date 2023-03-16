using Testapp.Interfaces;
using Testapp.Model;

namespace Testapp.Repository
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(MyDbContext context) : base(context)
        {
        }
    }
}
