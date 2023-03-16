namespace Testapp.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IWeatherRepository Weathers { get; }
        ICountryRepository Countries { get; }
        ICityRepository Cities { get; }
        int Save();
    }
}
