# .NET Core Authentication
Authentication sytem development with ASP .NET Core MVC. Data flow controlled by Entity Framework.

You can simply sign up and log in as a user and you can take notes and display your notes on the home page.

## Entites

 - User
	 - **(PK)** UserId
	- Name
	- Username
	- Password
	- IsDeleted
- Note
	- **(PK)** NoteId
	- NoteContext
	- **(FK)** UserId

#### To Do:
- [x] Log In
- [x] Sign Up
- [x] Save Notes
- [x] Display Notes
- [ ] Make Changes on Notes
- [ ] Front-End Beauty

This project is practice for MVC pattern, Entity Framework and .Net Core.
