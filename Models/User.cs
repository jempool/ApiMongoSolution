using System;

namespace Api.Models
{
    public class User
    {
        public User(string id)
        {
            this.Id = id;
        }

        public string Id { get; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public static User Clone(User source, string id)
        {
            return new User(id) { Name = source.Name, Email = source.Email, Country = source.Country };
        }
    }
}
