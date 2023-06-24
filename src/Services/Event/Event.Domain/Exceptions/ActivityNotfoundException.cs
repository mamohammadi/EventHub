using Event.Common.Exceptions;
using Event.Common.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Domain.Exceptions
{
    public class ActivityNotFoundException : EventException
    {
        public ActivityNotFoundException(ITranslationService translationService)
            : base(translationService, "ActivityNotFound") { }
    }
}
