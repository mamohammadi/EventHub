using Event.Domain.ValueObjects;
using Event.Infrastructure.EF.Write.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure.EF.Write.Extensions
{
    internal static class ActivityExtensions
    {
        public static ActivityWriteModel ToActivityWriteModel(this Activity activity) =>
            new ActivityWriteModel() { Name = activity.Name, Capacity = activity.Capacity };

        public static IEnumerable<ActivityWriteModel> ToActivityWriteModels(this IEnumerable<Activity> activities) =>
            activities.Select(a => a.ToActivityWriteModel());
    }
}
