using Event.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure.EF
{
    public sealed class EventRepository : IEventRepository
    {
        private readonly IEventReadRepository eventReadRepository;
        private readonly IEventWriteRepository eventWriteRepository;

        public EventRepository(IEventReadRepository eventReadRepository, IEventWriteRepository eventWriteRepository)
        {
            this.eventReadRepository = eventReadRepository;
            this.eventWriteRepository = eventWriteRepository;
        }

        public Task CreateAsync(Domain.Entities.Event @event)
        {
            return eventWriteRepository.CreateAsync(@event);
        }

        public Task DeleteAsync(Domain.Entities.Event @event)
        {
            return eventWriteRepository.DeleteAsync(@event);
        }

        public Task<Domain.Entities.Event?> GetAsync(Guid Id)
        {
            return eventReadRepository.GetAsync(Id);
        }

        public Task UpdateAsync(Domain.Entities.Event @event)
        {
            return eventWriteRepository.UpdateAsync(@event);
        }
    }
}
