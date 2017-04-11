using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newssystem.Data.Repository
{
    public interface IEfGenericRepository<T>
          where T : class
    {
        IEnumerable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        int SaveChanges();
    }
}
