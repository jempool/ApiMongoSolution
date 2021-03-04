using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Api.Models;
using Api.Services.Exceptions;
using Api.Data;

namespace Api.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;

        private readonly IIdeasRepository _ideasRepository;

        private readonly ILogger<CommentsService> _logger;
        public CommentsService(ILogger<CommentsService> logger, ICommentsRepository commentsRepository, IIdeasRepository ideasRepository)
        {
            _commentsRepository = commentsRepository;
            _ideasRepository = ideasRepository;
            _logger = logger;
            _logger.LogInformation("Comments Service was created");
        }

        IEnumerable<Comment> ICommentsService.GetAllComments()
        {
            return _commentsRepository.GetAllComments();
        }

        Comment ICommentsService.CreateComment(Comment comment)
        {   
            // Validate the stars quantity (range 1-5)
            if (comment.Stars < 1 || comment.Stars > 5)
            {
                throw new AlreadyExistsException("The valid star range is between 1 and 5");
            }
            // Validating that it's the only comment for the idea
            var newComment = _commentsRepository.HasThisUserAlreadyCommentedOnThisIdea(comment);
            if(newComment != null){
                throw new AlreadyExistsException("This user has already commented on this idea");
            }

            // Validating that Comment is posted to ideas of a different user.
            var idea = _ideasRepository.GetIdeaById(comment.GivenTo);
            if(idea != null){
                if(comment.GivenBy == idea.ProposedBy){
                    throw new AlreadyExistsException("Comment can only be posted to ideas that were not created by the same user");
                }
            }

            // Increasing +1 the number of Comments in Ideas
            if(idea != null){
                if (!_ideasRepository.IncreaseNumberOfComments(idea.Id))
                {
                    throw new NotFoundException("Cannot find idea");
                }
            }

            // Update the average of stars ---------------------------------------------------------------- 
            if(idea != null){                                
                long newAverageOfStars = _commentsRepository.GetNewAverageRegardingTheCurrentComment(idea.Id, comment.Stars);
                if (!_ideasRepository.UpdateAverageStars(idea.Id, newAverageOfStars))
                {
                    throw new NotFoundException("Cannot find idea");
                }
            }
            // --------------------------------------------------------------------------------------------
            
            newComment = _commentsRepository.CreateComment(comment);
            return newComment;
        }
        
        Comment ICommentsService.GetCommentById(string id)
        {
            var comment = _commentsRepository.GetCommentById(id);
            if (comment == null)
            {
                throw new NotFoundException("Cannot find comment");
            }
            return comment;
        }

        void ICommentsService.DeleteComment(string id)
        {
            if (!_commentsRepository.DeleteComment(id))
            {
                throw new NotFoundException("Cannot find comment");
            }
        }
    }
}