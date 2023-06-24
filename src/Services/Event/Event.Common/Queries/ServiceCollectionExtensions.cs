using Event.Common.Abstractions.Commands;
using Event.Common.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Event.Common.Queries
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
