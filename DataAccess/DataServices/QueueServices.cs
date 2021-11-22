using DataAccess.Env;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text.Json;

namespace DataAccess.DataServices
{
    public class QueueServices : IQueueServices
    {
        private static readonly QueueServices instance = null;
        public static QueueServices GetInstance
        {
            get 
            {
                if (instance == null)return new QueueServices();
                return instance;
            }
        }
      
        public void ConsumeAndSave<T>()
        {
            // Channel is created.
            var channel = GetChannel(Util.UriProtocol, Commons.MESSAGE_QUEUE);

            // Instatiate a consumer to consume queue.
            var consumer = new EventingBasicConsumer(channel);
            T TModel = default;

            consumer.Received += async (sender, e) =>
            {
                // check null for the event arg
                if (e.Body.ToArray() == null)
                    return;

                TModel = JsonSerializer.Deserialize<T>(e.Body.ToArray());

                // Save a copy into the Mongo
                if (TModel != null)
                    await MongoDataServices.GetInstance.AddData(TModel);
            };

            channel.BasicConsume(Commons.MESSAGE_QUEUE, true, consumer);
        }

       
        public void Produce<T>(T tObject)
        {
            var channel = GetChannel(Util.UriProtocol, Commons.MESSAGE_QUEUE);
            var body = JsonSerializer.SerializeToUtf8Bytes(tObject);

            //Message gets published
            channel.BasicPublish("", Commons.MESSAGE_QUEUE, null, body);
        }


        /// <summary>
        /// This method creates a rabbitMQ channel for processing
        /// </summary>
        /// <returns></returns>
        private IModel GetChannel(string UriProtocol, string targetQueue)
        {
            var connFactory = new ConnectionFactory()
            {
                Uri = new Uri(UriProtocol),
            };

            var connection = connFactory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(queue: targetQueue, durable: true, exclusive: false, autoDelete: false, arguments: null);

            return channel;
        }
    }
}
