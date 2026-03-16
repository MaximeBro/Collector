using CollectorCommands.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectorCommands.Database;

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
            .WithOne()
            .IsRequired();
        
        this.setDefaultData(modelBuilder);
    }

    private void setDefaultData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticleModel>()
            .HasData([
                new ArticleModel()
                {
                    Name = "Tableau",
                    Description = "Un simple tableau",
                    Price = 50,
                    State = ArticleState.Available,
                },
                new ArticleModel()
                {
                    Name = "Assiette",
                    Description = "Une assiette quelconque",
                    Price = 9.99,
                    State = ArticleState.Available,
                },
                new ArticleModel()
                {
                    Name = "Capsules",
                    Description = "Lot de capsules de bouteilles de bière",
                    Price = 14.99,
                    State = ArticleState.Available,
                },
            ]);

        modelBuilder.Entity<CommandModel>()
            .HasData([
                
            ]);
    }
}