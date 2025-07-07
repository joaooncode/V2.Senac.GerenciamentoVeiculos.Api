using System.Collections.Generic;
using System.Threading.Tasks;

namespace V2.Senac.GerenciamentoVeiculos.Api.Domain.Repositories.Car;

public interface ICarRepository
{
   Task<IEnumerable<Entities.Car>> GetAllAsync();
}