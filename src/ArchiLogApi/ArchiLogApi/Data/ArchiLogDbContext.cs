using ApiClassLibrary.Data;
using ArchiLogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchiLogApi.Data
{
    public class ArchiLogDbContext:BaseDbContext
    {
        public ArchiLogDbContext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("archi");
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
