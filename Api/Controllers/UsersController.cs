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

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(string id)
        {
            try
            {
                return Ok(_usersService.GetUserById(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
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
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpGet("/Users/Countries/{country}")]
        public ActionResult<IEnumerable<User>> GetUsersByCountry(string country)
        {
            try
            {
                return Ok(_usersService.GetUsersByCountry(country));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpGet("/Users/Countries")]
        public ActionResult GetAllUniqueCountries()
        {
            try
            {
                return Ok(_usersService.GetAllUniqueCountries());
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }
    }
}
