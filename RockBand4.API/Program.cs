﻿
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using RockBand4.API.DbContext;
using RockBand4.API.Services;

namespace RockBand4.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<ISongService, SongService>();

        builder.Services.AddDbContextPool<MariaDbContext>(options =>
        {
            var connetionString = builder.Configuration.GetConnectionString("MariaDbConnectionString");
            options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
        });

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

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

