using DataAccess.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataModels
{
    class GasNetWork : INetWork
    {

        [BsonId]
        ///<summary>The Id of the data object</summary>
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string GasType { get; set; }
    }
}
