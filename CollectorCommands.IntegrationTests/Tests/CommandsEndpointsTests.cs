using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CollectorCommands.IntegrationTests.Tests;

public class CommandsEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CommandsEndpointsTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetCommands_ReturnsOk()
    {
        var response = await _client.GetAsync("api/v1/Commands");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetCommand_UnknownId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("api/v1/Commands/2dfb34c3-0b84-4ec1-9c2f-2030d5a32509");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}