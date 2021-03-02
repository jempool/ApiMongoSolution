using System.Collections.Generic;
using Api.Config;
using Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Api.Data.Mongo
{
    public class MongoIdeasRepository : IIdeasRepository
    {
        private readonly IMongoCollection<Idea> _ideasCollection;

        public MongoIdeasRepository(IMongoSettings settings)
        {
            var mongoClient = new MongoClient(settings.Server);
            var db = mongoClient.GetDatabase(settings.Database);
            _ideasCollection = db.GetCollection<Idea>("ideas");
        }

        Idea IIdeasRepository.CreateIdea(Idea idea)
        {
            _ideasCollection.InsertOne(idea);
            return idea;   
        }

        bool IIdeasRepository.DeleteIdea(string id)
        {
            var result = _ideasCollection.DeleteOne(g => g.Id == id);
            return (result.DeletedCount == 1);     
        }

        IEnumerable<Idea> IIdeasRepository.GetAllIdeas()
        {            
            return _ideasCollection.Find<Idea>(idea => true).ToList();
        }

        Idea IIdeasRepository.GetIdeaById(string id)
        {
            return _ideasCollection.Find<Idea>(idea => (idea.Id == id)).FirstOrDefault();
        }

        public bool IncreaseNumberOfComments(string id)
        {
            var idea = _ideasCollection.Find<Idea>(idea => (idea.Id == id)).FirstOrDefault();
            
            if(idea != null)
            {
                var updateOp = Builders<Idea>.Update.Set("comments", idea.Comments + 1);
                var opResult = _ideasCollection.UpdateOne(i => i.Id == id, updateOp);
                return (opResult.ModifiedCount == 1);
            }
            else 
            {
                return false;
            }
        }

        public bool UpdateAverageStars(string id, int stars)
        {
            var updateOp = Builders<Idea>.Update.Set("averageStars", stars);
            var opResult = _ideasCollection.UpdateOne(i => i.Id == id, updateOp);
            return (opResult.ModifiedCount == 1);
        }
    }
}