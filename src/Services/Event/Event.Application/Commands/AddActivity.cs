using Event.Application.Commands.Abstractions;
using Event.Application.Commands.WriteModels;
using Event.Common.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.Commands
{
    public record AddActivity(Guid EventId, string Name, long Capacity) : ICommand;
}
