using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{   
       public interface IIdeasService
    {
        Idea CreateIdea(Idea idea);
        void DeleteIdea(Guid id);
        IEnumerable<Idea> GetAllIdeas();
        Idea GetIdeaById(Guid id);
    }
}