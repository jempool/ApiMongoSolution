using System;

namespace Api.Models
{
    public class Comment
    {
        public Comment(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }

        public string TheComment { get; set; }

        public int Stars { get; set; }

        public Guid GivenBy { get; set; }

        public static Comment Clone(Comment source, Guid id)
        {
            return new Comment(id) { TheComment = source.TheComment, Stars = source.Stars, GivenBy = source.GivenBy };
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
