using DataAccess;
using DataAccess.DataModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer
{
    public static class ConsumerWorker
    {
        public static void RunRabbitMQConsumer(this IServiceCollection services)
        {
            try
            {
                IQueueServices queueServices = new QueueServices();
                var user = queueServices.Consume<User>();

                //Console.WriteLine(user.Name);

                //if (user != null)
                //    DataServices.GetInstance.AddData("", user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
