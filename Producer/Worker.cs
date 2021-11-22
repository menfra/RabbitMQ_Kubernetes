using DataAccess.DataServices;
using DataAccess.DataModels;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.DataContext;

namespace Producer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _provider;
        private readonly Random random = new Random();

        public Worker(ILogger<Worker> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _provider.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<ProducerDataContext>();

                // Make a user object
                User user = new User()
                {
                    Name = $"{nameof(Worker)}_{RandomString(8)}",
                    DisplayName = nameof(Worker),
                    Age = DateTime.Now.Second.ToString(),
                    Occupation = "Producer"
                };

                // Save the object to a db
                PostgresDataServices.DBContext = db;
                await PostgresDataServices.GetInstance.AddData(user);

                // send the object to a message queue for the other service to also use.
                if (user != null)
                    QueueServices.GetInstance.Produce(user);

                await Task.Delay(1000, stoppingToken);
            }
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
