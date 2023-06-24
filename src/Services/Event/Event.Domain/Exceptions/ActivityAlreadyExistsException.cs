using Event.Common.Exceptions;
using Event.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Domain.Exceptions
{
    public class ActivityAlreadyExistsException : EventException
    {
        public ActivityAlreadyExistsException(ITranslationService translationService)
            : base(translationService, "ActivityAlreadyExists") { }
    }
}
