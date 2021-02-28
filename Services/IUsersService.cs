using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{   
    public interface IUsersService
    {
        User CreateUser(User user);        
        void DeleteUser(Guid id);
        IEnumerable<User> GetAllUsers();
        User GetUserById(Guid id);
    }
}