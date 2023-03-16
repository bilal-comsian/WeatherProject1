using Testapp.Interfaces;

namespace Testapp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _dbContext;

        public IWeatherRepository Weathers { get;set; }
        public ICountryRepository Countries { get; set; }
        public ICityRepository Cities { get; set; }
        public UnitOfWork(MyDbContext dbContext,
                            IWeatherRepository weatherRepository, ICountryRepository countries,ICityRepository cities )
        {
            _dbContext = dbContext;
            Weathers = weatherRepository;
            Countries = countries;
            Cities = cities;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}
