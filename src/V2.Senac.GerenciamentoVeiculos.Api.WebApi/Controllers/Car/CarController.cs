using Microsoft.AspNetCore.Mvc;
using V2.Senac.GerenciamentoVeiculos.Api.Application.DTOs.Responses;
using V2.Senac.GerenciamentoVeiculos.Api.Application.Interfaces.Car;
using Npgsql;

namespace V2.Senac.GerenciamentoVeiculos.Api.WebApi.Controllers.Car;


[ApiController]
[Route("api/[controller]")]
public class CarController : Controller
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IEnumerable<GetAllAsyncResponse>> GetAllAsync()
    {
        var response = await _carService.GetAllAsync();
        return response;
    }

    [HttpGet("count")]
    public async Task<IActionResult> GetCountAsync()
    {
        var response = await _carService.GetAllAsync();
        var count = response.Count();
        return Ok(new { Count = count, Message = $"Found {count} cars in database" });
    }

    [HttpGet("debug/tables")]
    public async Task<IActionResult> GetTablesAsync()
    {
        try
        {
            var connectionString = Environment.GetEnvironmentVariable("NEON_POSTGRES_CONNECTION");
            using var connection = new Npgsql.NpgsqlConnection(connectionString);
            await connection.OpenAsync();

            var command = new Npgsql.NpgsqlCommand(@"
                SELECT table_schema, table_name 
                FROM information_schema.tables 
                WHERE table_type = 'BASE TABLE' 
                AND table_schema NOT IN ('information_schema', 'pg_catalog')
                ORDER BY table_schema, table_name;", connection);

            var tables = new List<object>();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                tables.Add(new
                {
                    Schema = reader.GetString(0),
                    TableName = reader.GetString(1)
                });
            }

            return Ok(new
            {
                Database = "gerenciamento_veiculos_senac",
                Tables = tables
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}