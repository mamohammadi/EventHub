using Event.Domain.ValueObjects;
using Event.Infrastructure.EF.Write.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure.EF.Write.Extensions
{
    internal static class LocationExtensions
    {
        public static LocationWriteModel ToLocationWriteModel(this Location location) =>
            new LocationWriteModel() { Country = location.Country, City = location.City, AddressLine1 = location.AddressLine1 };
    }
}
