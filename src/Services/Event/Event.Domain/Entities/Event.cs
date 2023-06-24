using Event.Common.Abstractions.Services;
using Event.Domain.Events;
using Event.Domain.Exceptions;
using Event.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Domain.Entities
{
    public class Event : AggregateRoot<Guid>
    {
        [AllowNull]
        public string Title { get; private set; }

        public DateTime Date { get; private set; }

        [AllowNull]
        public string Description { get; private set; }

        [AllowNull]
        public Location Location { get; private set; }
        
        private readonly ICollection<Activity> activities = new List<Activity>();

        internal Event(string title, DateTime date, string description, Location location)
        {
            Title = title;
            Date = date;
            Description = description;
            Location = location;
        }

        public Event() 
        {
        }

        public void AddActivity(Activity activity, ITranslationService translationService)
        {
            if(activities.Any(a => a.Name == activity.Name))
            {
                throw new ActivityAlreadyExistsException(translationService);
            }
            activities.Add(activity);
            AddDomainEvent(new ActivityAdded(this, activity));
        }

        public void RemoveActivity(string name, ITranslationService translationService)
        {
            var activity = GetActivity(name, translationService);
            activities.Remove(activity);
            AddDomainEvent(new ActivityRemoved(this, activity));
        }

        public Activity GetActivity(string name, ITranslationService translationService)
        {
            var activity = activities.FirstOrDefault(a => a.Name == name);
            if(activity == null)
            {
                throw new ActivityNotFoundException(translationService);
            }
            return activity;
        }

        public void ClearActivities() =>
            activities.Clear();
    }
}
