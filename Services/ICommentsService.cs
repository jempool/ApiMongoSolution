using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{
    public interface ICommentsService
    {
        Comment CreateComment(Comment comment);
        void DeleteComment(Guid id);
        IEnumerable<Comment> GetAllComments();
        Comment GetCommentById(Guid id);
    }
}