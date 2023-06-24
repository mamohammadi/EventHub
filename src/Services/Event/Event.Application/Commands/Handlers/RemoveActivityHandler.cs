using Event.Application.Exceptions;
using Event.Application.Extensions;
using Event.Application.Services;
using Event.Common.Abstractions.Commands;
using Event.Common.Abstractions.Services;
using Event.Domain.Factories;
using Event.Domain.Repositories;
using Event.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.Commands.Handlers
{
    internal sealed class RemoveActivityHandler : ICommandHandler<RemoveActivity>
    {
        private readonly IEventRepository eventRepository;
        private readonly ITranslationService translationService;

        public RemoveActivityHandler(IEventRepository eventRepository, ITranslationService translationService)
        {
            this.eventRepository = eventRepository;
            this.translationService = translationService;
        }

        public async Task HandleAsync(RemoveActivity command)
        {
            var @event = await eventRepository.GetAsync(command.EventId);
            if (@event == null)
            {
                throw new EventNotfoundException(translationService);
            }

            @event.RemoveActivity(command.Name, translationService);

            await eventRepository.UpdateAsync(@event);
        }
    }
}
