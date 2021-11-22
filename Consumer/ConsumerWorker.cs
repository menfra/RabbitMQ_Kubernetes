using DataAccess.DataModels;
using DataAccess.DataServices;
using DataAccess.Env;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Consumer
{
    public static class ConsumerWorker
    {
        /// <summary>
        /// This methids registers the entities and the database table it targets when consuming queue services.
        /// </summary>
        /// <param name="services"></param>
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
