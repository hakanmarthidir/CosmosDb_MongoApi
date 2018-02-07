using System.Configuration;
using System.Security.Authentication;
using MongoDB.Driver;

namespace CosmosDbMongoApi.InfrastructureLayer.Context
{
    public class MongoContext : IMongoContext
    {        
        public MongoContext()
        {
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            MongoClientSettings settings = MongoClientSettings.FromUrl(url);
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var client = new MongoClient(settings);
            Database = client.GetDatabase(url.DatabaseName);            
        }
        public IMongoDatabase Database { get; set ; }
    } 
}
