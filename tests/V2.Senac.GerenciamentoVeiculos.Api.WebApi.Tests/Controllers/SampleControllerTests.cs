using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MyDddProject.WebApi.Controllers;
using Xunit;

namespace MyDddProject.WebApi.Tests.Controllers;

public class SampleControllerTests
{
    private readonly SampleController _controller;

    public SampleControllerTests()
    {
        _controller = new SampleController();
    }

    [Fact]
    public void GetAllItems_Should_Return_Ok_With_Sample_Data()
    {
        // Act
        var result = _controller.GetAllItems();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = result as OkObjectResult;
        okResult?.Value.Should().NotBeNull();
    }

    [Fact]
    public void GetItem_With_Valid_Id_Should_Return_Ok()
    {
        // Arrange
        var validId = 1;

        // Act
        var result = _controller.GetItem(validId);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public void GetItem_With_Invalid_Id_Should_Return_NotFound()
    {
        // Arrange
        var invalidId = 999;

        // Act
        var result = _controller.GetItem(invalidId);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
    }

    [Fact]
    public void CreateItem_With_Valid_Request_Should_Return_Created()
    {
        // Arrange
        var request = new CreateSampleItemRequest
        {
            Name = "Test Item",
            Description = "Test Description"
        };

        // Act
        var result = _controller.CreateItem(request);

        // Assert
        result.Should().BeOfType<CreatedAtActionResult>();
    }

    [Fact]
    public void CreateItem_With_Empty_Name_Should_Return_BadRequest()
    {
        // Arrange
        var request = new CreateSampleItemRequest
        {
            Name = "",
            Description = "Test Description"
        };

        // Act
        var result = _controller.CreateItem(request);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
    }
}
