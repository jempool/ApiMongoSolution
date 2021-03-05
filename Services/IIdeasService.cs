using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{   
       public interface IIdeasService
    {
        Idea CreateIdea(Idea ideaId);

        void DeleteIdea(string ideaId);

        IEnumerable<Idea> GetAllIdeas();

        Idea GetIdeaById(string ideaId);

        IEnumerable<Idea> GetAllIdeasOfAUser(string userId);

        Idea GetIdeaByCommentId(string commentId);  
    }
}