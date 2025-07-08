using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using V2.Senac.GerenciamentoVeiculos.Api.Application.Interfaces.Car;
using V2.Senac.GerenciamentoVeiculos.Api.Application.Services.Car;
using V2.Senac.GerenciamentoVeiculos.Api.Domain.Repositories.Car;
using V2.Senac.GerenciamentoVeiculos.Api.Infrastructure.Data;
using V2.Senac.GerenciamentoVeiculos.Api.Infrastructure.Repositories;
using V2.Senac.GerenciamentoVeiculos.Api.Infrastructure.Services;
using DotNetEnv;

// Load environment variables from .env file
var envFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".env");
if (File.Exists(envFilePath))
{
    Env.Load(envFilePath);
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // First try to get connection string from environment variables (.env file)
    var connectionString = Environment.GetEnvironmentVariable("NEON_POSTGRES_CONNECTION");

    // If not found, fallback to appsettings.json
    if (string.IsNullOrEmpty(connectionString))
    {
        connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    }

    options.UseNpgsql(connectionString);
});

// Register services
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<DatabaseSeeder>();

// Add health checks with database check
builder.Services.AddHealthChecks()
    .AddDbContextCheck<ApplicationDbContext>();
// Configure Swagger/OpenAPI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "V2.Senac.GerenciamentoVeiculos.Api API",
        Version = "v1",
        Description = "A .NET 8 Web API following Domain-Driven Design principles",
        Contact = new OpenApiContact
        {
            Name = "Development Team",
            Email = "dev@company.com"
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    // Include XML comments if available
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }

    // Add security definitions if needed
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
});

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add health checks
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "V2.Senac.GerenciamentoVeiculos.Api API v1");
        c.RoutePrefix = "swagger";
        c.DocumentTitle = "V2.Senac.GerenciamentoVeiculos.Api API Documentation";
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseCors("DefaultCorsPolicy");

app.UseAuthorization();

app.MapControllers();

// Map health check endpoint
app.MapHealthChecks("/health");

// Seed database in development
if (app.Environment.IsDevelopment())
{
    // Temporarily disabled - using existing data
    // using var scope = app.Services.CreateScope();
    // var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
    // await seeder.SeedAsync();
}

app.Run();
