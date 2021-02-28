using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
            private static readonly List<Comment> Comments = new ()
            {
                new Comment(Guid.Parse("f5469a86-e192-4dd9-a408-906ed3fbc838")) { TheComment = "What a cliche", Stars = 4, GivenBy = Guid.Parse("ab908249-7cf7-49cf-890e-d1c71cc08d59") },
                new Comment(Guid.Parse("e2dfb073-b259-4ec6-ad1d-48a5e823fe33")) { TheComment = "I disagree", Stars = 1, GivenBy = Guid.Parse("93491041-023f-45fe-b61b-461a086fc87b") },
                new Comment(Guid.Parse("3ccc1887-40e7-48c5-b272-9216991d861f")) { TheComment = "It's crazy", Stars = 3, GivenBy = Guid.Parse("4586afea-1167-4159-bd14-3cfb3db47bb4") },
            };

            private readonly ILogger<CommentsController> _logger;

            public CommentsController(ILogger<CommentsController> logger)
            {
                _logger = logger;
            }

            [HttpGet]
            public IEnumerable<Comment> GetAllComments()
            {
                return Comments;
            }

            [HttpGet("{id}")]
            public Comment GetCommentById(Guid id)
            {
                return Comments.FirstOrDefault(comment => comment.Id == id);
            }

            [HttpPost]
            public Comment CreateComment(Comment comment)
            {
                Comment newComment = new (Guid.NewGuid()) { TheComment = comment.TheComment, Stars = comment.Stars, GivenBy = comment.GivenBy };
                Comments.Add(newComment);
                return newComment;
            }

            [HttpDelete("{id}")]
            public void DeleteComment(Guid id)
            {
                var commentToDelete = Comments.FirstOrDefault(comment => comment.Id == id);
                if (commentToDelete != null)
                {
                _ = Comments.Remove(commentToDelete);
                }
            }
    }
}
