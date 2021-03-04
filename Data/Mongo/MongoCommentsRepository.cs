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
            var moreThanOneComment = _commentsCollection.Find<Comment>(Comment => (Comment.GivenBy == comment.GivenBy)).FirstOrDefault();
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

        Comment ICommentsRepository.HasThisUserAlreadyCommentedOnThisIdea(Comment comment)
        {            
            return _commentsCollection.Find<Comment>(Comment => (Comment.GivenBy == comment.GivenBy) && (Comment.GivenTo == comment.GivenTo) ).FirstOrDefault();
        }

        long ICommentsRepository.GetNewAverageRegardingTheCurrentComment(string ideaId, int currentStars)
        {
            var comments = _commentsCollection.Find<Comment>(comment => comment.GivenTo == ideaId).ToList();
            var totalNumberOfComments = comments.Count;
            long totalNumberOfStars = 0;
            foreach (var comment in comments)
            {
                totalNumberOfStars += comment.Stars;
            }
            // adding the current number of stars and the current comment
            var newAverage = (totalNumberOfStars + currentStars) / (totalNumberOfComments + 1);

            return newAverage;
        }
    }
}