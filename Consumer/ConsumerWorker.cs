using DataAccess.DataModels;
using DataAccess.DataServices;
using DataAccess.Env;
using Microsoft.Extensions.DependencyInjection;
using System;
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
                queueServices.ConsumeAndSave<User>(Commons.TBUSER);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
