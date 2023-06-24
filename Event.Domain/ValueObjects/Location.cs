using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Domain.ValueObjects
{
    public record Location(string Country, string City, string AddressLine1);
}
