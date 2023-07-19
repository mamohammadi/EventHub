
using Event.API.Extensions;
using Event.Application.Queries;
using Event.Application.Queries.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Event.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;

            // Add services to the container.

            services.AddApplication();
            services.AddInfrastructure(builder.Configuration);
            services.AddApplicationInit();

            services.AddAuthorization();

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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/event", (HttpContext httpContext, IQueryDispatcher queryDispatcher) =>
            {
                return Results.Ok(queryDispatcher.QueryAsync(new GetEvent() { Id = Guid.NewGuid() }));
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            app.Run();
        }
    }
}