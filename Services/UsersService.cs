using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;

namespace Api.Services
{
    public class UsersService : IUsersService
    {
        private static readonly List<User> Users = new ()
        {
            new User(Guid.Parse("ab908249-7cf7-49cf-890e-d1c71cc08d59")) { Name = "Jem Suarez", Email = "jem@mail.com", Country = "COLOMBIA" },
            new User(Guid.Parse("93491041-023f-45fe-b61b-461a086fc87b")) { Name = "Carlos Perez", Email = "carlos@mail.com", Country = "BOLIVIA" },
            new User(Guid.Parse("4586afea-1167-4159-bd14-3cfb3db47bb4")) { Name = "Diana Sanchez", Email = "diana@mail.com", Country = "CHILE" },
        };
        
        public IEnumerable<User> GetAllUsers()
        {
            return Users;
        }

        public User CreateUser(User user)
        {
            User newUser = new (Guid.NewGuid()) { Name = user.Name, Email = user.Email, Country = user.Country };
            Users.Add(newUser);
            return newUser;
        }
        
        public User GetUserById(Guid id)
        {
            var user = Users.FirstOrDefault(user => user.Id == id);
            if (user == null)
            {
                throw new NotFoundException("Cannot find game");
            }
            return user;
        }

        public void DeleteUser(Guid id)
        {
            var userToDelete = Users.FirstOrDefault(user => user.Id == id);
            if (userToDelete != null)
            {
            _ = Users.Remove(userToDelete);
            } 
            else 
            {
                throw new NotFoundException("Cannot find game");
            }
        }
    }
}