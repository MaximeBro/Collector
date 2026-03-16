using CollectorCommands.Models;
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

    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] CommandModel? model)
    {
        if (model == null || model.Articles.Count == 0) return BadRequest();

        try
        {
            var command = await _service.CreateAsync(model);
            return Ok(command);
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
    
    [HttpPost("confirm/{id:guid}")]
    public async Task<IActionResult> Confirm([FromRoute] Guid? id)
    {
        try
        {
            if (!id.HasValue || id.Equals(Guid.Empty)) return BadRequest();
            
            var command = await _service.GetByIdAsync(id.Value);
            if (command == null) return NotFound();

            var updated = await _service.ConfirmAsync(command);
            return Ok(updated);
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