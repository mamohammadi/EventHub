using Event.Application.DTO;
using Event.Application.Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.Queries
{
    public class GetEvents : IQuery<List<EventDTO>> { }
}
