using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Data
{   
    public interface IIdeasRepository
    {
        Idea CreateIdea(Idea idea);

        bool DeleteIdea(string ideaId);

        IEnumerable<Idea> GetAllIdeas();

        Idea GetIdeaById(string ideaId);

        bool IncreaseNumberOfComments(string ideaId);

        bool UpdateAverageStars(string ideaId, long newAverageOfStars);

        IEnumerable<Idea> GetAllIdeasOfAUser(string userId);        
    }
}