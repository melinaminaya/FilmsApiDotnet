# Films API

This project is a RESTful API built using .NET, designed to manage a collection of films. It provides endpoints for performing CRUD (Create, Read, Update, Delete) operations on films, including details like title, director, genre, release year, and more.

## Features

- **Create** new film records.
- **Read** film details by ID or list of films.
- **Update** existing film records.
- **Delete** films from the collection.
- **Search** films by title, director, genre, or release year.

## Technologies Used

- **.NET 8.0** for the backend API.
- **Entity Framework Core** for ORM-based database access.
- **SQLite** or **SQL Server** (choose based on your preference for development or production).
- **Swagger** for API documentation and testing.
- **Postman** for API testing (optional).

## Installation

Follow these steps to get the project up and running:

### Prerequisites

- [.NET SDK 6.0+](https://dotnet.microsoft.com/download)
- A code editor like [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)
- SQLite or SQL Server (depending on your choice of database)

### Clone the repository

```bash
git clone https://github.com/yourusername/films-api.git
cd films-api
dotnet restore
dotnet ef database update
dotnet run      
```