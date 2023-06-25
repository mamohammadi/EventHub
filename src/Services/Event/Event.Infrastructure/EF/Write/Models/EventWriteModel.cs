using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure.EF.Write.Models
{
    internal class EventWriteModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public LocationWriteModel Location { get; set; }

        public IEnumerable<ActivityWriteModel> Activities { get; set; }

        public int Version { get; set; }
    }
}
