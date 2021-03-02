using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Api.Models;
using Api.Services.Exceptions;
using Api.Data;
using System.Linq;

namespace Api.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        private readonly ILogger<UsersService> _logger;

        private readonly List<string> Countries = new(new string[] 
            { "BELIZE", "COSTA RICA", "EL SALVADOR", "GUATEMALA", "HONDURAS", "MEXICO", "NICARAGUA", "PANAMA", 
              "ARGENTINA", "BOLIVIA", "BRAZIL", "CHILE", "COLOMBIA", "ECUADOR", "GUYANA", "PARAGUAY", "PERU", 
              "URUGUAY", "VENEZUELA", "CUBA", "DOMINICAN REPUBLIC", "HAITI", "PUERTO RICO" }
        );

        public UsersService(ILogger<UsersService> logger, IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _logger = logger;
            _logger.LogInformation("Users Service was created");
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _usersRepository.GetAllUsers();
        }

        public User CreateUser(User user)        
        {
            //Validating country
            var match = Countries.FirstOrDefault(country => country.Contains(user.Country));
            if(match == null)
            {
                throw new AlreadyExistsException("Is not a latin american country or is not capitalized");
            }

            try {
                var addr = new System.Net.Mail.MailAddress(user.Email);
                bool isValidEmail = addr.Address == user.Email;
            }
            catch {
                throw new AlreadyExistsException("Invalid email address");
            }

            //Validating if Email exists
            var oldUser = _usersRepository.FindUserByEmail(user.Email);
            if (oldUser != null)
            {
                throw new AlreadyExistsException("User with the same email already exists");
            }
            var newUser = _usersRepository.CreateUser(user);
            return newUser;
        }
        
        public User GetUserById(string id)
        {
            var user = _usersRepository.GetUserById(id);
            if (user == null)
            {
                throw new NotFoundException("Cannot find user");
            }
            return user;
        }

        public void DeleteUser(string id)
        {
            if (!_usersRepository.DeleteUser(id))
            {
                throw new NotFoundException("Cannot find user");
            }
        }

        IEnumerable<User> IUsersService.GetUsersByCountry(string country)
        {
            var users = _usersRepository.GetUsersByCountry(country);
            if (users == null)
            {
                throw new NotFoundException("Cannot find user");
            }
            return users;
        }

        IEnumerable<string> IUsersService.GetAllUniqueCountries()
        {
        var users = _usersRepository.GetAllUsers();
        List<string> countries = new();

        foreach (User user in users)
        {
            if(_usersRepository.GetUsersByCountry(user.Country).Count() == 1)
            {
                countries.Add(user.Country);
            }
        }
            return countries;
        }
    }
}