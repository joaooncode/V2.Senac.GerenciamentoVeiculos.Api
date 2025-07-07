using Microsoft.AspNetCore.Mvc;

namespace MyDddProject.WebApi.Controllers;

/// <summary>
/// Sample controller demonstrating basic API operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Tags("Sample")]
public class SampleController : ControllerBase
{
    private static readonly List<SampleItem> _sampleData = new()
    {
        new SampleItem { Id = 1, Name = "Sample Item 1", Description = "This is a sample item", CreatedAt = DateTime.UtcNow.AddDays(-5) },
        new SampleItem { Id = 2, Name = "Sample Item 2", Description = "Another sample item", CreatedAt = DateTime.UtcNow.AddDays(-3) },
        new SampleItem { Id = 3, Name = "Sample Item 3", Description = "Yet another sample item", CreatedAt = DateTime.UtcNow.AddDays(-1) }
    };

    /// <summary>
    /// Get all sample items
    /// </summary>
    /// <returns>List of sample items</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SampleItem>), StatusCodes.Status200OK)]
    public IActionResult GetAllItems()
    {
        return Ok(_sampleData);
    }

    /// <summary>
    /// Get a specific sample item by ID
    /// </summary>
    /// <param name="id">The ID of the item to retrieve</param>
    /// <returns>The sample item if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SampleItem), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetItem(int id)
    {
        var item = _sampleData.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return NotFound($"Item with ID {id} not found");
        }

        return Ok(item);
    }

    /// <summary>
    /// Create a new sample item
    /// </summary>
    /// <param name="request">The sample item data to create</param>
    /// <returns>The created sample item</returns>
    [HttpPost]
    [ProducesResponseType(typeof(SampleItem), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateItem([FromBody] CreateSampleItemRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required");
        }

        var newItem = new SampleItem
        {
            Id = _sampleData.Count > 0 ? _sampleData.Max(x => x.Id) + 1 : 1,
            Name = request.Name,
            Description = request.Description ?? string.Empty,
            CreatedAt = DateTime.UtcNow
        };

        _sampleData.Add(newItem);

        return CreatedAtAction(nameof(GetItem), new { id = newItem.Id }, newItem);
    }

    /// <summary>
    /// Update an existing sample item
    /// </summary>
    /// <param name="id">The ID of the item to update</param>
    /// <param name="request">The updated item data</param>
    /// <returns>The updated sample item</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(SampleItem), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateItem(int id, [FromBody] UpdateSampleItemRequest request)
    {
        var item = _sampleData.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return NotFound($"Item with ID {id} not found");
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required");
        }

        item.Name = request.Name;
        item.Description = request.Description ?? string.Empty;

        return Ok(item);
    }

    /// <summary>
    /// Delete a sample item
    /// </summary>
    /// <param name="id">The ID of the item to delete</param>
    /// <returns>No content if successful</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteItem(int id)
    {
        var item = _sampleData.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return NotFound($"Item with ID {id} not found");
        }

        _sampleData.Remove(item);
        return NoContent();
    }
}

/// <summary>
/// Sample item model
/// </summary>
public class SampleItem
{
    /// <summary>
    /// Unique identifier for the item
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the item
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the item
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// When the item was created
    /// </summary>
    public DateTime CreatedAt { get; set; }
}

/// <summary>
/// Request model for creating a new sample item
/// </summary>
public class CreateSampleItemRequest
{
    /// <summary>
    /// Name of the item (required)
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the item (optional)
    /// </summary>
    public string? Description { get; set; }
}

/// <summary>
/// Request model for updating an existing sample item
/// </summary>
public class UpdateSampleItemRequest
{
    /// <summary>
    /// Name of the item (required)
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of the item (optional)
    /// </summary>
    public string? Description { get; set; }
}
