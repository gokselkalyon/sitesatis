using sitesatis.Models.entity;
using sitesatis.Models.repository.abstracti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;


namespace sitesatis.Models.repository.manager
{
    public class productmanager : IDatabase<product>
    {

        public void create(product t)
        {
            using(satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                DB.products.Add(t);
                DB.SaveChanges();
            }
        }

        public void delete(int id)
        {
            using(satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                DB.products.Remove(DB.products.Find(id));
                DB.SaveChanges();
            }
        }

        public product filterread(Expression<Func<product, bool>> filtre)
        {
            using(satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                return DB.products.SingleOrDefault(filtre);
            }
        }
        public List<product> filtre(Expression<Func<product, bool>> filtre)
        {
            using(satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                return DB.products.Where(filtre).ToList();
            }
        }

        public IEnumerable<product> read()
        {
            satissitesivol1DBEntities DB = new satissitesivol1DBEntities();
            return DB.products.ToList();
        }

        public void update(product t)
        {
            using(satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                DB.products.Attach(t);
                DB.Entry(t).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
            }
        }
        public int count()
        {
            using(satissitesivol1DBEntities DB = new satissitesivol1DBEntities())
            {
                return DB.products.Count();
            }
        }

    }
}