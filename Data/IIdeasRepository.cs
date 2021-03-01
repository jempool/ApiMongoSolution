using System;
using System.Collections.Generic;
using Api.Models;

namespace Api.Data
{   
    public interface IIdeasRepository
    {
        Idea CreateIdea(Idea idea);

        bool DeleteIdea(string id);

        IEnumerable<Idea> GetAllIdeas();

        Idea GetIdeaById(string id);
    }
}