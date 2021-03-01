For this homework placeholder each of you needs to create a folder like:
*initial.lastname.hw*

e.g. *j.roca.hw*

Inside this folder you need to implement the following:


A multiproject .net core **SOLUTION** for an API + DB (MONGODB) to accomplish the following requirement:

- An **USER** can propose an **IDEA** that can have a detail, and associated **COMMENT** with stars (1-5) from **other USERS** (not him/her self). An *USER* has an assigned email, name, and country. 
- Each **IDEA** should contain the **number** of comments and the **average number** of stars.

This is just an example:

- users/XXXX => {id: "uXXXX", name: "Javier Roca", email: "mail@mail.com", country: "BOLIVIA" }
- users/XXXX/ideas/iYYY => {id: "iYYY", detail: "Increase salary!", comments: 2, averageStars: 3, proposedBy: "XXXX"}
- users/XXXX/ideas/iYYY/comments => [{id: "cAAA", comment: "Agree!!!", stars: 4, givenBy: "uYYYY:},
  {id: "cBBB", comment: "What a cliche", stars: 2, givenBy: "uZZZZ:}
]

A. Implement the following USER actions:

[X] Get list of Users
[X] Get individual User
[X] Create User
[X] Delete User

B. Implement the following IDEAS actions:

[X] Create Idea by user
[X] Delete Idea by user
[X] Get list of User's ideas
[X] Get individual User's idea
[X] Get the list of all ideas (all users)

C. Implement the following COMMENTS actions:

[X] Create a comment of an IDEA (including stars)
[X] Delete a comment of and IDEA (including stars)
[X] Get list of comments of and IDEA
[X] Get individual comment from an IDEA

D. Implement the following COUNTRY actions:
[ ] Get the list of all unique countries from current users
[ ] Get the list of existing users for a country (e.g. /countries/BOLIVIA/users => [{}])

E. Some BIZ rules you may need to follow:
[X] Validate the user's email on creation (ensure it's a EMAIL)
[X] User's Email cannot be duplicated,
[X] Validate the stars quantity (range 1-5)
[ ] Comment can only be posted to ideas that were not created by the same user.
[ ] Only a comment per user is allowed!
[X] The country name can only be in CAPITAL LETTERS and is limited to the full set of Latin American countries!

F. Dockerize the application in one docker container



users: 
            new User("ab908249-7cf7-49cf-890e-d1c71cc08d59") { Name = "Jem Suarez", Email = "jem@mail.com", Country = "COLOMBIA" },
            new User("93491041-023f-45fe-b61b-461a086fc87b") { Name = "Carlos Perez", Email = "carlos@mail.com", Country = "BOLIVIA" },
            new User("4586afea-1167-4159-bd14-3cfb3db47bb4") { Name = "Diana Sanchez", Email = "diana@mail.com", Country = "CHILE" },

ideas: 
			new Idea("602f616a-382c-446e-9d07-40436f356863") { Detail = "Increase salary!", Comments = 2, AverageStars = 3, ProposedBy = "ab908249-7cf7-49cf-890e-d1c71cc08d59" },
			
			new Idea("1eedb34c-dd36-446e-a55a-5c1e0980ba32") { Detail = "More vacations!", Comments = 3, AverageStars = 4, ProposedBy = "93491041-023f-45fe-b61b-461a086fc87b" },
			
			new Idea("4a5cbd01-4c99-4132-a758-8a06c1f310db") { Detail = "Less taxes!", Comments = 1, AverageStars = 2, ProposedBy = "4586afea-1167-4159-bd14-3cfb3db47bb4" },
			
comments:
  {id: "9e9fd6c6-01ab-4d7c-99e4-db2fa32e7b7b", comment: "What a cliche", stars: 2, givenBy: "7e1ca8a4-8006-45d5-806e-cefcd7a838ea"}
