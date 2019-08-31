using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
    public interface IEntityRepository<T> 
        where T : class, new()
    {
        List<T> GetAll();

        T Get(int id);

        T Add(T entity);

        void Delete(T entity);

        T Update(T entity);
    }
}
