using sitesatis.Models.entity;
using sitesatis.Models.repository.abstracti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace sitesatis.Models.repository.manager
{
    public class sitepagemanager : IDatabase<sitepage>
    {
        satissitesivol1DBEntities DB = new satissitesivol1DBEntities();
        public void create(sitepage t)
        {
            DB.sitepages.Add(t);
            DB.SaveChanges();
        }

        public void delete(int id)
        {
            DB.sitepages.Remove(DB.sitepages.Find(id));
            DB.SaveChanges();
        }

        public sitepage filterread(Expression<Func<sitepage, bool>> filtre)
        {
            return DB.sitepages.SingleOrDefault(filtre);
        }

        public IEnumerable<sitepage> read()
        {
            return DB.sitepages.ToList();
        }

        public void update(sitepage t)
        {
            DB.sitepages.Attach(t);
            DB.Entry(t).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}