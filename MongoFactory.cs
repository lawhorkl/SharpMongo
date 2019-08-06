using System.Collections.Generic;
using MongoDB.Driver;

namespace SharpMongo
{
    public abstract class MongoFactoryBase
    {
        protected IMongoClient _client;
        protected string _databaseName;

        public MongoFactoryBase(IMongoClient client, string databaseName)
        {
            _client = client;
            _databaseName = databaseName;
        }

        public MongoService<TType> GetService<TType>(string databaseName, bool capped = false, List<CreateIndexModel<TType>> indexes = null) where TType : IObjectId =>
            new MongoService<TType>(_client, databaseName, capped, indexes);
    }
}