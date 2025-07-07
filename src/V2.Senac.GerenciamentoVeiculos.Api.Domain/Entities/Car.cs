namespace V2.Senac.GerenciamentoVeiculos.Api.Domain.Entities;

public class Car
{
    public long Id { get; set; }
    
    public string Model { get; set; }
    
    public string Brand { get; set; }
    
    public string Color { get; set; }
    
    public string Plate { get; set; }
    
    public int Year { get; set; }
    
    public FuelType FuelType { get; set; }
    
}