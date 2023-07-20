using Event.Application.Commands;
using Event.Application.Commands.Abstractions;
using Event.Application.Queries;
using Event.Application.Queries.Abstractions;
using Event.Common.Services;
using Event.Domain.Factories;
using Event.Domain.Repositories;
using Event.Infrastructure.EF;
using Event.Infrastructure.EF.Read;
using Event.Infrastructure.EF.Write;
using Event.Infrastructure.Translation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Event.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services
                .AddSingleton<IEventFactory, EventFactory>()
                .AddCommandHandlers()
                .AddQueryHandlers();
        }

        private static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            var assemblyToSearch = Assembly.GetCallingAssembly();

            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

            return services.Scan(s => s.FromAssemblies(assemblyToSearch)
                           .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                           .AsImplementedInterfaces()
                           .WithScopedLifetime());
        }

        private static IServiceCollection AddQueryHandlers(this IServiceCollection services)
        {
            var assemblyToSearch = Assembly.GetCallingAssembly();

            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

            return services.Scan(s => s.FromAssemblies(assemblyToSearch)
                           .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                           .AsImplementedInterfaces()
                           .WithScopedLifetime());
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITranslationService, TranslationService>();
            return services.AddSQLDB(configuration);
        }

        private static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<ReadDbContext>(optionsBuilder =>
                        optionsBuilder.UseSqlServer(connectionString))
                    .AddDbContext<WriteDbContext>(optionsBuilder =>
                        optionsBuilder.UseSqlServer(connectionString))
                    .AddScoped<IEventReadRepository, EventReadRepository>()
                    .AddScoped<IEventWriteRepository, EventWriteRepository>()
                    .AddScoped<IEventRepository, EventRepository>();

            return services;
        }

        public static IServiceCollection AddApplicationInit(this IServiceCollection services) =>
            services.AddHostedService<ApplicationInit>();
    }
}
