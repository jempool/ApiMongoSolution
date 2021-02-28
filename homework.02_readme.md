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

- Get list of Users
- Get individual User
- Create User
- Delete User

B. Implement the following IDEAS actions:

- Create Idea by user
- Delete Idea by user
- Get list of User's ideas
- Get individual User's idea
- Get the list of all ideas (all users)

C. Implement the following COMMENTS actions:

- Create a comment of an IDEA (including stars)
- Delete a comment of and IDEA (including stars)
- Get list of comments of and IDEA
- Get individual comment from an IDEA

D. Implement the following COUNTRY actions:
- Get the list of all unique countries from current users
- Get the list of existing users for a country (e.g. /countries/BOLIVIA/users => [{}])

E. Some BIZ rules you may need to follow:
- Validate the user's email on creation (ensure it's a EMAIL)
- User's Email cannot be duplicated,
- Validate the stars quantity (range 1-5)
- Comment can only be posted to ideas that were not created by the same user.
- Only a comment per user is allowed!
- The country name can only be in CAPITAL LETTERS and is limited to the full set of Latin American countries!

F. Dockerize the application in one docker container