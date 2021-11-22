using DataAccess.DataContext;
using DataAccess.Env;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DataServices
{
    public class PostgresDataServices : IDataServices
    {
        private static readonly PostgresDataServices instance = null;
        private readonly NpgsqlConnection conn = null;
        public static ProducerDataContext DBContext { get; set; }

        public static PostgresDataServices GetInstance
        {
            get
            {
                if (instance == null) return new PostgresDataServices();
                return instance;
            }
        }

        private PostgresDataServices()
        {
            conn = new NpgsqlConnection(Util.PostgresConnectionString);
        }

        public async Task AddData<T>(T tdata)
        {
            await DBContext.AddAsync(tdata);
            await DBContext.SaveChangesAsync();
        }

        public async Task DeleteData<T>(Guid guid)
        {
            //var entityToDelete = await DBContext(guid);
            //if (entityToDelete == null)
            //{
            //    return false;
            //}
            //var result = Delete(entityToDelete);

            //return result;
        }

        public async Task<List<T>> GetAllData<T>()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetDataByID<T>(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task UpSertData<T>(Guid guid, T tdata)
        {
            if (tdata == null)
            {
                return;
            }
            DBContext.Entry(tdata).State = EntityState.Modified;
            await DBContext.SaveChangesAsync();
        }
    }
}
