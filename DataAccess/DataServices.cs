using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataServices : IDataServices
    {
        private static readonly DataServices instance = null;
        public static DataServices GetInstance
        {
            get
            {
                if (instance == null) return new DataServices();
                return instance;
            }
        }

        public Task<bool> DeleteData<T>(string table, Guid guid)
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

        public Task<T> UpdateData<T>(string table, T tdata)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddData<T>(string table, T tdata)
        {
            throw new NotImplementedException();
        }
    }
}
