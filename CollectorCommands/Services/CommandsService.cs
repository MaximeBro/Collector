using CollectorCommands.Database;
using CollectorCommands.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectorCommands.Services;

public class CommandsService
{
    private readonly IDbContextFactory<CommandsDbContext> _factory;

    public CommandsService(IDbContextFactory<CommandsDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<CommandModel>> GetAllAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Commands.Include(x => x.Articles).ToListAsync();
    }
    
    
}