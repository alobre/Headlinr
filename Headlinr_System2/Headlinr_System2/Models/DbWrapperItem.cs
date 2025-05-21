using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Headlinr_System2.Models
{
    public class DbWrapperItem 
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; } = string.Empty;

        public DTOs.Output.Item Item { get; set; } = new();
    }
}
