using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CosmosDbMongoApi.SharedKernel.BaseClasses
{
    public abstract class Entity
    {
        [BsonId]        
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string _Id { get; set; }               
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }
    }
}
