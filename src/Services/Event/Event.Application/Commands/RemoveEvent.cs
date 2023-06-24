using Event.Application.Commands.WriteModels;
using Event.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.Commands
{
    public record RemoveEvent(Guid Id) : ICommand;
}
