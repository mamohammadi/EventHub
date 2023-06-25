using Event.Application.Commands.Abstractions;

namespace Event.Application.Commands
{
    public record AddActivity(Guid EventId, string Name, long Capacity) : ICommand;
}
