using System;
using MongoDB.Driver;

namespace MisKebap.DAL.Context
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>();

        IMongoDatabase GetDatabase();
    }
}
