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

        private readonly IUsersService _usersService;

        private readonly ICommentsService _commentsServices;

        public IdeasController(ILogger<IdeasController> logger, IIdeasService ideasService, IUsersService usersService, ICommentsService commentsServices)
        {
            _logger = logger;
            _logger.LogInformation("Ideas Controller was created!");
            _ideasService = ideasService;
            _usersService = usersService;
            _commentsServices = commentsServices;
        }

        [HttpGet]
        public IEnumerable<Idea> GetAllIdeas()
        {
            return _ideasService.GetAllIdeas();
        }

        [HttpPost]
        public ActionResult CreateIdea(Idea ideaId)
        {
            try
            {
                var newIdea = _ideasService.CreateIdea(ideaId);
                return Ok(newIdea);
            }
            catch (AlreadyExistsException ex)
            {
                return Conflict(new AppError(ex.Message));
            }
        }

        [HttpGet("{ideaId}")]
        public ActionResult<Idea> GetIdeaById(string ideaId)
        {
            try
            {
                return Ok(_ideasService.GetIdeaById(ideaId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpGet("{ideaId}/Users")]
        public ActionResult<User> FindUserByIdeaId(string ideaId)
        {
            try
            {
                return Ok(_usersService.FindUserByIdeaId(ideaId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpGet("{ideaId}/Comments")]
        public ActionResult<Comment> FindCommentsByIdeaId(string ideaId)
        {
            try
            {
                return Ok(_commentsServices.FindCommentsByIdeaId(ideaId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpGet("{ideaId}/Comments/{commentId}")]
        public ActionResult<Comment> FindCommentByIdeaIdAndCommentId(string ideaId, string commentId)
        {
            try
            {
                return Ok(_commentsServices.FindCommentByIdeaIdAndCommentId(ideaId, commentId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpDelete("{ideaId}")]
        public ActionResult DeleteIdea(string ideaId)
        {
            try
            {
                _ideasService.DeleteIdea(ideaId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }
    }
}
