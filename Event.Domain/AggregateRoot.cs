using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Domain
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }
        
        public int Version { get; protected set; }

        public ICollection<IDomainEvent> DomainEvents { get; protected set; } = new List<IDomainEvent>();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            DomainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents() =>
            DomainEvents.Clear();
    }
}
