using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using pessoas_api.Data;
using pessoas_api.Entities;
using pessoas_api.Exceptions;
using pessoas_api.Repositories;
using pessoas_api.Services;
using pessoas_api.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<GlobalExceptionsHandler>())
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter()));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.DocumentFilter<CustomSchemaFilter>());

// Configure the Database
var connectionString = $"Server={Environment.GetEnvironmentVariable("DB_HOST")};Database={Environment.GetEnvironmentVariable("DB_NAME")};User Id={Environment.GetEnvironmentVariable("DB_USER")};Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};TrustServerCertificate=true;MultipleActiveResultSets=true;";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services
    .AddHttpClient()
    .AddTransient<DbContext, AppDbContext>()
    .AddTransient<PersonRepository, PersonRepository>()
    .AddTransient<IRepository<Address>, Repository<Address>>()
    .AddTransient<IPersonService, PersonService>()
    .AddTransient<IAddressService, AddressService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DatabaseManagementService.InitializeMigration(app);

app.UseAuthorization();

app.MapControllers();

app.Run();
