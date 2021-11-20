using DataAccess.DataContext;
using DataAccess.Env;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Producer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var optionsBuilder = new DbContextOptionsBuilder<ProducerDataContext>();
                    optionsBuilder.UseNpgsql(Util.PostgresConnectionString, actions => actions.MigrationsAssembly("DataAccess"));

                    services.AddHostedService<Worker>();
                    services.AddScoped(s => new ProducerDataContext(optionsBuilder.Options));
                });
    }
}
