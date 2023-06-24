using Event.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Domain.Events
{
    public record ActivityRemoved(Entities.Event Event, Activity Activity) : IDomainEvent;
}
