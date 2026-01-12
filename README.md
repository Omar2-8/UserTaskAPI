# UserTaskAPI

A clean, layered .NET Web API for managing users and tasks with JWT-based role-based access control, built using Clean Architecture principles.

--------------------------------------------------------------------

ARCHITECTURE

The solution follows a Clean Architecture / DDD-style layering:

UserTaskAPI.Domain  
UserTaskAPI.Application  
UserTaskAPI.Infrastructure  
UserTaskAPI.API  
UserTaskAPI.Tests  

Responsibilities:

Domain  
- Core entities, enums, Models, DTOs 
- No framework or infrastructure dependencies  

Application  
- Business logic and use cases  
- Services, Interfaces  

Infrastructure  
- Entity Framework Core (InMemory)  
- Repositories and Unit of Work  
- JWT token generation and persistence  

API  
- Controllers and endpoints  
- Authentication and authorization  
- Swagger / OpenAPI configuration  

Tests  
- Integration and controller tests  
- Full request pipeline testing using WebApplicationFactory  

--------------------------------------------------------------------

FEATURES

Users (Admin only):
- Create a user
- Retrieve a user by ID
- List all users
- Update user details
- Delete a user

Tasks:
- Create a task (Admin only)
- Retrieve a task
  - Admin: any task
  - User: only tasks assigned to them
- Update a task
  - Admin: all fields
  - User: status only (assigned tasks only)
- Delete a task (Admin only)
- List all tasks (Admin only)

--------------------------------------------------------------------

SECURITY AND ACCESS CONTROL

- JWT authentication (Bearer tokens)
- Role-based authorization
  - Admin
  - User
- Authorization enforced via:
  - Controller attributes
  - Application service-level ownership and permission checks

JWT claims include:
- User ID
- Username
- Email
- Role

--------------------------------------------------------------------

DATABASE

- Entity Framework Core
- In-memory database provider
- Database is automatically seeded on startup with:
  - 2 users (Admin and User)
  - 3 tasks

No external database is required.

--------------------------------------------------------------------

TESTING

Testing stack:
- xUnit
- FluentAssertions
- Microsoft.AspNetCore.Mvc.Testing

Coverage includes:
- Controller actions
- Authorization rules
- JWT authentication
- End-to-end request pipeline

Tests authenticate via the real Auth API (no mocked principals).

Run tests:
dotnet test

--------------------------------------------------------------------

TECH STACK

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core (InMemory)
- JWT Authentication
- Swagger / OpenAPI
- xUnit + FluentAssertions

--------------------------------------------------------------------

HOW TO RUN

1. Clone the repository

git clone 
cd UserTaskAPI

2. Restore dependencies

dotnet restore

3. Run the API

dotnet run --project UserTaskAPI.API

The API will be available at:
https://localhost:<port>

--------------------------------------------------------------------

SWAGGER / OPENAPI

Swagger UI is available at:
https://localhost:<port>/

Authenticating in Swagger:
1. Call the Auth/Login endpoint
2. Copy the returned JWT
3. Click Authorize
4. Enter:
Bearer <your-token>

--------------------------------------------------------------------

SEEDED USERS (FOR TESTING)

Admin User:
- Username: admin
- Password: demo

Regular User:
- Username: user
- Password: demo

--------------------------------------------------------------------

PROJECT REFERENCES

API references:
- Application
- Infrastructure

Application references:
- Domain

Infrastructure references:
- Domain

Tests reference:
- API
- Application
- Infrastructure

No circular dependencies exist.

--------------------------------------------------------------------

DESIGN DECISIONS

- Strict separation of concerns
- Domain layer has zero framework dependencies
- JWT and authentication logic live only in Infrastructure
- Authorization rules enforced at both controller and service levels
- Tests exercise the real authentication and authorization pipeline

--------------------------------------------------------------------

EVALUATION CRITERIA COVERAGE

- Clean layered architecture
- Repository and Unit of Work patterns
- Full CRUD functionality
- Correct role-based access control
- JWT authentication
- Seeded test data
- Swagger API documentation
- Automated tests
- Clear build, run, and test instructions

--------------------------------------------------------------------

AUTHOR

This project is a clean, production-style demo showcasing secure API design, clean architecture, and testable .NET backend development.
