using System;
using MongoDB.Driver;
using Extensao.Shared;

namespace Extensao.Infra.Data.DataContexts
{
    public class MongoDBDataContext : IDisposable
    {
        public MongoClient Connection { get; private set; }
        public IMongoDatabase Database { get; private set; }

        public MongoDBDataContext()
        {
            Connection = new MongoClient(Settings.MongoDBConnectionString);
            Database = Connection.GetDatabase(Settings.MongoDBDataBase);
        }

        public void Dispose()
        {
        }
    }
}
