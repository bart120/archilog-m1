using ApiClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClassLibrary.Data
{
    public abstract class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

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
