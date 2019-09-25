using sitesatis.Models.entity;
using sitesatis.Models.repository.abstracti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace sitesatis.Models.repository.manager
{
    public class usermanager : IDatabase<user>
    {
        satissitesivol1DBEntities DB = new satissitesivol1DBEntities();
        public void create(user t)
        {
            DB.users.Add(t);
            DB.SaveChanges();
        }

        public void delete(int id)
        {
            DB.users.Remove(DB.users.Find(id));
            DB.SaveChanges();
        }

        public user filterread(Expression<Func<user, bool>> filtre)
        {
            return DB.users.SingleOrDefault(filtre);
        }

        public IEnumerable<user> read()
        {
          return DB.users.ToList();
        }

        public void update(user t)
        {
            DB.users.Attach(t);
            DB.Entry(t).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}