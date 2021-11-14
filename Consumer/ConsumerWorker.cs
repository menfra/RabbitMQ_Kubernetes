using DataAccess;
using DataAccess.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer
{
    public class ConsumerWorker
    {
        public ConsumerWorker()
        {
            IQueueServices queueServices = new QueueServices();
            var user = queueServices.Consume<User>();


            if (user != null)
                DataServices.GetInstance.AddData("", user);
        }
    }
}
