using Microsoft.EntityFrameworkCore;
using PruebaEurofirms.Application.Interfaces;
using PruebaEurofirms.Application.Services;
using PruebaEurofirms.Domain.Repositories;
using PruebaEurofirms.Infrastructure;
using PruebaEurofirms.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CharacterDbContext>(options =>
    options.UseSqlite("Data Source=../Eurofirms.db")); 

builder.Services.AddScoped<ICharacterRepository, SqliteCharacterRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICharacterRepository, SqliteCharacterRepository>();
builder.Services.AddHttpClient<IRickAndMortyService, RickAndMortyService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();

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
