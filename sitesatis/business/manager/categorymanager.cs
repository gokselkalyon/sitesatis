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
        

        public void create(category t)
        {
            using(satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                DB.categoryinsert(t.category_name.ToString());
                DB.SaveChanges();
            }
        }

        public void delete(int id)
        {
            using(satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                DB.categories.Remove(DB.categories.Find(id));
                DB.SaveChanges();
            }
        }

        public category filterread(Expression<Func<category, bool>> filtre)
        {
            using(satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                return DB.categories.SingleOrDefault(filtre);
            }
        }

        public IEnumerable<category> read()
        {
            using(satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                return DB.categories.ToList();
            }
        }

        public void update(category t)
        {
            using(satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                DB.categoryupdate(t.category_name.ToString(),t.id);
                DB.SaveChanges();
            }
        }
    }
}