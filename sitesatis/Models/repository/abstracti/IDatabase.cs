using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace sitesatis.Models.repository.abstracti
{
    public interface IDatabase<T> where T:class
    {
        void create(T t);
        IEnumerable<T> read();
        T filterread(Expression<Func<T,bool>> filtre);
        void update(T t);
        void delete(int id);
    }
}