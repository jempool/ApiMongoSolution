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
    }
}