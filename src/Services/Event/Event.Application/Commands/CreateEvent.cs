using Event.Application.Commands.WriteModels;
using Event.Common.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.Commands
{
    public record CreateEvent(string Title, DateTime Date, string Description, LocationWriteModel Location) : ICommand;
}
