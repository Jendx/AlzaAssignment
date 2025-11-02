using Api.Endpoints;
using Api.Endpoints.V1;
using Api.Endpoints.V2;
using Api.Extensions;
using Data.Context;
using Domain.Providers;
using Microsoft.EntityFrameworkCore;

namespace Api;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.RegisterServices();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlServer(connectionString));

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        // Register all endpoints
        app
            .MapProductEndpoints()
            .MapProductEndpointsV2();

        app.Run();
    }
}