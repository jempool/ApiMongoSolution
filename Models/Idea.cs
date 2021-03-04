using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Models
{
    public class Idea
    {
        public Idea(string id)
        {
            this.Id = id;
            this.Comments = 0;
            this.AverageStars = 0;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get;  private set; }
        
        [BsonElement("detail")]
        public string Detail { get; set; }

        [BsonElement("comments")]
        public int Comments { get; private set; }

        [BsonElement("averageStars")]
        public long AverageStars { get; private set; }

        [BsonElement("proposedBy")]
        public string ProposedBy { get; set; }

        public static Idea Clone(Idea source, string id)
        {
            return new Idea(id) { Detail = source.Detail, Comments = source.Comments, AverageStars = source.AverageStars, ProposedBy = source.ProposedBy };
        }
    }
}
