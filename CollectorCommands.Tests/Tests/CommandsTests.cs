using CollectorCommands.Extensions;
using CollectorCommands.Models;
using Xunit;

namespace CollectorCommands.Tests.Tests;

public class CommandsTests
{
    [Fact]
    public void CalculateTotals()
    {
        var command = new CommandModel()
        {
            State = CommandState.Pending,
            Total = 0,
            TotalHt = 0,
            Articles = [
                new ArticleModel()
                {
                    Price = 50,
                    State = ArticleState.Available,
                    Description = "",
                    Name = "",
                },
                new ArticleModel()
                {
                    Price = 50,
                    State = ArticleState.Available,
                    Description = "",
                    Name = "",
                }
            ]
        };

        var calculatedTotalHt = command.GetTotalHt();
        var calculatedTotal = command.GetTotal();
        
        Assert.Equal(100, calculatedTotalHt);
        Assert.Equal(105, calculatedTotal);
    }
}