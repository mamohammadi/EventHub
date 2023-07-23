using Asp.Versioning;
using Asp.Versioning.Builder;
using Event.Application.Queries.Abstractions;
using Event.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Event.Application.Commands.Abstractions;
using Event.Application.Commands;

namespace Event.API.Endpoints
{
    public static class V1
    {
        private static readonly ApiVersion API_VERSION = new(1.0);
        private static readonly string VERSION_URL = "v{version:apiVersion}";

        public static void MapV1(this IEndpointRouteBuilder routeBuilder, ApiVersionSet apiVersionSet)
        {
            routeBuilder.MapGet($"{VERSION_URL}/events", (IQueryDispatcher queryDispatcher) =>
            {
                return Results.Ok(queryDispatcher.QueryAsync(new GetEvents()));
            })
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(API_VERSION);

            routeBuilder.MapGet($"{VERSION_URL}/event", (IQueryDispatcher queryDispatcher) =>
            {
                return Results.Ok(queryDispatcher.QueryAsync(new GetEvent() { Id = Guid.NewGuid() }));
            })
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(API_VERSION);

            routeBuilder.MapPost($"{VERSION_URL}/event", (CreateEvent command, ICommandDispatcher commandDispatcher) =>
            {
                return Results.Ok(commandDispatcher.DispatchAsync(command));
            })
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(API_VERSION);

            routeBuilder.MapDelete($"{VERSION_URL}/event", ([AsParameters] RemoveEvent command, ICommandDispatcher commandDispatcher) =>
            {
                return Results.Ok(commandDispatcher.DispatchAsync(command));
            })
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(API_VERSION);

            routeBuilder.MapPost($"{VERSION_URL}/add-activity", (AddActivity command, ICommandDispatcher commandDispatcher) =>
            {
                return Results.Ok(commandDispatcher.DispatchAsync(command));
            })
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(API_VERSION);

            routeBuilder.MapDelete($"{VERSION_URL}/remove-activity", ([AsParameters] RemoveActivity command, ICommandDispatcher commandDispatcher) =>
            {
                return Results.Ok(commandDispatcher.DispatchAsync(command));
            })
            .WithApiVersionSet(apiVersionSet)
            .MapToApiVersion(API_VERSION);
        }
    }
}
