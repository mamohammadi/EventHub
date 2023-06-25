using Event.Common.Exceptions;
using Event.Common.Services;

namespace Event.Application.Exceptions
{
    public class EventAlreadyExistsException : EventException
    {
        public EventAlreadyExistsException(ITranslationService translationService):
            base(translationService, "EventAlreadyExists") { }
    }
}
