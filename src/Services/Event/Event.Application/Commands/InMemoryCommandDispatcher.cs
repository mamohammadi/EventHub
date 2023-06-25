using Event.Application.Commands.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Application.Commands
{
    public class InMemoryCommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        async Task ICommandDispatcher.DispatchAsync<TCommand>(TCommand command)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

                await handler.HandleAsync(command);
            }
        }
    }
}
