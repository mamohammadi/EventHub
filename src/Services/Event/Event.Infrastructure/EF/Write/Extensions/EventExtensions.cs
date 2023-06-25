using Event.Infrastructure.EF.Write.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure.EF.Write.Extensions
{
    internal static class EventExtensions
    {
        public static EventWriteModel ToEventWriteModel(this Domain.Entities.Event @event)
        {
            return new EventWriteModel()
            {
                Title = @event.Title,
                Date = @event.Date,
                Description = @event.Description,
                Location = @event.Location.ToLocationWriteModel(),
                Activities = @event.Activities.ToActivityWriteModels()
            };
        }
    }
}
