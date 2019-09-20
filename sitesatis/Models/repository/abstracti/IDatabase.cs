using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sitesatis.Models.repository.abstracti
{
    public interface IDatabase<T>
    {
        void create(T t);
        IEnumerable<T> read();
        T filterread(int id);
        void update(T t);
        void delete(int id);
    }
}