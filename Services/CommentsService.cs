using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;

namespace Api.Services
{
    public class CommentsService : ICommentsService
    {
        private static readonly List<Comment> Comments = new ()
        {
            new Comment("f5469a86-e192-4dd9-a408-906ed3fbc838") { TheComment = "What a cliche", Stars = 4, GivenBy = "ab908249-7cf7-49cf-890e-d1c71cc08d59" },
            new Comment("e2dfb073-b259-4ec6-ad1d-48a5e823fe33") { TheComment = "I disagree", Stars = 1, GivenBy = "93491041-023f-45fe-b61b-461a086fc87b" },
            new Comment("3ccc1887-40e7-48c5-b272-9216991d861f") { TheComment = "It's crazy", Stars = 3, GivenBy = "4586afea-1167-4159-bd14-3cfb3db47bb4" },
        };

        IEnumerable<Comment> ICommentsService.GetAllComments()
        {
            return Comments;
        }

        Comment ICommentsService.CreateComment(Comment comment)
        {
            Comment newComment = new ("Guid.NewGuid()") { TheComment = comment.TheComment, Stars = comment.Stars, GivenBy = comment.GivenBy };
            Comments.Add(newComment);
            return newComment;
        }
        
        Comment ICommentsService.GetCommentById(string id)
        {
            var comment = Comments.FirstOrDefault(comment => comment.Id == id);
            if (comment == null)
            {
                throw new NotFoundException("Cannot find comment");                
            }
            return comment;
        }

        void ICommentsService.DeleteComment(string id)
        {
            var commentToDelete = Comments.FirstOrDefault(comment => comment.Id == id);
            if (commentToDelete != null)
            {
            _ = Comments.Remove(commentToDelete);
            }
            else
            {
                throw new NotFoundException("Cannont find comment");
            }
        }
    }
}