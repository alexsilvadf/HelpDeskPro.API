using HDP.Infra.Data;
using HDP.Service.Extensao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HDPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Porta padrão Angular
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddControllers();
builder.Services.AdicionarApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowMyOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
