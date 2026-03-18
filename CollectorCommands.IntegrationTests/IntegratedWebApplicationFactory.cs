using System.Diagnostics.CodeAnalysis;
using CollectorCommands.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CollectorCommands.IntegrationTests;

[ExcludeFromCodeCoverage]
public class IntegratedWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptors = services.Where(d => 
                d.ServiceType == typeof(DbContextOptions) ||
                d.ServiceType == typeof(DbContextOptions<CommandsDbContext>) || 
                d.ServiceType == typeof(IDbContextFactory<CommandsDbContext>) ||
                d.ServiceType == typeof(IDbContextOptionsConfiguration<CommandsDbContext>)
            ).ToList();

            foreach (var descriptor in descriptors)
            {
                services.Remove(descriptor);
            }

            services.AddDbContextFactory<CommandsDbContext>(options => options.UseInMemoryDatabase("TestDb"));
        });
    }
}