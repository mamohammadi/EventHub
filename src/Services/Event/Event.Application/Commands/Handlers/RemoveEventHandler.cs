using Event.Application.Exceptions;
using Event.Application.Services;
using Event.Common.Abstractions.Commands;
using Event.Common.Abstractions.Services;
using Event.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.Commands.Handlers
{
    internal sealed class RemoveEventHandler : ICommandHandler<RemoveEvent>
    {
        private readonly IEventRepository eventRepository;
        private readonly ITranslationService translationService;

        public RemoveEventHandler(IEventRepository eventRepository, ITranslationService translationService)
        {
            this.eventRepository = eventRepository;
            this.translationService = translationService;
        }

        public async Task HandleAsync(RemoveEvent command)
        {
            var @event = await eventRepository.GetAsync(command.Id);
            if (@event == null)
            {
                throw new EventNotfoundException(translationService);
            }

            await eventRepository.DeleteAsync(@event);
        }
    }
}
