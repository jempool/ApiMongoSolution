using System;

namespace Api.Models
{
    public class Comment
    {
        public Comment(string id)
        {
            this.Id = id;
        }

        public string Id { get; }

        public string TheComment { get; set; }

        public int Stars { get; set; }

        public string GivenBy { get; set; }

        public static Comment Clone(Comment source, string id)
        {
            return new Comment(id) { TheComment = source.TheComment, Stars = source.Stars, GivenBy = source.GivenBy };
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
