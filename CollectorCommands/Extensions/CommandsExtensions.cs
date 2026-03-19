using CollectorCommands.Models;

namespace CollectorCommands.Extensions;

public static class CommandsExtensions
{
    public static double GetTotalHt(this CommandModel @this)
    {
        return @this.Articles.Sum(x => x.Price);
    }
    
    public static double GetTotal(this CommandModel @this)
    {
        return @this.GetTotalHt(); // * 1.05D;
    }
}