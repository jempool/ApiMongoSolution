using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Data
{
    public interface ICommentsRepository
    {
        Comment CreateComment(Comment comment);
        void DeleteComment(Guid id);
        IEnumerable<Comment> GetAllComments();
        Comment GetCommentById(Guid id);
    }
}