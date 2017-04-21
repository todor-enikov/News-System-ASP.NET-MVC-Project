using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Newssystem.Data
{
    public interface INewsSystemDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
