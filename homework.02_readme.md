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
[X] Get the list of all unique countries from current users
[X] Get the list of existing users for a country (e.g. /countries/BOLIVIA/users => [{}])

E. Some BIZ rules you may need to follow:
[X] Validate the user's email on creation (ensure it's a EMAIL)
[X] User's Email cannot be duplicated,
[X] Validate the stars quantity (range 1-5)
[X] Comment can only be posted to ideas that were not created by the same user.
[X] Only a comment per user is allowed!
[X] The country name can only be in CAPITAL LETTERS and is limited to the full set of Latin American countries!

F. Dockerize the application in one docker container
[ ]
