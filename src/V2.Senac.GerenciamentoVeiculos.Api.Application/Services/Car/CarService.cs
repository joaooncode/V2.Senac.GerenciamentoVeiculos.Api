using V2.Senac.GerenciamentoVeiculos.Api.Application.DTOs.Responses;
using V2.Senac.GerenciamentoVeiculos.Api.Application.Interfaces.Car;
using V2.Senac.GerenciamentoVeiculos.Api.Domain.Repositories.Car;

namespace V2.Senac.GerenciamentoVeiculos.Api.Application.Services.Car;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<GetAllAsyncResponse>> GetAllAsync()
    {
        var cars = await _carRepository.GetAllAsync();

        var carsResponse = cars.Select(c => new GetAllAsyncResponse
        {
            Id = c.Id,
            Model = c.Model,
            Brand = c.Brand,
            Color = c.Color,
            Plate = c.Plate,
            Year = c.Year,
            Price = c.Price,
            FuelTypeId = c.FuelTypeId,
            FuelType = c.FuelTypeEntity?.Name ?? "Unknown",
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt
        });

        return carsResponse;
    }
}