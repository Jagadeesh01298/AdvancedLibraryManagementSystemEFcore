# Advanced Library Management System

This is an ASP.NET Core MVC web application built using Entity Framework Core, SQL Server, Repository Pattern, and AJAX.

## Features

- Manage Books, Authors, and Genres
- CRUD operations for all entities
- Generic Repository Pattern
- Specific repositories for Book, Author, and Genre
- EF Core Code First approach
- SQL Server database
- AJAX-based book creation
- Search and pagination for books
- Async EF Core operations
- Error handling for server-side and AJAX operations

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Repository Pattern
- AJAX
- jQuery
- Bootstrap

## Project Structure

- Models: Contains Book, Author, and Genre classes
- Data: Contains ApplicationDbContext
- Repositories: Contains generic and specific repositories
- Controllers: Contains MVC controllers
- Views: Contains Razor views

## Database Setup

Run the following commands in Package Manager Console:

```powershell
Add-Migration InitialCreate
Update-Database
