using Event.Common.Services;
using Event.Domain.Entities;
using Event.Domain.Events;
using Event.Domain.Exceptions;
using Event.Domain.Factories;
using Event.Domain.ValueObjects;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventUnitTests.Domain
{
    public class EventTests
    {
        private readonly IEventFactory eventFactory;

        public EventTests()
        {
            Mock<ITranslationService> translationServiceMock = new Mock<ITranslationService>();
            translationServiceMock.Setup(ts => ts.Translate(It.IsAny<string>()))
                .Returns(string.Empty);

            eventFactory = new EventFactory(translationServiceMock.Object);
        }

        private Event.Domain.Entities.Event CreateDefaultEvent()
        {
            return eventFactory.Create("Event1", DateTime.Now, "Nothing", new Location("USA", "LA", "1st"));
        }

        private Activity CreateDefaultActivity()
        {
            return new Activity("Stand up comedy", 50);
        }

        [Fact]
        public void AddActivity_NonExistingActivity_ShouldAddActivityAndActivityAddedDomainEvent()
        {
            var @event = CreateDefaultEvent();
            var activity = CreateDefaultActivity();
            var activityAddedEvent = new ActivityAdded(@event, activity);

            @event.AddActivity(activity);

            Assert.True(@event.Activities.SingleOrDefault(a => a == activity) != null);
            Assert.True(@event.DomainEvents.SingleOrDefault(e => e is ActivityAdded && (ActivityAdded)e == activityAddedEvent) != null);
        }

        [Fact]
        public void AddActivity_ExistingActivity_ThrowsActivityAlreadyExistsException()
        {
            var @event = CreateDefaultEvent();
            var activity = CreateDefaultActivity();

            @event.AddActivity(activity);
            Assert.Throws<ActivityAlreadyExistsException>(() => @event.AddActivity(activity));
        }

        [Fact]
        public void RemoveActivity_ExistingActivity_ShouldRemoveActivityAndAddActivityRemovedEvent()
        {
            var @event = CreateDefaultEvent();
            var activity = CreateDefaultActivity();
            var activityRemovedEvent = new ActivityRemoved(@event, activity);

            @event.AddActivity(activity);
            @event.RemoveActivity(activity.Name);

            Assert.True(!@event.Activities.Any(a => a == activity));
            Assert.True(@event.DomainEvents.SingleOrDefault(e => e is ActivityRemoved && (ActivityRemoved)e == activityRemovedEvent) != null);
        }

        [Fact]
        public void RemoveActivity_NonExistingActivity_ThrowsActivityNotFoundException()
        {
            var @event = CreateDefaultEvent();
            var activity = CreateDefaultActivity();

            Assert.Throws<ActivityNotFoundException>( () => @event.RemoveActivity(activity.Name));
        }

        [Fact]
        public void GetActivity_ExistingActivity_ShouldReturnExistingActivity()
        {
            var @event = CreateDefaultEvent();
            var activity = CreateDefaultActivity();

            @event.AddActivity(activity);
            var actual = @event.GetActivity(activity.Name);

            Assert.Equal(activity, actual);
        }

        [Fact]
        public void GetActivity_NonExistingActivity_ThrowsActivityNotFoundException()
        {
            var @event = CreateDefaultEvent();
            var activity = CreateDefaultActivity();

            Assert.Throws<ActivityNotFoundException>(() => @event.RemoveActivity(activity.Name));
        }
    }
}
