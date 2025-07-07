using V2.Senac.GerenciamentoVeiculos.Api.Application.DTOs.Responses;

namespace V2.Senac.GerenciamentoVeiculos.Api.Application.Interfaces.Car;

public interface ICarService
{
    Task<IEnumerable<GetAllAsyncResponse>> GetAllAsync();
}