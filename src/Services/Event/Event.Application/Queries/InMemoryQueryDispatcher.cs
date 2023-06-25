using Event.Application.Queries.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Application.Queries
{
    internal sealed class InMemoryQueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public InMemoryQueryDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            using(var scope = serviceProvider.CreateScope())
            {
                //var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
                //var handler = scope.ServiceProvider.GetRequiredService(handlerType);
                var handler = scope.ServiceProvider.GetRequiredService<IQueryHandler<IQuery<TResult>, TResult>>();
                return handler.HandleAsync(query);
            }
        }
    }
}
