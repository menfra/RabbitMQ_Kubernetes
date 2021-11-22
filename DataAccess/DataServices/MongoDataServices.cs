using DataAccess.Env;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.DataServices
{
    public class MongoDataServices : IDataServices
    {
        private static readonly MongoDataServices instance = null;
        private readonly IMongoDatabase db;
        public static MongoDataServices GetInstance
        {
            get
            {
                if (instance == null) return new MongoDataServices();
                return instance;
            }
        }

        private MongoDataServices()
        {
            var client = new MongoClient(Util.MongoConnectionString);

            db = client.GetDatabase(Commons.DBName);
        }

        public async Task DeleteData<T>(Guid guid)
        {
            var collection = db.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("Id", guid);

            await collection.DeleteOneAsync(filter);
        }

        public async Task<List<T>> GetAllData<T>()
        {
            var collection = db.GetCollection<T>(typeof(T).Name);
            return (await collection.FindAsync(new BsonDocument())).ToList();
        }

        public async Task<T> GetDataByID<T>(Guid guid)
        {
            var collection = db.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("Id", guid);

            return (await collection.FindAsync(filter)).FirstOrDefault();
        }

        public async Task UpSertData<T>(Guid guid, T tdata)
        {
            var collection = db.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("Id", guid);
            await collection.ReplaceOneAsync(filter, tdata, new ReplaceOptions { IsUpsert = true });
        }

        public async Task AddData<T>(T tdata)
        {
            var name = typeof(T).Name;
            var collection = db.GetCollection<T>(typeof(T).Name);
            await collection.InsertOneAsync(tdata);
        }
    }
}
