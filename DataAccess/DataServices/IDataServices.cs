using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataServices
{
    interface IDataServices
    {
        /// <summary>
        /// Gets all data from DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<List<T>> GetAllData<T>();

        /// <summary>
        /// Gets table data by ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<T> GetDataByID<T>(Guid guid);

        /// <summary>
        /// Updates table data 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tdata"></param>
        /// <returns></returns>
        Task UpSertData<T>(Guid guid, T tdata);

        /// <summary>
        /// Method Adds new data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tdata"></param>
        /// <returns></returns>
        Task AddData<T>(T tdata);

        /// <summary>
        /// Deletes table data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task DeleteData<T>(Guid guid);
    }
}
