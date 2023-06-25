using Event.Common.Exceptions;
using Event.Common.Services;

namespace Event.Domain.Exceptions
{
    public class ActivityNotFoundException : EventException
    {
        public ActivityNotFoundException(ITranslationService translationService)
            : base(translationService, "ActivityNotFound") { }
    }
}
