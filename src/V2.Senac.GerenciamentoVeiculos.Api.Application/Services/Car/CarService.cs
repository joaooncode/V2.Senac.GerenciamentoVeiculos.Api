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
    
    public Task<IEnumerable<GetAllAsyncResponse>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}