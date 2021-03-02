using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Models
{
    public class Comment
    {
        public Comment(string id)
        {
            this.Id = id;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }

        [BsonElement("theComment")]
        public string TheComment { get; set; }

        [BsonElement("stars")]
        public int Stars { get; set; }

        [BsonElement("givenBy")]
        public string GivenBy { get; set; }

        [BsonElement("givenTo")]
        public string GivenTo { get; set; }

        public static Comment Clone(Comment source, string id)
        {
            return new Comment(id) { TheComment = source.TheComment, Stars = source.Stars, GivenBy = source.GivenBy };
        }
    }
}
