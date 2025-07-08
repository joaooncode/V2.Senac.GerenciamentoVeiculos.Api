using System;
using System.Collections.Generic;

namespace V2.Senac.GerenciamentoVeiculos.Api.Domain.Entities;

public class FuelTypeEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // Navigation property
    public ICollection<Car> Cars { get; set; } = new List<Car>();
}
