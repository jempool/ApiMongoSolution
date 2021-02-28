using System;
using System.Collections.Generic;
using Api.Models;
using Api.Services;
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

        public UsersController(ILogger<UsersController> logger, IUsersService service)
        {
            _logger = logger;
            _logger.LogInformation("Users Controller was created!");
            _usersService = service;
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _usersService.GetAllUsers();
        }

        [HttpPost]
        public User CreateUser(User user)
        {
            var newUser = _usersService.CreateUser(user);
            return newUser;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(string id)
        {
            try
            {
                return _usersService.GetUserById(id);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(string id)
        {
            try
            {
                _usersService.DeleteUser(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
