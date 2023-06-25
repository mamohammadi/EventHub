using Event.Domain.Repositories;
using Event.Infrastructure.EF.Write.Extensions;
using Event.Infrastructure.EF.Write.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure.EF.Write
{
    public class EventWriteRepository : IEventWriteRepository
    {
        private readonly WriteDbContext writeDbContext;
        private readonly DbSet<EventWriteModel> events;

        public EventWriteRepository(WriteDbContext writeDbContext)
        {
            this.writeDbContext = writeDbContext;
            this.events = writeDbContext.Events;
        }

        public Task CreateAsync(Domain.Entities.Event @event)
        {
            events.Add(@event.ToEventWriteModel());
            return writeDbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Domain.Entities.Event @event)
        {
            events.Remove(@event.ToEventWriteModel());
            return writeDbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(Domain.Entities.Event @event)
        {
            events.Update(@event.ToEventWriteModel());
            return writeDbContext.SaveChangesAsync();
        }
    }
}
