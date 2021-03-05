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
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;

        private readonly ICommentsService _commentsService;

        private readonly IIdeasService _ideasService;

        private readonly IUsersService _usersService;

        public CommentsController(ILogger<CommentsController> logger, ICommentsService commentsService, IIdeasService ideasService, IUsersService usersService)
        {
            _logger = logger;
            _logger.LogInformation("Comments Controller was created!");
            _commentsService = commentsService;
            _ideasService = ideasService;
            _usersService = usersService;
        }

        [HttpGet]
        public IEnumerable<Comment> GetAllComments()
        {
            return _commentsService.GetAllComments();
        }

        [HttpPost]
        public ActionResult CreateComment(Comment comment)
        {
            try
            {
                var newComment = _commentsService.CreateComment(comment);
                return Ok(newComment);
            }
            catch (AlreadyExistsException ex)
            {
                return Conflict(new AppError(ex.Message));
            }
        }

        [HttpGet("{commentId}")]
        public ActionResult<Comment> GetCommentById(string commentId)
        {
            try
            {
                return Ok(_commentsService.GetCommentById(commentId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpGet("{commentId}/Ideas")]
        public ActionResult<Comment> GetIdeaByCommentId(string commentId)
        {
            try
            {
                return Ok(_ideasService.GetIdeaByCommentId(commentId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpGet("{commentId}/Users")]
        public ActionResult<Comment> GetUserByCommentId(string commentId)
        {
            try
            {
                return Ok(_usersService.GetUserByCommentId(commentId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpDelete("{commentId}")]
        public ActionResult DeleteComment(string commentId)
        {
            try
            {
                _commentsService.DeleteComment(commentId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }
    }
}
