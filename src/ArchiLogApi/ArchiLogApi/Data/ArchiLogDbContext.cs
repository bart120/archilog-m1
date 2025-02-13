using ApiClassLibrary.Data;
using ArchiLogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchiLogApi.Data
{
    /// <summary>
    /// Class de liaison entre la BDD et les modèles objet.
    /// </summary>
    public class ArchiLogDbContext:BaseDbContext
    {
        public ArchiLogDbContext(DbContextOptions options):base(options)
        {
        }

        /// <summary>
        /// paramétrage du dbContext, ici modification du schéma sqlserver des tables.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("archi");
        }

        /// <summary>
        /// DbSet faisant un lien direct entre le modèle et la table en bdd afin de générer les requetes SQL.
        /// </summary>
        public DbSet<Car> Cars { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
