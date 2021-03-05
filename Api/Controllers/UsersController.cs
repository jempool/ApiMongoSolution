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
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _usersService;
        private readonly IIdeasService _ideasService;

        private readonly ICommentsService _commentsService;

        public UsersController(ILogger<UsersController> logger, IUsersService userService, IIdeasService ideasService, ICommentsService commentsService)
        {
            _logger = logger;
            _logger.LogInformation("Users Controller was created!");
            _usersService = userService;
            _ideasService = ideasService;
            _commentsService = commentsService;
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _usersService.GetAllUsers();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            try
            {
                var newUser = _usersService.CreateUser(user);
                return Ok(newUser);
            }
            catch (AlreadyExistsException ex)
            {
                return Conflict(new AppError(ex.Message));
            }
        }

        [HttpGet("{userId}")]
        public ActionResult<User> GetUserById(string userId)
        {
            try
            {
                return Ok(_usersService.GetUserById(userId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpGet("{userId}/Ideas")]
        public ActionResult<User> GetAllIdeasOfAUser(string userId)
        {
            try
            {
                return Ok(_ideasService.GetAllIdeasOfAUser(userId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpGet("{userId}/Ideas/{ideaId}/Comments")]
        public ActionResult<Comment> GetCommentGivenAnUserAndAnIdea(string userId, string ideaId)
        {
            try
            {
                return Ok(_commentsService.GetCommentGivenAnUserAndAnIdea(userId, ideaId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser(string userId)
        {
            try
            {
                _usersService.DeleteUser(userId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }
    }
}
