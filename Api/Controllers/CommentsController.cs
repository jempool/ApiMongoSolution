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
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;

        private readonly ICommentsService _commentsService;

        public CommentsController(ILogger<CommentsController> logger, ICommentsService service)
        {
            _logger = logger;
            _logger.LogInformation("Comments Controller was created!");
            _commentsService = service;
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

        [HttpGet("{id}")]
        public ActionResult<Comment> GetCommentById(string id)
        {
            try
            {
                return Ok(_commentsService.GetCommentById(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteComment(string id)
        {
            try
            {
                _commentsService.DeleteComment(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }
    }
}
