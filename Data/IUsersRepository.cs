using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Data
{   
    public interface IUsersRepository
    {
        User CreateUser(User user);  

        bool DeleteUser(string userId);

        IEnumerable<User> GetAllUsers();

        User GetUserById(string userId);

        User FindUserByEmail(string email);

        IEnumerable<User> GetUsersByCountry(string country);

        IEnumerable<string> GetAllUniqueCountries();
    }
}