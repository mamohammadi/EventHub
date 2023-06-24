﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Domain
{
    public interface ICommandHandler<in TCommand> where TCommand: ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
