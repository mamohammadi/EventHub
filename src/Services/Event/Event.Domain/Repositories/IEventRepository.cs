﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Domain.Repositories
{
    public interface IEventRepository : IEventReadRepository, IEventWriteRepository { }
}
