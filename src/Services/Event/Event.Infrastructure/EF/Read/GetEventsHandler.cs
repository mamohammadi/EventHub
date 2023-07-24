using Event.Application.DTO;
using Event.Application.Queries.Abstractions;
using Event.Domain.Repositories;
using Event.Infrastructure.EF.Read;
using Event.Infrastructure.EF.Read.Models;
using Microsoft.EntityFrameworkCore;

namespace Event.Application.Queries
{
    public class GetEventsHandler : IQueryHandler<GetEvents, List<EventDTO>>, IQueryHandler<IQuery<List<EventDTO>>, List<EventDTO>>
    {
        private readonly DbSet<EventReadModel> events;

        public GetEventsHandler(ReadDbContext dbContext)
        {
            this.events = dbContext.Events;
        }

        public Task<List<EventDTO>> HandleAsync(GetEvents query)
        {
            return events
                .Select(e => new EventDTO
                {
                    Id = e.Id,
                    Title = e.Title,
                    Date = e.Date,
                    Description = e.Description,
                    Location = new Domain.ValueObjects.Location(e.Location.Country, e.Location.City, e.Location.AddressLine1)
                })
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<List<EventDTO>> HandleAsync(IQuery<List<EventDTO>> query)
        {
            return HandleAsync((GetEvents)query);
        }
    }
}
