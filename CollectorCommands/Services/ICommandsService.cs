using CollectorCommands.Models;

namespace CollectorCommands.Services;

public interface ICommandsService
{
    Task<List<CommandModel>> GetAllAsync();
    Task<CommandModel?> GetByIdAsync(Guid id);
    Task<CommandModel> CreateAsync(CommandModel model);
    Task<CommandModel> ConfirmAsync(CommandModel model);
}