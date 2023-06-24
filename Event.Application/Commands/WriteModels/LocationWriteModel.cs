using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.Commands.WriteModels
{
    public record LocationWriteModel(string Country, string City, string AddressLine1);
}
