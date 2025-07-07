using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace MyDddProject.WebApi.Controllers;

/// <summary>
/// Health check controller for monitoring application status
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Tags("Health")]
public class HealthController : ControllerBase
{
    /// <summary>
    /// Check the health status of the application
    /// </summary>
    /// <returns>Health status information</returns>
    [HttpGet]
    [ProducesResponseType(typeof(HealthResponse), StatusCodes.Status200OK)]
    public IActionResult GetHealth()
    {
        var response = new HealthResponse
        {
            Status = "Healthy",
            Timestamp = DateTime.UtcNow,
            Version = "1.0.0",
            Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"
        };

        return Ok(response);
    }

    /// <summary>
    /// Detailed health check with system information
    /// </summary>
    /// <returns>Detailed health information</returns>
    [HttpGet("detailed")]
    [ProducesResponseType(typeof(DetailedHealthResponse), StatusCodes.Status200OK)]
    public IActionResult GetDetailedHealth()
    {
        var response = new DetailedHealthResponse
        {
            Status = "Healthy",
            Timestamp = DateTime.UtcNow,
            Version = "1.0.0",
            Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development",
            MachineName = Environment.MachineName,
            ProcessId = Environment.ProcessId,
            WorkingSet = Environment.WorkingSet,
            UpTime = DateTime.UtcNow.Subtract(Process.GetCurrentProcess().StartTime)
        };

        return Ok(response);
    }
}

/// <summary>
/// Basic health response model
/// </summary>
public class HealthResponse
{
    /// <summary>
    /// Current health status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Timestamp of the health check
    /// </summary>
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Application version
    /// </summary>
    public string Version { get; set; } = string.Empty;

    /// <summary>
    /// Current environment
    /// </summary>
    public string Environment { get; set; } = string.Empty;
}

/// <summary>
/// Detailed health response model
/// </summary>
public class DetailedHealthResponse : HealthResponse
{
    /// <summary>
    /// Machine name where the application is running
    /// </summary>
    public string MachineName { get; set; } = string.Empty;

    /// <summary>
    /// Process ID of the application
    /// </summary>
    public int ProcessId { get; set; }

    /// <summary>
    /// Working set memory usage
    /// </summary>
    public long WorkingSet { get; set; }

    /// <summary>
    /// Application uptime
    /// </summary>
    public TimeSpan UpTime { get; set; }
}
