using DataAccess.DataContext;
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
        }

        public async Task DeleteData<T>(Guid guid)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
