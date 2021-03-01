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
        private readonly IIdeasRepository _repository;

        private readonly ILogger<IdeasService> _logger;
        public IdeasService(ILogger<IdeasService> logger, IIdeasRepository repo)
        {
            _repository = repo;
            _logger = logger;
            _logger.LogInformation("Ideas Service was created");
        }

        IEnumerable<Idea> IIdeasService.GetAllIdeas()
        {
            return _repository.GetAllIdeas();
        }

        Idea IIdeasService.CreateIdea(Idea idea)        
        {
            var newIdea = _repository.CreateIdea(idea);
            return newIdea;
        }

        Idea IIdeasService.GetIdeaById(string id)
        {            
            var idea = _repository.GetIdeaById(id);
            if (idea == null)
            {
                throw new NotFoundException("Cannot find idea");
            }
            return idea;
        }

        void IIdeasService.DeleteIdea(string id)
        {
            if (!_repository.DeleteIdea(id))
            {
                throw new NotFoundException("Cannot find idea");
            }
        }
    }
}