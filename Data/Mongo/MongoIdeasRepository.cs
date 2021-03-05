using System.Collections.Generic;
using Api.Config;
using Api.Models;
using MongoDB.Driver;

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

        // not only "increase" but "update"
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

        public bool UpdateAverageStars(string id, long newAverageOfStars)
        {
            var updateOp = Builders<Idea>.Update.Set("averageStars", newAverageOfStars);
            var opResult = _ideasCollection.UpdateOne(i => i.Id == id, updateOp);
            return (opResult.ModifiedCount == 1);
        }

        IEnumerable<Idea> IIdeasRepository.GetAllIdeasOfAUser(string userId)
        {
            var ideas = _ideasCollection.Find<Idea>(idea => idea.ProposedBy == userId).ToList();
            return ideas;
        }
    }
}