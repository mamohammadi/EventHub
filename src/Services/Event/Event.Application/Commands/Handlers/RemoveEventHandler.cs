using Event.Application.Commands.Abstractions;
using Event.Application.Exceptions;
using Event.Common.Services;
using Event.Domain.Repositories;

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
