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
        /// <param name="table"></param>
        /// <returns></returns>
        Task<List<T>> GetAllData<T>(string table);

        /// <summary>
        /// Gets table data by ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<T> GetDataByID<T>(string table, Guid guid);

        /// <summary>
        /// Updates table data 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="tdata"></param>
        /// <returns></returns>
        void UpSertData<T>(string table, Guid guid, T tdata);

        /// <summary>
        /// Method Adds new data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="tdata"></param>
        /// <returns></returns>
        void AddData<T>(string table, T tdata);

        /// <summary>
        /// Deletes table data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        void DeleteData<T>(string table, Guid guid);
    }
}
