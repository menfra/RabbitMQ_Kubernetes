using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DataAccess
{
    public class QueueServices : IQueueServices
    {
        private readonly string UriProtocol = "amqp://guest:guest@host.docker.internal:5672";

        private static readonly QueueServices instance = null;
        public static QueueServices GetInstance
        {
            get 
            {
                if (instance == null)return new QueueServices();
                return instance;
            }
        }
      
        public T Consume<T>()
        {
            // Channel is created.
            var channel = GetChannel(UriProtocol, Commons.MESSAGE_QUEUE);

            // Instatiate a consumer to consume queue.
            var consumer = new EventingBasicConsumer(channel);
            T TModel = default;

            consumer.Received += (sender, e) =>
            {
                // check null for the event arg
                if (e.Body.ToArray() == null)
                    return;

                var obj = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(e.Body.ToArray()));
                //TModel = (T)obj;
            };

            channel.BasicConsume(Commons.MESSAGE_QUEUE, true, consumer);

            return TModel;
        }

       
        public void Produce<T>(T tObject)
        {
            var channel = GetChannel(UriProtocol, Commons.MESSAGE_QUEUE);
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tObject));

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
