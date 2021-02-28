using System;

namespace Api.Models
{
    public class User
    {
        public User(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public static User Clone(User source, Guid id)
        {
            return new User(id) { Name = source.Name, Email = source.Email, Country = source.Country };
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
