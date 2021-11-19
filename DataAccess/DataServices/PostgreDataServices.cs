using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataServices
{
    public class PostgreDataServices : IDataServices
    {
        private static readonly PostgreDataServices instance = null;

        public static PostgreDataServices GetInstance
        {
            get
            {
                if (instance == null) return new PostgreDataServices();
                return instance;
            }
        }

        private PostgreDataServices()
        {
          
        }

        public async Task AddData<T>(string table, T tdata)
        {
            throw new NotImplementedException();
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
