
using MongoDB.Driver;

namespace CosmosDbMongoApi.InfrastructureLayer.Context
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; set; }       
    }
}
