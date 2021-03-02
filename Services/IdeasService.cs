using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Api.Models;
using Api.Services.Exceptions;
using Api.Data;
using System.Linq;

namespace Api.Services
{
    public class IdeasService : IIdeasService        
    {
        private readonly IIdeasRepository _ideasRepository;

        private readonly ILogger<IdeasService> _logger;
        public IdeasService(ILogger<IdeasService> logger, IIdeasRepository ideasRepository)
        {
            _ideasRepository = ideasRepository;
            _logger = logger;
            _logger.LogInformation("Ideas Service was created");
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

        Idea IIdeasService.GetIdeaById(string id)
        {            
            var idea = _ideasRepository.GetIdeaById(id);
            if (idea == null)
            {
                throw new NotFoundException("Cannot find idea");
            }
            return idea;
        }

        void IIdeasService.DeleteIdea(string id)
        {
            if (!_ideasRepository.DeleteIdea(id))
            {
                throw new NotFoundException("Cannot find idea");
            }
        }
    }
}