using DataAccess.Env;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataServices
{
    public class MongoDataServices : IDataServices
    {
        private static readonly MongoDataServices instance = null;
        private IMongoDatabase db;
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
            //var client = new MongoClient(Util.ConnectionString);
            var client = new MongoClient(new MongoClientSettings
            {
                Credential = new MongoCredential(Util.AuthMechanism, new MongoInternalIdentity(Util.DBName, Util.UserName), new PasswordEvidence(Util.PasswordEvidence)),
                Server = new MongoServerAddress(Util.MongoServer, Util.MongoPort)
            });

            db = client.GetDatabase(Commons.DBName);
        }

        public async void DeleteData<T>(string table, Guid guid)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", guid);

            await collection.DeleteOneAsync(filter);
        }

        public async Task<List<T>> GetAllData<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return (await collection.FindAsync(new BsonDocument())).ToList();
        }

        public async Task<T> GetDataByID<T>(string table, Guid guid)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", guid);

            return (await collection.FindAsync(filter)).FirstOrDefault();
        }

        public void UpSertData<T>(string table, Guid guid, T tdata)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", guid);
            collection.ReplaceOne(filter, tdata, new ReplaceOptions { IsUpsert = true });
        }

        public void AddData<T>(string table, T tdata)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(tdata);
        }
    }
}
