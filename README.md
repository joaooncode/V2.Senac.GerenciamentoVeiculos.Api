# V2.Senac.GerenciamentoVeiculos.Api

A .NET project following Domain-Driven Design (DDD) principles.

## Project Structure

### src/

- **Domain**: Core business logic, entities, value objects, and domain services
- **Application**: Use cases, commands, queries, and application services
- **Infrastructure**: Data access, external services, and technical concerns
- **WebApi**: REST API controllers and presentation logic
- **SharedKernel**: Common functionality shared across bounded contexts

### tests/

- Unit and integration tests for each layer

## Database Configuration

This project supports both PostgreSQL and SQL Server databases.

### PostgreSQL (Default)

The project is configured to use PostgreSQL by default. Connection strings are in:

- `appsettings.json` - Production
- `appsettings.Development.json` - Development

### Connection String Examples:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=GerenciamentoVeiculosDb;Username=postgres;Password=yourpassword123;Port=5432"
  }
}
```

## Getting Started

### Prerequisites

- .NET 8 SDK
- PostgreSQL or SQL Server
- Entity Framework Core Tools

### Installation

1. Clone the repository
2. Navigate to the project directory
3. Restore dependencies: `dotnet restore`
4. Update connection strings in `appsettings.json`

### Database Setup

#### Option 1: Using Docker (Recommended)

```bash
# Start PostgreSQL container
docker-compose up -d postgres

# Run migrations
dotnet ef database update --project src/V2.Senac.GerenciamentoVeiculos.Api.Infrastructure --startup-project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi
```

#### Option 2: Local PostgreSQL

1. Install PostgreSQL
2. Create database: `GerenciamentoVeiculosDb`
3. Update connection string in `appsettings.json`
4. Run migrations (see commands below)

### Entity Framework Commands

```bash
# Add new migration
dotnet ef migrations add MigrationName --project src/V2.Senac.GerenciamentoVeiculos.Api.Infrastructure --startup-project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi

# Update database
dotnet ef database update --project src/V2.Senac.GerenciamentoVeiculos.Api.Infrastructure --startup-project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi

# Drop database
dotnet ef database drop --project src/V2.Senac.GerenciamentoVeiculos.Api.Infrastructure --startup-project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi
```

### Running the Application

1. Build the solution: `dotnet build`
2. Run tests: `dotnet test`
3. Run the API: `dotnet run --project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi`

## API Documentation

After running the API, access the Swagger documentation at:

- **Development**: https://localhost:7001/swagger
- **HTTP**: http://localhost:5000/swagger

## Test Endpoints

The API includes the following endpoints:

- `GET /api/health` - Health check endpoint
- `GET /api/car` - Get all cars
- `GET /api/sample` - Sample data endpoint

## Architecture

This project follows Clean Architecture and DDD principles:

- Domain layer contains no dependencies on other layers
- Application layer depends only on Domain
- Infrastructure implements interfaces defined in Domain/Application
- WebApi depends on Application and Infrastructure for DI setup

## Database Features

- **Entity Framework Core 8.0** with PostgreSQL provider
- **Code-First** approach with migrations
- **Repository Pattern** implementation
- **Database seeding** for development data
- **Health checks** for database connectivity
- **Docker support** for database containerization
