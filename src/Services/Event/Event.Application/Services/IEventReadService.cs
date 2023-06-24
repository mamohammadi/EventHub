using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.Services
{
    public interface IEventReadService
    {
        Task<bool> ExistsByTitleAsync(string title);
    }
}
