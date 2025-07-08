using Microsoft.EntityFrameworkCore;
using V2.Senac.GerenciamentoVeiculos.Api.Domain.Entities;
using V2.Senac.GerenciamentoVeiculos.Api.Domain.Repositories.Car;
using V2.Senac.GerenciamentoVeiculos.Api.Infrastructure.Data;

namespace V2.Senac.GerenciamentoVeiculos.Api.Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    private readonly ApplicationDbContext _context;

    public CarRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        var cars = await _context.Cars
            .Include(c => c.FuelTypeEntity)
            .ToListAsync();
        Console.WriteLine($"CarRepository.GetAllAsync() - Found {cars.Count} cars in database");
        return cars;
    }
}
