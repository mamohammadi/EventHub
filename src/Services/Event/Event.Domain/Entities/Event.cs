using Event.Common.Services;
using Event.Domain.Events;
using Event.Domain.Exceptions;
using Event.Domain.ValueObjects;
using System.Diagnostics.CodeAnalysis;

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
        public IEnumerable<Activity> Activities => activities;

        private ITranslationService translationService;

        internal Event(string title, DateTime date, string description, Location location, ITranslationService translationService)
        {
            Title = title;
            Date = date;
            Description = description;
            Location = location;
            this.translationService = translationService;
        }

        public void AddActivity(Activity activity)
        {
            if(activities.Any(a => a.Name == activity.Name))
            {
                throw new ActivityAlreadyExistsException(translationService);
            }
            activities.Add(activity);
            AddDomainEvent(new ActivityAdded(this, activity));
        }

        public void RemoveActivity(string name)
        {
            var activity = GetActivity(name);
            activities.Remove(activity);
            AddDomainEvent(new ActivityRemoved(this, activity));
        }

        public Activity GetActivity(string name)
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
