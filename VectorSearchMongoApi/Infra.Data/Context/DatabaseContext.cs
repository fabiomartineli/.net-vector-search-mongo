using Infra.Data.Mappings;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infra.Data.Context
{

    public class DatabaseContext : IDatabaseContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public DatabaseContext(string connectionString, string database)
        {
            _client = new(connectionString);
            _database = _client.GetDatabase(database, new()
            {
                ReadConcern = ReadConcern.Local,
                WriteConcern = WriteConcern.WMajority,
            });

            MapSerializers();
            MapEntities();
        }

        public IMongoClient Client => _client;
        public IMongoDatabase Database => _database;

        private static void MapEntities()
        {
            MovieMapping.Map();
        }

        private static void MapSerializers()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        }
    }
}
