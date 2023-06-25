using Event.Application.Commands;
using Event.Application.Commands.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Event.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            var assemblyToSearch = Assembly.GetCallingAssembly();

            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

            return services.Scan(s => s.FromAssemblies(assemblyToSearch)
                           .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                           .AsImplementedInterfaces()
                           .WithScopedLifetime());
        }
    }
}
