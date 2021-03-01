using System;
using System.Collections.Generic;
using Api.Models;
using Api.Config;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Api.Data.Mongo
{
    public class MongoCommentsRepository : ICommentsRepository
    {
        private readonly IMongoCollection<Comment> _commentsCollection;

        public MongoCommentsRepository(IMongoSettings settings)
        {
            var mongoClient = new MongoClient(settings.Server);
            var db = mongoClient.GetDatabase(settings.Database);
            _commentsCollection = db.GetCollection<Comment>("comments");            
        }

        Comment ICommentsRepository.CreateComment(Comment comment)
        {
            _commentsCollection.InsertOne(comment);
            return comment;   
        }

        bool ICommentsRepository.DeleteComment(string id)
        {
            var opResult = _commentsCollection.DeleteOne(g => g.Id == id);
            return (opResult.DeletedCount == 1);      
        }

        IEnumerable<Comment> ICommentsRepository.GetAllComments()
        {
            return _commentsCollection.Find<Comment>(comment => true).ToList();
        }

        Comment ICommentsRepository.GetCommentById(string id)
        {
             return _commentsCollection.Find<Comment>(comment => (comment.Id == id)).FirstOrDefault();
        }
    }
}