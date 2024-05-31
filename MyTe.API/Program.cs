using Microsoft.EntityFrameworkCore;
using MyTe.API.Controllers;
using MyTe.API.Models.Contexts;
using MyTe.API.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager config = builder.Configuration;
// Add services to the container.

builder.Services.AddDbContext<MyTeContext>(options =>
    options.UseSqlServer(config.GetConnectionString("MyTeConnection")));

builder.Services.AddScoped<CargosService>();
builder.Services.AddScoped<ColaboradoresService>();
builder.Services.AddScoped<RegistrosHorasService>();
builder.Services.AddScoped<WbssService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<MyTeContext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
