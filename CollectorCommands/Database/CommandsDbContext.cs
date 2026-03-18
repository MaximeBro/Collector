using System.Diagnostics.CodeAnalysis;
using CollectorCommands.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectorCommands.Database;

[ExcludeFromCodeCoverage]
public class CommandsDbContext : DbContext
{
    public DbSet<CommandModel> Commands { get; init; }
    public DbSet<ArticleModel> Articles { get; init; }
    
    public CommandsDbContext(DbContextOptions<CommandsDbContext> options) : base (options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticleModel>()
            .HasKey(e => e.Id);
        
        modelBuilder.Entity<CommandModel>()
            .HasKey(e => e.Id);
        
        modelBuilder.Entity<CommandModel>()
            .HasMany(e => e.Articles)
            .WithOne(e => e.Command)
            .HasForeignKey(e => e.CommandId)
            .IsRequired();
    }
}