using DevFreelaAPI.Models;
using DevFreela.Infrastructure.Persistence;
/* using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces; */
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DevFreela.Application.Commands.CreateProjects;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using DevFreela.Application.Vallidators;
using DevFreela.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationsFilter>();
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProjectCommand).Assembly));
//builder.Services.AddMediatR();

builder.Services.Configure<OpeningTimeOption>(builder.Configuration.GetSection("OpeningTime"));

var connectionString = builder.Configuration.GetConnectionString("DevFreelaCs");
builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(connectionString));

/* builder.Services.AddScoped<IProjectService, ProjectService>();
 */
builder.Services.AddSingleton<ExampleClass>(e => new ExampleClass{Name = "Initial Stage" });
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
