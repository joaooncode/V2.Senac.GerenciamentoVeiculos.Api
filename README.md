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

## Getting Started

1. Navigate to the project directory
2. Restore dependencies: `dotnet restore`
3. Build the solution: `dotnet build`
4. Run tests: `dotnet test`
5. Run the API: `dotnet run --project src/V2.Senac.GerenciamentoVeiculos.Api.WebApi`

## API Documentation

After running the API, access the Swagger documentation at:
- **Development**: https://localhost:7001/swagger
- **HTTP**: http://localhost:5000/swagger

## Test Endpoints

The API includes sample endpoints for testing:
- `GET /api/health` - Health check endpoint
- `GET /api/sample` - Sample data endpoint

## Architecture

This project follows Clean Architecture and DDD principles:
- Domain layer contains no dependencies on other layers
- Application layer depends only on Domain
- Infrastructure implements interfaces defined in Domain/Application
- WebApi depends on Application and Infrastructure for DI setup
