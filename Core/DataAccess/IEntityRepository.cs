using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    /*
     * Generic Yapı
     * DataAccess Katmanımızdaki her entity için kod tekrarını önlemek için oluşturduğumuz interface.
     * Temel methodları oluşturarak, ihtiyaç duyan her tablomuz için kullanabiliriz.
     */

    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        T Get(Expression<Func<T,bool>> filter);
    }
}
