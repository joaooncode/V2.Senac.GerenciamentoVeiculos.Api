using System;

namespace V2.Senac.GerenciamentoVeiculos.Api.Application.DTOs.Responses;

public class GetAllAsyncResponse
{
    public long Id { get; set; }
    public required string Model { get; set; }
    public required string Brand { get; set; }
    public required string Color { get; set; }
    public required string Plate { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public int FuelTypeId { get; set; }
    public required string FuelType { get; set; } // This will be the name from fuel_types table
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}