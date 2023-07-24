using Event.Infrastructure.EF.Write.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure.EF.Write
{
    public sealed class WriteDbContext : DbContext
    {
        internal DbSet<EventWriteModel> Events { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Event");

            var eventBuilder = modelBuilder.Entity<EventWriteModel>();
            eventBuilder.OwnsOne(e => e.Location);
            eventBuilder.OwnsMany(e => e.Activities);
        }
    }
}
