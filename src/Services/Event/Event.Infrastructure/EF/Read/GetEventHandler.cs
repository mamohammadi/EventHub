using Event.Application.DTO;
using Event.Application.Queries.Abstractions;
using Event.Domain.Repositories;
using Event.Infrastructure.EF.Read;
using Event.Infrastructure.EF.Read.Models;
using Microsoft.EntityFrameworkCore;

namespace Event.Application.Queries
{
    public class GetEventHandler : IQueryHandler<GetEvent, EventDTO?>
    {
        private readonly DbSet<EventReadModel> events;

        public GetEventHandler(ReadDbContext dbContext)
        {
            this.events = dbContext.Events;
        }

        public Task<EventDTO?> HandleAsync(GetEvent query)
        {
            return events.Where(e => e.Id == query.Id)
                .Select(e => new EventDTO
                {
                    Id = e.Id,
                    Title = e.Title,
                    Date = e.Date,
                    Description = e.Description,
                    Location = new Domain.ValueObjects.Location(e.Location.Country, e.Location.City, e.Location.AddressLine1)
                })
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
    }
}
