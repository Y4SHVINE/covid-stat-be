# CovidStat-backend

The goal of this project is to be a kickstart to your .Net WebApi, implementing the most common used patterns
and technologies for a restful API in .net, making your work easier.

# How to run
- clone/download to your local workplace.
- Download the latest .Net SDK and Visual Studio/Code.

## Standalone
1. You have to change your connection string to "Server=127.0.0.1;Database=CovidStat;User=sa;Password=Yourpassword123” and run api and webapp projects:
	- If you want, you can change the DatabaseExtension to use UseInMemoryDatabase, instead of Mssql.
2. Go to the src/CovidStat.Api folder and run ``dotnet run``, or, in visual studio set the api project as startup and run as console or docker (not IIS).
3. Visit http://localhost:5000/api-docs or https://localhost:5001/api-docs to access the application's swagger.

## Authentication
In this project, some routes requires authentication/authorization. For that, you will have to use the ``api/user/authenticate`` route to obtain the JWT.
As default, you have two users, Admin and normal user.
- Normal user: 
	- email: user@boilerplate.com
	- password: userpassword
- Admin:
	- email: admin@boilerplate.com
	- password: adminpassword

After that, you can pass the jwt on the lock (if using swagger) or via the Authorization header on a http request.

# This project contains:
- SwaggerUI
- EntityFramework
- AutoMapper
- Generic repository (to easily bootstrap a CRUD repository)
- Serilog with request logging and easily configurable sinks
- .Net Dependency Injection
- Resource filtering
- Response compression
- Response pagination
- Authentication
- Authorization

# Project Structure
1. Services
	- This folder stores your apis and any project that sends data to your users.
	1. CovidStat.Api
		- This is the main api project. Here are all the controllers and initialization for the api that will be used.
	2. docker-compose
		- This project exists to allow you to run docker-compose with Visual Studio. It contains a reference to the docker-compose file and will build all the projects dependencies and run it.
2. Application
	-  This folder stores all data transformations between your api and your domain layer. It also contains your business logic.
	1. Auth
		- This folder contains the login Session implementation.
3. Domain
	- This folder contains your business models, enums and common interfaces.
	1. CovidStat.Domain.Core
		- Contains the base entity for all other domain entities, as well as the interface for the repository implementation.
	2. CovidStat.Domain
		- Contains business models and enums.
		1. Auth
			- This folder contains the login Session Interface.
4. Infra
	- This folder contains all data access repositories, database contexts, anything that reaches for outside data.
	1. CovidStat.Infrastructure
		- This project contains the dbcontext, an generic implementation of repository pattern and a Hero(domain class) repository.
5. Web
	- This folder stores the admin MVC project to access apis.

# Migrations
1. To run migrations on this project, run the following command on the root folder: 
	- ``dotnet ef migrations add InitialCreate --startup-project .\src\CovidStat.Api\ --project .\src\CovidStat.Infrastructure\``

