using Event.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Common.Exceptions
{
    public abstract class EventException : Exception
    {
        public EventException(ITranslationService translationService, string key) :
            base(translationService.Translate(key)) { }
    }
}
