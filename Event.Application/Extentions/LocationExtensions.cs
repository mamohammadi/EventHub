using Event.Application.Commands.WriteModels;
using Event.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.Extentions
{
    internal static class LocationWriteModelExtensions
    {
        public static Location ToDomainLocation(this LocationWriteModel locationWriteModel)
            => new Location(locationWriteModel.Country, locationWriteModel.City, locationWriteModel.AddressLine1);
    }
}
