using ApiClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClassLibrary.Data
{
    /// <summary>
    /// Class abstraite (qui doit être héritée) qui permet d'ajouter les fonctions de suppression, ajout et mise à jour personnalisées pour les DbContext enfants.
    /// </summary>
    public abstract class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// override de la méthode SaveChangesAsync, qui permet d'ajouter des fonctions avant l'appel de la méthode d'origine
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeAddedState();
            ChangeModifiedState();
            ChangeDeletedState();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            ChangeAddedState();
            ChangeModifiedState();
            ChangeDeletedState();
            return base.SaveChanges();
        }

        /// <summary>
        /// Recherche les entitees avec l'état à Deleted et modifie la valeur du champ Deleted à true et change l'état en Modified 
        /// afin de ne pas avoir de suppression phisyque en bdd.
        /// Uniquement pour les entitées de type (qui hérite de) BaseModel.
        /// </summary>
        private void ChangeDeletedState()
        {
            var deleteEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);
            foreach (var item in deleteEntities)
            {
                if (item.Entity is BaseModel model)
                {
                    model.Deleted = true;
                    item.State = EntityState.Modified;
                }
            }
        }

        private void ChangeModifiedState()
        {
            var modifiedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var item in modifiedEntities)
            {
                if (item.Entity is BaseModel model)
                {
                    model.UpdatedAt = DateTime.Now;
                }
            }
        }

        private void ChangeAddedState()
        {
            var addEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            foreach (var item in addEntities)
            {
                if (item.Entity is BaseModel model)
                {
                    model.CreatedAt = DateTime.Now;
                    model.Deleted = false;
                }
            }
        }

    }
}
