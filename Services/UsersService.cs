using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Api.Models;
using Api.Services.Exceptions;
using Api.Data;

namespace Api.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;

        private readonly ILogger<UsersService> _logger;

        public UsersService(ILogger<UsersService> logger, IUsersRepository repo)
        {
            _repository = repo;
            _logger = logger;
            _logger.LogInformation("Users Service was created");            
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }

        public User CreateUser(User user)
        {
            var oldUser = _repository.FindUserByEmail(user.Email);
            if (oldUser != null)
            {
                throw new AlreadyExistsException("User with the same email already exists");
            }
            var newUser = _repository.CreateUser(user);
            return newUser;
        }
        
        public User GetUserById(string id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
            {
                throw new NotFoundException("Cannot find user");
            }
            return user;
        }

        public void DeleteUser(string id)
        {
            if (!_repository.DeleteUser(id))
            {
                throw new NotFoundException("Cannot find user");
            }
        }
    }
}