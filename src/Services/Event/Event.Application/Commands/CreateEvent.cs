using Event.Application.Commands.Abstractions;
using Event.Application.Commands.WriteModels;

namespace Event.Application.Commands
{
    public record CreateEvent(string Title, DateTime Date, string Description, LocationWriteModel Location) : ICommand;
}
