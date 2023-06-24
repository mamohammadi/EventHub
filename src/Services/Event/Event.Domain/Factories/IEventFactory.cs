using Event.Domain.Entities;
using Event.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Domain.Factories
{
    public interface IEventFactory
    {
        Entities.Event Create(string title, DateTime date, string description, Location location); 
    }
}
