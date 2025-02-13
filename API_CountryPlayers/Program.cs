using API_CountryPlayers.ActionClass;
using API_CountryPlayers.Interface;
using API_CountryPlayers.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICountry, CountryClass>();
builder.Services.AddTransient<IPlayer, PlayerClass>();

var connectionString = builder.Configuration.GetConnectionString("ConnectDb");
builder.Services.AddDbContext<PlayersContext>(options=>options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Audience = "";
        options.Authority = "";
    }); // Добавление проверки на аутентификацию


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
