using Event.Application.DTO;
using Event.Application.Queries.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Event.Application.Queries
{
    public sealed class InMemoryQueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public InMemoryQueryDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var handler = scope.ServiceProvider.GetRequiredService<IQueryHandler<IQuery<TResult>, TResult>>();
                return await handler.HandleAsync(query);
            }
        }
    }
}
