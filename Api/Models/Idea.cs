using System;

namespace Api.Models
{
    public class Idea
    {
        public Idea(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }

        public string Detail { get; set; }

        public int Comments { get; set; }

        public int AverageStars { get; set; }

        public Guid ProposedBy { get; set; }

        public static Idea Clone(Idea source, Guid id)
        {
            return new Idea(id) { Detail = source.Detail, Comments = source.Comments, AverageStars = source.AverageStars, ProposedBy = source.ProposedBy };
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
