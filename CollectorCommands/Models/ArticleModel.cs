using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CollectorCommands.Models;

[ExcludeFromCodeCoverage]
public class ArticleModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [JsonPropertyName("userId")]
    public Guid UserId { get; set; } = Guid.NewGuid();

    [MaxLength(50)]
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(300)]
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    
    [JsonPropertyName("price")]
    public double Price { get; set; } = 0D;

    [JsonPropertyName("state")]
    public ArticleState State { get; set; } = ArticleState.Available;
    
    [NotMapped]
    [JsonIgnore]
    public Guid? CommandId { get; set; } = Guid.NewGuid();
    
    [NotMapped]
    [JsonIgnore]
    public CommandModel? Command { get; set; }
}