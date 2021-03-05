using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{
    public interface ICommentsService
    {
        Comment CreateComment(Comment comment);

        void DeleteComment(string commentId);

        IEnumerable<Comment> GetAllComments();

        Comment GetCommentById(string commentId);

        Comment GetCommentGivenAnUserAndAnIdea(string userId, string ideaId);

        IEnumerable<Comment> FindCommentsByIdeaId(string ideaId);

        Comment FindCommentByIdeaIdAndCommentId(string ideaId, string commentId);
    }
}