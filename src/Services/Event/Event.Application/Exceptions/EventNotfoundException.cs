using Event.Common.Exceptions;
using Event.Common.Services;

namespace Event.Application.Exceptions
{
    public class EventNotfoundException : EventException
    {
        public EventNotfoundException(ITranslationService translationService)
            : base(translationService, "EventNotFound") { }
    }
}
