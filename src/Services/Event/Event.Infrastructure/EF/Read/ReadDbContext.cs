using Event.Infrastructure.EF.Read.Models;
using Event.Infrastructure.EF.Write.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure.EF.Read
{
    internal sealed class ReadDbContext : DbContext
    {
        public DbSet<EventReadModel> Events { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Event");

            var eventBuilder = modelBuilder.Entity<EventReadModel>();
            eventBuilder.OwnsOne(e => e.Location);
            eventBuilder.OwnsMany(e => e.Activities);
        }
    }
}
