using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace CollectorCommands.IntegrationTests.Tests;

public class CommandsEndpointsTests : IClassFixture<IntegratedWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _outputHelper;

    public CommandsEndpointsTests(IntegratedWebApplicationFactory factory, ITestOutputHelper outputHelper)
    {
        _client = factory.CreateClient();
        _outputHelper = outputHelper;
    }

    [Fact]
    public async Task GetCommands_ReturnsOk()
    {
        var response = await _client.GetAsync("api/v1/Commands");
        var content = await response.Content.ReadAsStringAsync();
        _outputHelper.WriteLine($"Status: {response.StatusCode}");
        _outputHelper.WriteLine($"Body: {content}");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetCommand_UnknownId_ReturnsNotFound()
    {
        var response = await _client.GetAsync($"api/v1/Commands/{Guid.NewGuid()}");
        var content = await response.Content.ReadAsStringAsync();
        _outputHelper.WriteLine($"Status: {response.StatusCode}");
        _outputHelper.WriteLine($"Body: {content}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}