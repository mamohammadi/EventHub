using Event.Common.Services;
using Event.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Domain.Factories
{
    public sealed class EventFactory : IEventFactory
    {
        private readonly ITranslationService translationService;

        public EventFactory(ITranslationService translationService)
        {
            this.translationService = translationService;
        }

        public Entities.Event Create(string title, DateTime date, string description, Location location)
            => new Entities.Event(title, date, description, location, translationService);
    }
}
