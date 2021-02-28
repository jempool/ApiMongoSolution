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
    public class IdeasController : ControllerBase
    {
            private static readonly List<Idea> Ideas = new ()
            {
                new Idea(Guid.Parse("602f616a-382c-446e-9d07-40436f356863")) { Detail = "Increase salary!", Comments = 2, AverageStars = 3, ProposedBy = Guid.Parse("ab908249-7cf7-49cf-890e-d1c71cc08d59") },
                new Idea(Guid.Parse("1eedb34c-dd36-446e-a55a-5c1e0980ba32")) { Detail = "More vacations!", Comments = 3, AverageStars = 4, ProposedBy = Guid.Parse("93491041-023f-45fe-b61b-461a086fc87b") },
                new Idea(Guid.Parse("4a5cbd01-4c99-4132-a758-8a06c1f310db")) { Detail = "Less taxes!", Comments = 1, AverageStars = 2, ProposedBy = Guid.Parse("4586afea-1167-4159-bd14-3cfb3db47bb4") },
            };

            private readonly ILogger<IdeasController> _logger;

            public IdeasController(ILogger<IdeasController> logger)
            {
                _logger = logger;
            }

            [HttpGet]
            public IEnumerable<Idea> GetAllIdeas()
            {
                return Ideas;
            }

            [HttpGet("{id}")]
            public Idea GetIdeaById(Guid id)
            {
                return Ideas.FirstOrDefault(idea => idea.Id == id);
            }

            [HttpPost]
            public Idea CreateIdea(Idea idea)
            {
                Idea newIdea = new (Guid.NewGuid()) { Detail = idea.Detail, Comments = idea.Comments, AverageStars = idea.AverageStars, ProposedBy = idea.ProposedBy };
                Ideas.Add(newIdea);
                return newIdea;
            }

            [HttpDelete("{id}")]
            public void DeleteIdea(Guid id)
            {
                var ideaToDelete = Ideas.FirstOrDefault(idea => idea.Id == id);
                if (ideaToDelete != null)
                {
                _ = Ideas.Remove(ideaToDelete);
                }
            }
    }
}
