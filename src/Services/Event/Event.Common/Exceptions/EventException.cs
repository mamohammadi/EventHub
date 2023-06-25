
using Event.Common.Services;

namespace Event.Common.Exceptions
{
    public abstract class EventException : Exception
    {
        public EventException(ITranslationService translationService, string key) :
            base(translationService.Translate(key)) { }
    }
}
