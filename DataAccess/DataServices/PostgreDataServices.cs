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

        public void AddData<T>(string table, T tdata)
        {
            throw new NotImplementedException();
        }

        public void DeleteData<T>(string table, Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllData<T>(string table)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetDataByID<T>(string table, Guid guid)
        {
            throw new NotImplementedException();
        }

        public void UpSertData<T>(string table, Guid guid, T tdata)
        {
            throw new NotImplementedException();
        }
    }
}
