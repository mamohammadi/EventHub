using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure.EF.Read.Models
{
    internal class LocationReadModel
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string AddressLine1 { get; set; }
    }
}
