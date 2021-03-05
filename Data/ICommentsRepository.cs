using System.Collections.Generic;
using Api.Models;

namespace Api.Data
{
    public interface ICommentsRepository
    {
        Comment CreateComment(Comment comment);

        bool DeleteComment(string ideaId);

        IEnumerable<Comment> GetAllComments();

        Comment GetCommentById(string ideaId);
        
        long GetNewAverageRegardingTheCurrentComment(string ideaId, int currentStars);
                         
        Comment GetCommentGivenAnUserAndAnIdea(string userId, string ideaId);

        IEnumerable<Comment> FindCommentsByIdeaId(string ideaId);

        Comment FindCommentByIdeaIdAndCommentId(string ideaId, string commentId);
    }
}