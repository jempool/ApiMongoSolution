using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{   
    public interface IUsersService
    {
        User CreateUser(User user);        
        void DeleteUser(string id);
        IEnumerable<User> GetAllUsers();
        User GetUserById(string id);
        IEnumerable<User> GetUsersByCountry(string country);

        IEnumerable<string> GetAllUniqueCountries();
    }
}