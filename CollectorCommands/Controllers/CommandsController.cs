using CollectorCommands.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollectorCommands.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CommandsController : ControllerBase
{
    private readonly CommandsService _service;

    public CommandsController(CommandsService service)
    {
        _service = service;
    }
    
    [HttpGet("live")]
    public IActionResult LiveProbe()
    {
        return Ok();
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var commands = await _service.GetAllAsync();
            return Ok(commands);
        }
        catch (Exception e)
        {
            return Problem(
                statusCode: 500,
                title: "Internal Server Error",
                detail: $"Une erreur interne est survenue: {e.Message}"
            );
        }
    }
}