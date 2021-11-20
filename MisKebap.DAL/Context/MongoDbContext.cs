using System;
using Microsoft.Extensions.Options;
using MisKebap.DAL.Entities;
using MongoDB.Driver;

namespace MisKebap.DAL.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDbContext(IOptions<MongoOptions> mongoOptions)
        {
            var mongoClient = new MongoClient("mongodb://root:mismongo@134.122.108.244:27017");
            _mongoDatabase = mongoClient.GetDatabase(mongoOptions.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _mongoDatabase.GetCollection<T>(typeof(T).Name);
        }

        public IMongoDatabase GetDatabase()
        {
            return _mongoDatabase;
        }
    }
}
