using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using SistemaVenta.IOC;
using System;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.inyectarDependecias(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

IApplicationBuilder applicationBuilder = app.UseCors("NuevaPolitica");


app.UseAuthorization();

app.MapControllers();

app.Run();







