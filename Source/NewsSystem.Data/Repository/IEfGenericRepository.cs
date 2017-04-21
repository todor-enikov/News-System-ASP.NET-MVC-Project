using System.Linq;

namespace Newssystem.Data.Repository
{
    public interface IEfGenericRepository<T>
          where T : class
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        int SaveChanges();
    }
}
