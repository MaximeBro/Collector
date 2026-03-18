using CollectorCommands.Controllers;
using CollectorCommands.Models;
using CollectorCommands.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CollectorCommands.Tests.Tests;

public class CommandsControllerTests
{
    [Fact]
    public async Task GetAll_ReturnsOk_WithCommands()
    {
        var mockService = new Mock<ICommandsService>();
        mockService.Setup(s => s.GetAllAsync()).ReturnsAsync([new CommandModel { Id = Guid.NewGuid(), Articles = new() }]);

        var controller = new CommandsController(mockService.Object);
        var result = await controller.GetAll();
        
        var ok = Assert.IsType<OkObjectResult>(result);
        var commands = Assert.IsAssignableFrom<IEnumerable<CommandModel>>(ok.Value);
        Assert.Single(commands);
    }
    
    [Fact]
    public async Task GetById_InvalidId_ReturnsBadRequest()
    {
        var mockService = new Mock<ICommandsService>();
        var controller = new CommandsController(mockService.Object);
        var result = await controller.GetById(Guid.Empty);

        Assert.IsType<BadRequestResult>(result);
    }
    
    [Fact]
    public async Task GetById_NotFound_ReturnsNotFound()
    {
        var mockService = new Mock<ICommandsService>();
        mockService.Setup(s => s.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((CommandModel?)null);

        var controller = new CommandsController(mockService.Object);
        var result = await controller.GetById(Guid.NewGuid());

        Assert.IsType<NotFoundResult>(result);
    }
    
    [Fact]
    public async Task GetById_Found_ReturnsOk()
    {
        var mockService = new Mock<ICommandsService>();
        mockService.Setup(s => s.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new CommandModel { Id = Guid.NewGuid(), Articles = new() });

        var controller = new CommandsController(mockService.Object);
        var result = await controller.GetById(Guid.NewGuid());

        Assert.IsType<OkObjectResult>(result);
    }
    
    // [Fact]
    // public async Task Create_InvalidModel_ReturnsBadRequest()
    // {
    //     var mockService = new Mock<ICommandsService>();
    //     var controller = new CommandsController(mockService.Object);
    //     var result = await controller.Create(null);
    //
    //     Assert.IsType<BadRequestResult>(result);
    // }
    //
    // [Fact]
    // public async Task Create_ValidModel_ReturnsOk()
    // {
    //     var model = new CommandModel
    //     {
    //         Articles = [new ArticleModel()]
    //     };
    //
    //     var mockService = new Mock<ICommandsService>();
    //     mockService.Setup(s => s.CreateAsync(model)).ReturnsAsync(model);
    //
    //     var controller = new CommandsController(mockService.Object);
    //     var result = await controller.Create(model);
    //
    //     Assert.IsType<OkObjectResult>(result);
    // }
    //
    // [Fact]
    // public async Task Confirm_InvalidId_ReturnsBadRequest()
    // {
    //     var mockService = new Mock<ICommandsService>();
    //     var controller = new CommandsController(mockService.Object);
    //     var result = await controller.Confirm(Guid.Empty);
    //     
    //     Assert.IsType<BadRequestResult>(result);
    // }
}