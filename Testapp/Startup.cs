using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Testapp.Repository;

namespace Testapp
{
    public static class Startup
    {
        public static void ServiceConfiguration(IServiceCollection service)
        {
            service.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MyDbConnection")));
        }
    }
}
