using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Services
{   
       public interface IIdeasService
    {
        Idea CreateIdea(Idea idea);
        void DeleteIdea(string id);
        IEnumerable<Idea> GetAllIdeas();
        Idea GetIdeaById(string id);
    }
}