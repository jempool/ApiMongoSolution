using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Data
{
    public interface ICommentsRepository
    {
        Comment CreateComment(Comment comment);

        bool DeleteComment(string id);

        IEnumerable<Comment> GetAllComments();

        Comment GetCommentById(string id);

        Comment HasThisUserAlreadyCommentedOnThisIdea(Comment comment);
        
        long GetNewAverageRegardingTheCurrentComment(string ideaId, int currentStars);        

    }
}