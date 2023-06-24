using Event.Application.Exceptions;
using Event.Application.Extentions;
using Event.Application.Services;
using Event.Common.Abstractions.Commands;
using Event.Common.Abstractions.Services;
using Event.Domain.Repositories;
using Event.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.Commands.Handlers
{
    internal sealed class AddActivityHandler : ICommandHandler<AddActivity>
    {
        private readonly IEventRepository eventRepository;
        private readonly ITranslationService translationService;

        public AddActivityHandler(IEventRepository eventRepository, ITranslationService translationService)
        {
            this.eventRepository = eventRepository;
            this.translationService = translationService;
        }

        public async Task HandleAsync(AddActivity command)
        {
            var @event = await eventRepository.GetAsync(command.EventId);
            if (@event == null)
            {
                throw new EventNotfoundException(translationService);
            }

            var activity = new Activity(command.Name, command.Capacity);
            @event.AddActivity(activity, translationService);

            await eventRepository.CreateAsync(@event);
        }
    }
}
