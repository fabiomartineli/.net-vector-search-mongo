using MongoDB.Driver;

namespace Infra.Data.Context
{
    public interface IDatabaseContext
    {
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
    }
}
