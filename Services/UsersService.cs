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
        private readonly ILogger<UsersService> _logger;
        private readonly IUsersRepository _usersRepository;

        private readonly IIdeasRepository _ideasRepository;

        private readonly ICommentsRepository _commentsRepository;

        private readonly List<string> Countries = new(new string[] 
            { "BELIZE", "COSTA RICA", "EL SALVADOR", "GUATEMALA", "HONDURAS", "MEXICO", "NICARAGUA", "PANAMA", 
              "ARGENTINA", "BOLIVIA", "BRAZIL", "CHILE", "COLOMBIA", "ECUADOR", "GUYANA", "PARAGUAY", "PERU", 
              "URUGUAY", "VENEZUELA", "CUBA", "DOMINICAN REPUBLIC", "HAITI", "PUERTO RICO" }
        );

        public UsersService(ILogger<UsersService> logger, IUsersRepository usersRepository, IIdeasRepository ideasRepository, ICommentsRepository commentsRepository)
        {
            _logger = logger;
            _logger.LogInformation("Users Service was created");            
            _usersRepository = usersRepository;
            _ideasRepository = ideasRepository;
            _commentsRepository = commentsRepository;
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
        
        public User GetUserById(string userId)
        {
            var user = _usersRepository.GetUserById(userId);
            if (user == null)
            {
                throw new NotFoundException("Cannot find user");
            }
            return user;
        }

        public void DeleteUser(string userId)
        {
            if (!_usersRepository.DeleteUser(userId))
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
            var countries = _usersRepository.GetAllUniqueCountries().Distinct();        
            if (countries == null)
            {
                throw new NotFoundException("Cannot find countries");
            }
            
            return countries;
        }

        User IUsersService.FindUserByIdeaId(string ideaId)
        {
            var idea = _ideasRepository.GetIdeaById(ideaId);
            if (idea == null)
            {
                throw new NotFoundException("Cannot find the idea proposed by the user");
            }
                        
            var user = _usersRepository.GetUserById(idea.ProposedBy);
            if (user == null)
            {
                throw new NotFoundException("Cannot find user");
            }

            return user;
        }

        User IUsersService.GetUserByCommentId(string commentId)
        {
            var comment = _commentsRepository.GetCommentById(commentId);
            if (comment == null)
            {
                throw new NotFoundException("Cannot find comment of the user");
            }

            var user = _usersRepository.GetUserById(comment.GivenBy);
            if (user == null)
            {
                throw new NotFoundException("Cannot find user for this comment");
            }

            return user;
        }
    }
}