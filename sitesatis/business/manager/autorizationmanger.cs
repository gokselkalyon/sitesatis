using sitesatis.Models.entity;
using sitesatis.Models.repository.abstracti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;


namespace sitesatis.Models.repository.manager
{
    public class autorizationmanger : IDatabase<autorization>
    {
        satissitesivol1DBEntities DB = new satissitesivol1DBEntities();
        public void create(autorization t)
        {
            DB.autorizations.Add(t);
            DB.SaveChanges();
        }

        public void delete(int id)
        {
            DB.autorizations.Remove(DB.autorizations.Find(id));
            DB.SaveChanges();
        }

        public autorization filterread(Expression<Func<autorization, bool>> filtre)
        {
            return DB.autorizations.SingleOrDefault(filtre);

        }

        public IEnumerable<autorization> read()
        {
            return DB.autorizations.ToList();
        }

        public void update(autorization t)
        {
            DB.Entry(t).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}