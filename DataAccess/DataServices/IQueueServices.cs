using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataServices
{
    public interface IQueueServices
    {
        /// <summary>
        /// This method consumes messages inside a queue.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void ConsumeAndSave<T>();

        /// <summary>
        /// This method produces messages to a queue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tObject"></param>
        void Produce<T>(T tObject);
    }
}
