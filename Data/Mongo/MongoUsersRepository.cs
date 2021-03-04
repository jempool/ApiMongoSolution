using System;
using System.Collections.Generic;
using Api.Models;
using Api.Config;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;


namespace Api.Data.Mongo
{
    public class MongoUsersRepository : IUsersRepository
    {
        private readonly IMongoCollection<User> _usersCollection;

        public MongoUsersRepository(IMongoSettings settings)
        {
            var mongoClient = new MongoClient(settings.Server);
            var db = mongoClient.GetDatabase(settings.Database);
            _usersCollection = db.GetCollection<User>("users");
        }

        IEnumerable<User> IUsersRepository.GetAllUsers()
        {
            return _usersCollection.Find<User>(user => true).ToList();
        }

        User IUsersRepository.CreateUser(User user)
        {
            _usersCollection.InsertOne(user);
            return user;
        }

        User IUsersRepository.GetUserById(string id)
        {       
            return _usersCollection.Find<User>(user => user.Id == id).FirstOrDefault();     
        }

        bool IUsersRepository.DeleteUser(string id)
        {
            var result = _usersCollection.DeleteOne(g => g.Id == id);
            return (result.DeletedCount == 1);            
        }

        User IUsersRepository.FindUserByEmail(string email)
        {
            return _usersCollection.Find<User>(user => (user.Email == email)).FirstOrDefault();
        }

        IEnumerable<User> IUsersRepository.GetUsersByCountry(string country)
        {
            return _usersCollection.Find<User>(user => (user.Country == country)).ToList();
        }

        IEnumerable<string> IUsersRepository.GetAllUniqueCountries()
        {
            var usersForUniqueCountries = _usersCollection.Find<User>(user => true).ToList();                    
            var uniqueCountries = new List<string>();
            foreach (var user in usersForUniqueCountries)
            {
                uniqueCountries.Add(user.Country);
            }

            return uniqueCountries;
        }
    }
}