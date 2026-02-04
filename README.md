# Movies API

ASP.NET Core Web API for managing movies and genres.

## Features
- CRUD operations
- Entity Framework Core
- SQL Server
- Layered architecture (Controllers, Services, Models)

## Technologies
- ASP.NET Core
- EF Core
- SQL Server

  
## Project Structure
  
WebApplication2/
├── Controllers/          # API Controllers (GenericsController, MoviesController)
├── Models/              # Entity classes (Movie, Genre)
├── DTOs/               # Data Transfer Objects
├── Migrations/         # Database migrations
├── appsettings.json    # Configuration file
└── ApplicationDbContext.cs # Database context

 ## API for movie Endpoints
- `GET /api/movies` - Get all movies
- `GET /api/movies/{id}` - Get movie by ID
- `POST /api/movies` - Create new movie
- `PUT /api/movies/{id}` - Update movie
- `DELETE /api/movies/{id}` - Delete movie
## API for genres Endpoints

- `GET /api/Geners` - Get all movies
- `POST /api/Geners` - Create new genre
- `PUT /api/Geners/{id}` - Update genre
- `DELETE /api/Geners/{id}` - Delete genre


