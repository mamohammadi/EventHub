using Event.Application.Commands.Abstractions;
using Event.Application.Exceptions;
using Event.Common.Services;
using Event.Domain.Repositories;

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

            @event.RemoveActivity(command.Name);

            await eventRepository.UpdateAsync(@event);
        }
    }
}
