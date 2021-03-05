using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Api.Models;
using Api.Services.Exceptions;
using Api.Data;

namespace Api.Services
{
    public class IdeasService : IIdeasService        
    {
        private readonly IIdeasRepository _ideasRepository;

        private readonly ICommentsRepository _commentsRepository;

        private readonly ILogger<IdeasService> _logger;
        public IdeasService(ILogger<IdeasService> logger, IIdeasRepository ideasRepository, ICommentsRepository commentsRepository)
        {
            _logger = logger;
            _logger.LogInformation("Ideas Service was created");
            _ideasRepository = ideasRepository;
            _commentsRepository = commentsRepository;
        }

        IEnumerable<Idea> IIdeasService.GetAllIdeas()
        {
            return _ideasRepository.GetAllIdeas();
        }

        Idea IIdeasService.CreateIdea(Idea idea)        
        {
            var newIdea = _ideasRepository.CreateIdea(idea);
            return newIdea;
        }

        Idea IIdeasService.GetIdeaById(string ideasId)
        {            
            var idea = _ideasRepository.GetIdeaById(ideasId);
            if (idea == null)
            {
                throw new NotFoundException("Cannot find idea");
            }
            return idea;
        }

        void IIdeasService.DeleteIdea(string ideaId)
        {
            if (!_ideasRepository.DeleteIdea(ideaId))
            {
                throw new NotFoundException("Cannot find idea");
            }
        }

        IEnumerable<Idea> IIdeasService.GetAllIdeasOfAUser(string userId)
        {
            var ideas = _ideasRepository.GetAllIdeasOfAUser(userId);
            if (ideas == null)
            {
                throw new NotFoundException("Cannot find user");
            }
            return ideas;
        }

        Idea IIdeasService.GetIdeaByCommentId(string commentId)
        {
            var comment = _commentsRepository.GetCommentById(commentId);
            if (comment == null)
            {
                throw new NotFoundException("Cannot find comment of the idea");
            }

            var idea = _ideasRepository.GetIdeaById(comment.GivenTo);
            if (idea == null)
            {
                throw new NotFoundException("Cannot find idea");
            }
            return idea;
        }
    }
}