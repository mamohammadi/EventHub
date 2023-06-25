using Event.Domain.ValueObjects;
using Event.Infrastructure.EF.Read.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure.EF.Read.Extensions
{
    internal static class LocationReadModelExtensions
    {
        public static Location ToDomainLocation(this LocationReadModel location)
        {
            return new Location(location.Country, location.City, location.AddressLine1);
        }
    }
}
