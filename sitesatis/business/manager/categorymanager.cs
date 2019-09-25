using sitesatis.Models.entity;
using sitesatis.Models.repository.abstracti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace sitesatis.Models.repository.manager
{
    public class categorymanager:IDatabase<category>
    {
        satissitesivol1DBEntities DB = new satissitesivol1DBEntities();

        public void create(category t)
        {
            DB.categories.Add(t);
            DB.SaveChanges();
        }

        public void delete(int id)
        {
            DB.categories.Remove(DB.categories.Find(id));
            DB.SaveChanges();
        }

        public category filterread(Expression<Func<category, bool>> filtre)
        {
            return DB.categories.SingleOrDefault(filtre);
        }

        public IEnumerable<category> read()
        {
            return DB.categories.ToList();
        }

        public void update(category t)
        {
            DB.categories.Attach(t);
            DB.Entry(t).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}