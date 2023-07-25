using Asp.Versioning;
using Asp.Versioning.Builder;
using Event.Application.Queries.Abstractions;
using Event.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Event.Application.Commands.Abstractions;
using Event.Application.Commands;
using Event.Application.DTO;

namespace Event.API.Endpoints
{
    public static class V1
    {
        private static readonly ApiVersion API_VERSION = new(1.0);
        private static readonly string VERSION_URL = "v{version:apiVersion}";

        public static void MapV1(this IEndpointRouteBuilder routeBuilder, ApiVersionSet apiVersionSet)
        {
            routeBuilder.MapGet($"{VERSION_URL}/events", async (IQueryDispatcher queryDispatcher) =>
            {
                return Results.Ok(await queryDispatcher.QueryAsync(new GetEvents()));
            })
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(API_VERSION);

            routeBuilder.MapGet($"{VERSION_URL}/event", async (IQueryDispatcher queryDispatcher) =>
            {
                return Results.Ok(await queryDispatcher.QueryAsync(new GetEvent() { Id = Guid.NewGuid() }));
            })
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(API_VERSION);

            routeBuilder.MapPost($"{VERSION_URL}/event", async (CreateEvent command, ICommandDispatcher commandDispatcher) =>
            {
                await commandDispatcher.DispatchAsync(command);
                return Results.Ok();
            })
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(API_VERSION);

            routeBuilder.MapDelete($"{VERSION_URL}/event", async ([AsParameters] RemoveEvent command, ICommandDispatcher commandDispatcher) =>
            {
                await commandDispatcher.DispatchAsync(command);
                return Results.Ok();
            })
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(API_VERSION);

            routeBuilder.MapPost($"{VERSION_URL}/add-activity", async (AddActivity command, ICommandDispatcher commandDispatcher) =>
            {
                await commandDispatcher.DispatchAsync(command);
                return Results.Ok();
            })
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(API_VERSION);

            routeBuilder.MapDelete($"{VERSION_URL}/remove-activity", async ([AsParameters] RemoveActivity command, ICommandDispatcher commandDispatcher) =>
            {
                await commandDispatcher.DispatchAsync(command);
                return Results.Ok();
            })
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(API_VERSION);
        }
    }
}
