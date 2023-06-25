using Event.Domain.Factories;
using Event.Domain.Repositories;
using Event.Infrastructure.EF.Read.Extensions;
using Event.Infrastructure.EF.Read.Models;
using Microsoft.EntityFrameworkCore;

namespace Event.Infrastructure.EF.Read
{
    internal class EventReadRepository : IEventReadRepository
    {
        private readonly ReadDbContext readDbContext;
        private readonly IEventFactory eventFactory;

        private DbSet<EventReadModel> events => readDbContext.Events;

        public EventReadRepository(ReadDbContext readDbContext, IEventFactory eventFactory)
        {
            this.readDbContext = readDbContext;
            this.eventFactory = eventFactory;
        }

        public async Task<Domain.Entities.Event?> GetAsync(Guid Id)
        {
            var result = await events.SingleOrDefaultAsync(e => e.Id == Id);
            if (result == null)
            {
                return null;
            }

            return eventFactory.Create(result.Title, result.Date, result.Description, result.Location.ToDomainLocation());
        }
    }
}
