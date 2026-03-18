using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CollectorCommands.Models;

[ExcludeFromCodeCoverage]
public class CommandModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [JsonPropertyName("buyerId")]
    public Guid BuyerId { get; set; } = Guid.NewGuid();
    
    [JsonPropertyName("sellerId")]
    public Guid SellerId { get; set; } = Guid.NewGuid();

    [JsonPropertyName("total")]
    public double Total { get; set; } = 0D;
    
    [JsonPropertyName("totalHt")]
    public double TotalHt { get; set; } = 0D;
    
    [JsonPropertyName("state")]
    public CommandState State { get; set; } = CommandState.Pending;

    [JsonPropertyName("articles")]
    public List<ArticleModel> Articles { get; set; } = [];
}