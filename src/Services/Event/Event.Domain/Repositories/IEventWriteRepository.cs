using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Domain.Repositories
{
    public interface IEventWriteRepository
    {
        Task CreateAsync(Entities.Event @event);

        Task UpdateAsync(Entities.Event @event);

        Task DeleteAsync(Entities.Event @event);
    }
}
