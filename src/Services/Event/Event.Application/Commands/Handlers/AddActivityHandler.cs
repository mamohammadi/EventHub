using Event.Application.Commands.Abstractions;
using Event.Application.Exceptions;
using Event.Common.Services;
using Event.Domain.Repositories;
using Event.Domain.ValueObjects;

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
