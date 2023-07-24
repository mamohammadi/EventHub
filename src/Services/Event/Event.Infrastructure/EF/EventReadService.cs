using Event.Application.Services;
using Event.Infrastructure.EF.Read;
using Event.Infrastructure.EF.Read.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure.EF
{
    public sealed class EventReadService : IEventReadService
    {
        private readonly DbSet<EventReadModel> events;

        public EventReadService(ReadDbContext readDbContext) =>
            events = readDbContext.Events;

        public Task<bool> ExistsByTitleAsync(string title) =>
            events.AnyAsync(e => e.Title == title);
    }
}
