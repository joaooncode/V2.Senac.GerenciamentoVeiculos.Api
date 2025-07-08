using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DotNetEnv;

namespace V2.Senac.GerenciamentoVeiculos.Api.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // Load environment variables from .env file
        var envPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".env");
        if (File.Exists(envPath))
        {
            Env.Load(envPath);
        }

        // Try to get connection string from environment variables first
        var connectionString = Environment.GetEnvironmentVariable("NEON_POSTGRES_CONNECTION");

        // If not found, use default connection string
        if (string.IsNullOrEmpty(connectionString))
        {
            connectionString = "Host=localhost;Database=GerenciamentoVeiculosDb;Username=postgres;Password=yourpassword123;Port=5432";
        }

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
