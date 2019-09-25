using sitesatis.Models.entity;
using sitesatis.Models.repository.abstracti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace sitesatis.Models.repository.manager
{
    public class sitemastermanager : IDatabase<sitemaster>
    {
        satissitesivol1DBEntities DB = new satissitesivol1DBEntities();
        public void create(sitemaster t)
        {
            DB.sitemasters.Add(t);
            DB.SaveChanges();
        }

        public void delete(int id)
        {
            DB.sitemasters.Remove(DB.sitemasters.Find(id));
            DB.SaveChanges();
        }

        public sitemaster filterread(Expression<Func<sitemaster, bool>> filtre)
        {
            return DB.sitemasters.SingleOrDefault(filtre);
        }

        public IEnumerable<sitemaster> read()
        {
            return DB.sitemasters.ToList();
        }

        public void update(sitemaster t)
        {
            DB.sitemasters.Attach(t);
            DB.Entry(t).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}