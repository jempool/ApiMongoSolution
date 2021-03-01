using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Models
{
    public class User
    {
        public User(string id)
        {
            this.Id = id;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }

        [BsonElement("name")]
        public string Name { get; set; }
        
        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        public static User Clone(User source, string id)
        {
            return new User(id) { Name = source.Name, Email = source.Email, Country = source.Country };
        }
    }
}
