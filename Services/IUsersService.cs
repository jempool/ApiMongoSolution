using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{   
    public interface IUsersService
    {
        User CreateUser(User user);

        void DeleteUser(string userId);

        IEnumerable<User> GetAllUsers();

        User GetUserById(string userId);

        IEnumerable<User> GetUsersByCountry(string country);

        IEnumerable<string> GetAllUniqueCountries();

        User FindUserByIdeaId(string ideaId);

        User GetUserByCommentId(string commentId);
    }
}