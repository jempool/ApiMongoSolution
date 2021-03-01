using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Api.Models;
using Api.Services.Exceptions;
using Api.Data;

namespace Api.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _repository;

        private readonly ILogger<CommentsService> _logger;
        public CommentsService(ILogger<CommentsService> logger, ICommentsRepository repo)
        {
            _repository = repo;
            _logger = logger;
            _logger.LogInformation("Comments Service was created");
        }

        IEnumerable<Comment> ICommentsService.GetAllComments()
        {
            return _repository.GetAllComments();
        }

        Comment ICommentsService.CreateComment(Comment comment)
        {   
            // Validate the stars quantity (range 1-5)
            if (comment.Stars < 1 || comment.Stars > 5)
            {
                throw new AlreadyExistsException("The valid star range is between 1 and 5");
            }
            var newComment = _repository.CreateComment(comment);
            return newComment;
        }
        
        Comment ICommentsService.GetCommentById(string id)
        {
            var comment = _repository.GetCommentById(id);
            if (comment == null)
            {
                throw new NotFoundException("Cannot find comment");
            }
            return comment;
        }

        void ICommentsService.DeleteComment(string id)
        {
            if (!_repository.DeleteComment(id))
            {
                throw new NotFoundException("Cannot find comment");
            }
        }
    }
}