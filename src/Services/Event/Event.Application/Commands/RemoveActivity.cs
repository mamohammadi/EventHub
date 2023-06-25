using Event.Application.Commands.Abstractions;

namespace Event.Application.Commands
{
    public record RemoveActivity(Guid EventId, string Name) : ICommand;
}
