using CollectorCommands.Database;
using CollectorCommands.Extensions;
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

    public async Task<CommandModel?> GetByIdAsync(Guid id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Commands.Include(x => x.Articles).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<CommandModel> CreateAsync(CommandModel model)
    {
        await using var db = await _factory.CreateDbContextAsync();

        model.TotalHt = model.GetTotalHt();
        model.Total = model.GetTotal();
        model.State = CommandState.Pending;
        
        await db.Commands.AddAsync(model);
        await db.SaveChangesAsync();

        return model;
    }

    public async Task<CommandModel> ConfirmAsync(CommandModel model)
    {
        await using var db = await _factory.CreateDbContextAsync();

        model.State = CommandState.Payed;
        db.Commands.Update(model);
        await db.SaveChangesAsync();

        return model;
    }
}