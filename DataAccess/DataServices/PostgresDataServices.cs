using DataAccess.Env;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DataServices
{
    public class PostgresDataServices : IDataServices
    {
        private static readonly PostgresDataServices instance = null;
        private readonly NpgsqlConnection connection;

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
            connection = new NpgsqlConnection(Util.PostgresConnectionString);
        }

        public async Task AddData<T>(string table, T tdata)
        {
            
        }

        public async Task DeleteData<T>(string table, Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllData<T>(string table)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetDataByID<T>(string table, Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task UpSertData<T>(string table, Guid guid, T tdata)
        {
            throw new NotImplementedException();
        }
    }
}
