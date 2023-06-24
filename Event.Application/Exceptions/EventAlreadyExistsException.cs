using Event.Common.Exceptions;
using Event.Common.Services;
using Event.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.Exceptions
{
    public class EventAlreadyExistsException : EventException
    {
        public EventAlreadyExistsException(ITranslationService translationService):
            base(translationService, "EventAlreadyExists") { }
    }
}
