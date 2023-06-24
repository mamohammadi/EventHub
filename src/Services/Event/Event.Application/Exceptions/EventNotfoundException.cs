using Event.Common.Exceptions;
using Event.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.Exceptions
{
    public class EventNotfoundException : EventException
    {
        public EventNotfoundException(ITranslationService translationService)
            : base(translationService, "EventNotFound") { }
    }
}
