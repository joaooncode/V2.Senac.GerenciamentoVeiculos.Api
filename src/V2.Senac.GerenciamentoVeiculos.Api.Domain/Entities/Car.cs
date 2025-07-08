using System;

namespace V2.Senac.GerenciamentoVeiculos.Api.Domain.Entities;

public class Car
{
    public long Id { get; set; }

    public required string Model { get; set; }

    public required string Brand { get; set; }

    public required string Color { get; set; }

    public required string Plate { get; set; }

    public int Year { get; set; }

    public decimal Price { get; set; }

    public int FuelTypeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    // Navigation property (optional) - maps to the FuelTypeEntity table via FuelTypeId
    public FuelTypeEntity? FuelTypeEntity { get; set; }
}