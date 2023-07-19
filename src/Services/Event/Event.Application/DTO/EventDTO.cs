using Event.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.DTO
{
    public class EventDTO
    {
        [AllowNull]
        public Guid Id { get; set; }

        [AllowNull]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        [AllowNull]
        public string Description { get; set; }

        [AllowNull]
        public Location Location { get; set; }
    }
}
