using Company.DAL;
using Company.DAL.Setting;
using Company.Logger;
using Company.Logger.Contract;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.

builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddDbContext<RepositoryContext>(opts =>
    opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
    b.MigrationsAssembly("Company.API")));


TrackSettings trackChanges = configuration.GetSection("TrackSettings").Get<TrackSettings>();
builder.Services.AddSingleton(trackChanges);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
