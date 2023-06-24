using Microsoft.Extensions.DependencyInjection;

namespace Event.Common.Abstractions.Commands
{
    internal class InMemoryCommandDispatcher : ICommandDispatcher
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
                var handler = scope.ServiceProvider.GetService<ICommandHandler<TCommand>>();

                await handler.HandleAsync(command);
            }
        }
    }
}
