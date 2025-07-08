using Microsoft.EntityFrameworkCore;
using V2.Senac.GerenciamentoVeiculos.Api.Domain.Entities;
using V2.Senac.GerenciamentoVeiculos.Api.Infrastructure.Data;

namespace V2.Senac.GerenciamentoVeiculos.Api.Infrastructure.Services;

public class DatabaseSeeder
{
    private readonly ApplicationDbContext _context;

    public DatabaseSeeder(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        // Ensure database is created
        await _context.Database.EnsureCreatedAsync();

        // Check if data already exists
        var existingCarsCount = await _context.Cars.CountAsync();
        Console.WriteLine($"DatabaseSeeder.SeedAsync() - Found {existingCarsCount} existing cars in database");

        if (existingCarsCount > 0)
        {
            Console.WriteLine($"DatabaseSeeder.SeedAsync() - Skipping seeding because {existingCarsCount} cars already exist");
            return; // Database already seeded
        }

        Console.WriteLine("DatabaseSeeder.SeedAsync() - Seeding 3 new cars...");

        // Seed initial data
        var cars = new List<Car>
        {
            new Car
            {
                Model = "Civic",
                Brand = "Honda",
                Color = "Blue",
                Plate = "ABC-1234",
                Year = 2022,
                Price = 85000.00m,
                FuelTypeId = 1, // GASOLINE
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Car
            {
                Model = "Corolla",
                Brand = "Toyota",
                Color = "White",
                Plate = "XYZ-5678",
                Year = 2023,
                Price = 95000.00m,
                FuelTypeId = 4, // HYBRID
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Car
            {
                Model = "Onix",
                Brand = "Chevrolet",
                Color = "Silver",
                Plate = "DEF-9012",
                Year = 2021,
                Price = 65000.00m,
                FuelTypeId = 3, // ETHANOL
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        await _context.Cars.AddRangeAsync(cars);
        await _context.SaveChangesAsync();
    }
}
