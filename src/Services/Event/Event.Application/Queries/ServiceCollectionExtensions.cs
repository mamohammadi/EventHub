using Event.Application.Commands.Abstractions;
using Event.Application.Queries.Abstractions;
using Event.Common.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Event.Application.Queries
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
        {
            var assemblyToSearch = Assembly.GetCallingAssembly();

            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

            return services.Scan(s => s.FromAssemblies(assemblyToSearch)
                           .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                           .AsImplementedInterfaces()
                           .WithScopedLifetime());
        }
    }
}
