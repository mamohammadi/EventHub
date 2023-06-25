using Event.Application.Commands.Abstractions;

namespace Event.Application.Commands
{
    public record RemoveEvent(Guid Id) : ICommand;
}
