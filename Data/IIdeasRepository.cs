using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Data
{   
       public interface IIdeasRepository
    {
        Idea CreateIdea(Idea idea);
        void DeleteIdea(Guid id);
        IEnumerable<Idea> GetAllIdeas();
        Idea GetIdeaById(Guid id);
    }
}