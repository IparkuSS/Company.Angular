using AutoMapper;
using Company.API.Extensions;
using Company.BLL;
using Company.DAL;
using Company.DAL.Setting;
using Company.Logger;
using Company.Logger.Contract;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using News.API.Extensions;
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

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);



builder.Services.ConfigureServices();
builder.Services.ConfigureRepository();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var resolvedLoggerManager = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(resolvedLoggerManager);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
