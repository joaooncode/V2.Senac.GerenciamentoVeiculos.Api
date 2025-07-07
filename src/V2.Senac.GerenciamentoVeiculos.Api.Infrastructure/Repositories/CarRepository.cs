using V2.Senac.GerenciamentoVeiculos.Api.Domain.Entities;
using V2.Senac.GerenciamentoVeiculos.Api.Domain.Repositories.Car;

namespace V2.Senac.GerenciamentoVeiculos.Api.Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    public Task<IEnumerable<Car>> GetAllAsync()
    {
        // TODO: Implement actual data access logic
        // For now, returning sample data
        var cars = new List<Car>
        {
            new Car
            {
                Id = 1,
                Model = "Civic",
                Brand = "Honda",
                Color = "Blue",
                Plate = "ABC-1234",
                Year = 2022,
                FuelType = FuelType.GASOLINE
            },
            new Car
            {
                Id = 2,
                Model = "Corolla",
                Brand = "Toyota",
                Color = "White",
                Plate = "XYZ-5678",
                Year = 2023,
                FuelType = FuelType.HYBRID
            }
        };

        return Task.FromResult<IEnumerable<Car>>(cars);
    }
}
