using Event.Application.Commands.Abstractions;
using Event.Application.Exceptions;
using Event.Application.Extensions;
using Event.Application.Services;
using Event.Common.Services;
using Event.Domain.Factories;
using Event.Domain.Repositories;

namespace Event.Application.Commands.Handlers
{
    internal sealed class CreateEventHandler : ICommandHandler<CreateEvent>
    {
        private readonly IEventRepository eventRepository;
        private readonly IEventReadService eventReadService;
        private readonly ITranslationService translationService;
        private readonly IEventFactory eventFactory;

        public CreateEventHandler(IEventRepository eventRepository, IEventReadService eventReadService, ITranslationService translationService, IEventFactory eventFactory)
        {
            this.eventRepository = eventRepository;
            this.eventReadService = eventReadService;
            this.translationService = translationService;
            this.eventFactory = eventFactory;
        }

        public async Task HandleAsync(CreateEvent command)
        {
            if(await eventReadService.ExistsByTitleAsync(command.Title))
            {
                throw new EventAlreadyExistsException(translationService);
            }

            var @event = eventFactory.Create(command.Title, command.Date, command.Description, command.Location.ToDomainLocation());
            
            await eventRepository.CreateAsync(@event);
        }
    }
}
