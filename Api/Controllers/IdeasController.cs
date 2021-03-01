using System;
using System.Collections.Generic;
using Api.Models;
using Api.Services;
using Api.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdeasController : ControllerBase
    {
        private readonly ILogger<IdeasController> _logger;

        private readonly IIdeasService _ideasService;

        public IdeasController(ILogger<IdeasController> logger, IIdeasService service)
        {
            _logger = logger;
            _logger.LogInformation("Ideas Controller was created!");
            _ideasService = service;
        }

        [HttpGet]
        public IEnumerable<Idea> GetAllIdeas()
        {
            return _ideasService.GetAllIdeas();
        }

        [HttpPost]
        public Idea CreateIdea(Idea idea)
        {
            var newIdea = _ideasService.CreateIdea(idea);
            return newIdea;
        }

        [HttpGet("{id}")]
        public ActionResult<Idea> GetIdeaById(string id)
        {
            try
            {
                return _ideasService.GetIdeaById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteIdea(string id)
        {
            try
            {
                _ideasService.DeleteIdea(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
