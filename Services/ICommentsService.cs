using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{
    public interface ICommentsService
    {
        Comment CreateComment(Comment comment);
        void DeleteComment(string id);
        IEnumerable<Comment> GetAllComments();
        Comment GetCommentById(string id);
    }
}