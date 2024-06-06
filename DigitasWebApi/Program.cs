using Npgsql;
using System.Data;
using DigitasTechTest.Infrastructure.Data;
using DigitasTechTest.Infrastructure.Interfaces;
using DigitasTechTest.Infrastructure;
using DigitasTechTest.Application.Interfaces;
using DigitasTechTest.Application.Services;
using Domain.ExceptionHandler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("PostgresDb");

builder.Services.AddTransient<IDbConnection>((sp)=> new NpgsqlConnection(connectionString));
builder.Services.AddSingleton<IAppDbService, AppDbService>();
builder.Services.AddSingleton<IDigitasTaskRepository, DigitasTaskRepository>();
builder.Services.AddSingleton<IDigitasTaskService, DigitasTaskService>();
builder.Services.AddExceptionHandler<AppExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler( _ => { });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
