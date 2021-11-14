using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.DataModels;

namespace Publisher
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Make a user object
                User user = new User()
                {
                    Name = $"{nameof(Worker)}_{RandomString(8)}",
                    DisplayName = nameof(Worker),
                    Age = DateTime.Now.Second.ToString(),
                    Occupation = "Producer"
                };

                // Save the object to a db
                var results = await DataServices.GetInstance.AddData("", user);

                // send the object to a message queue for the other service to also use.
                if (results != null)
                    QueueServices.GetInstance.Produce(results);

                await Task.Delay(10000, stoppingToken);
            }
        }

        private Random random = new Random();

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
