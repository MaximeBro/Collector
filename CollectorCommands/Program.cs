using System.Text.Json.Serialization;
using CollectorCommands.Database;
using CollectorCommands.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDbContextFactory<CommandsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CommandsDb")));

builder.Services.AddScoped<CommandsService>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();
return;
